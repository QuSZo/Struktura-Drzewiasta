using AutoMapper;
using Microsoft.EntityFrameworkCore;
using StrukturaDrzewiasta.App.Middleware;
using StrukturaDrzewiasta.App.Models.DbModels;
using StrukturaDrzewiasta.Shared;

namespace StrukturaDrzewiasta.App.Services;

public interface ITreeStructureService
{
    void CreateNode(CreateNodeDto createNodeDto);
    void EditNode(EditNodeDto editNodeDto);
    public void MoveNode(MoveNodeDto moveNodeDto);
    IEnumerable<ReadNodeTreeDto> GetNodeTree(string sortedBy);
    IEnumerable<ReadNodeTreeDto> GetNodeTree(int nodeId);
    void DeleteNode(int nodeId);
}

public class TreeStructureService : ITreeStructureService
{
    private readonly AppDbContext _appDbContext;
    private readonly IMapper _autoMapper;
    
    public TreeStructureService(AppDbContext appDbContext, IMapper autoMapper)
    {
        _appDbContext = appDbContext;
        _autoMapper = autoMapper;
    }
    
    public void CreateNode(CreateNodeDto createNodeDto)
    {
        if(createNodeDto.Name == null)
            throw new BadRequestException("The Name field is required");
        
        var parentNode = _appDbContext.Node
            .Include(node => node.Nodes)
            .FirstOrDefault(node => node.Id == createNodeDto.ParentNodeId);
        
        if (parentNode == null)
            throw new NotFoundException("Parent node doesn't exist!");

        if (parentNode.Nodes.Any(node => node.Name == createNodeDto.Name))
            throw new BadRequestException("This name exist in this scope!");

        var node = _autoMapper.Map<Node>(createNodeDto);

        _appDbContext.Node.Add(node);
        _appDbContext.SaveChanges();
    }

    public void EditNode(EditNodeDto editNodeDto)
    {
        if(editNodeDto.Name == null)
            throw new BadRequestException("The Name field is required");
        
        var nodeToEdit = _appDbContext.Node.FirstOrDefault(node => node.Id == editNodeDto.Id);
        
        if (nodeToEdit == null || nodeToEdit.Id == 1)
            throw new NotFoundException("Node doesn't exist");

        var parentNode = _appDbContext.Node
            .Include(node => node.Nodes)
            .FirstOrDefault(node => node.Id == nodeToEdit.ParentNodeId);

        if (parentNode.Nodes.Any(node => node.Name == editNodeDto.Name && node != nodeToEdit))
            throw new BadRequestException("This name exist in this scope!");

        nodeToEdit.Name = editNodeDto.Name;
        _appDbContext.Node.Update(nodeToEdit);
        _appDbContext.SaveChanges();
    }

    public void MoveNode(MoveNodeDto moveNodeDto)
    {
        var moveNode = _appDbContext.Node.FirstOrDefault(node => node.Id == moveNodeDto.Id);
        var destinationNode = _appDbContext.Node.FirstOrDefault(node => node.Id == moveNodeDto.ParentNodeId);
        
        if (moveNode == null || moveNode.Id == 1)
            throw new NotFoundException("Node doesn't exist");

        if (destinationNode == null)
            throw new NotFoundException("Destination node doesn't exist!");
        
        if (moveNode == destinationNode)
            throw new BadRequestException("The destination node is a source node");
        
        if (!CheckIfSubNode(moveNode, destinationNode))
            throw new BadRequestException("The destination node is a subnode of the source node");
        
        var parentNode = _appDbContext.Node
            .Include(node => node.Nodes)
            .FirstOrDefault(node => node.Id == destinationNode.Id);

        if (parentNode.Nodes.Any(node => node.Name == moveNode.Name && node != moveNode))
            throw new BadRequestException("This name exist in this scope!");
        
        moveNode.ParentNodeId = moveNodeDto.ParentNodeId;
        _appDbContext.Node.Update(moveNode);
        _appDbContext.SaveChanges();
    }

    public IEnumerable<ReadNodeTreeDto> GetNodeTree(string sortedBy)
    {
        var nodeTreeFromDb = _appDbContext.Node.ToList()
            .Where(node => node.ParentNodeId == 1).ToList();

        switch(sortedBy)
        { 
            case "name":
                nodeTreeFromDb = nodeTreeFromDb
                    .OrderBy(node => node.Name)
                    .ToList();
                break;
            
            default:
                nodeTreeFromDb = nodeTreeFromDb
                                .OrderBy(node => node.Id)
                                .ToList();
                break;
        }
        
        nodeTreeFromDb.ForEach(node => node.RecursiveOrder(sortedBy));

        var nodeTree = _autoMapper.Map<List<ReadNodeTreeDto>>(nodeTreeFromDb);
        return nodeTree;
    }

    public IEnumerable<ReadNodeTreeDto> GetNodeTree(int nodeId)
    {
        var nodeTreeFromDb = _appDbContext.Node
            .Where(node => node.ParentNodeId == nodeId)
            .ToList();
        
        var nodeTree = _autoMapper.Map<List<ReadNodeTreeDto>>(nodeTreeFromDb);
        
        return nodeTree;
    }

    public void DeleteNode(int nodeId)
    {
        var nodeToDelete = _appDbContext.Node.FirstOrDefault(node => node.Id == nodeId);
        
        if (nodeToDelete == null || nodeToDelete.Id == 1)
            throw new NotFoundException("Node doesn't exist!");
        
        _appDbContext.Node.RemoveRange(nodeToDelete);
        _appDbContext.SaveChanges();
    }
    
    private bool CheckIfSubNode(Node nodeToEdit, Node parentNode)
    {
        var editedNode = _appDbContext.Node
            .Include(node => node.Nodes)
            .FirstOrDefault(node => node == nodeToEdit);

        if (editedNode?.Nodes.Count == 0)
        {
            return true;
        }

        if (editedNode.Nodes.Contains(parentNode))
        {
            return false;
        }

        foreach (var child in editedNode.Nodes)
        {
            if (!CheckIfSubNode(child, parentNode))
            {
                return false;
            }
        }

        return true;
    }
}