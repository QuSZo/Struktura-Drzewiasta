using Microsoft.AspNetCore.Mvc;
using StrukturaDrzewiasta.App.Services;
using StrukturaDrzewiasta.Shared.Dtos;
using StrukturaDrzewiasta.Shared.Enums;

namespace StrukturaDrzewiasta.App.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TreeStructureController : Controller
{
    private readonly ITreeStructureService _treeStructureService;

    public TreeStructureController(ITreeStructureService treeStructureService)
    {
        _treeStructureService = treeStructureService;
    }
    
    [HttpPost]
    public ActionResult CreateNode([FromBody] CreateNodeDto createNodeDto)
    {
        _treeStructureService.CreateNode(createNodeDto);
        return Ok();
    }

    [HttpPut("update")]
    public ActionResult EditNode([FromBody] EditNodeDto editNodeDto)
    {
        _treeStructureService.EditNode(editNodeDto);
        return Ok();
    }
    
    [HttpPut("move")]
    public ActionResult MoveNode([FromBody] MoveNodeDto moveNodeDto)
    {
        _treeStructureService.MoveNode(moveNodeDto);
        return Ok();
    }
    
    [HttpPost("reorderNodes")]
    public ActionResult ReorderingNodes([FromBody] ReorderNodeDto reorderNodeDto)
    {
        _treeStructureService.ReorderNodes(reorderNodeDto);
        return Ok();
    }
    
    [HttpGet]
    public ActionResult<IEnumerable<ReadNodeTreeDto>> GetNodeTree([FromQuery] SortTypeEnum sortedBy)
    {
        var result = _treeStructureService.GetNodeTree(sortedBy);
        return Ok(result);
    }    
    
    [HttpGet("{nodeId}")]
    public ActionResult<IEnumerable<ReadNodeTreeDto>> GetNodeTree([FromRoute] int nodeId)
    {
        var result = _treeStructureService.GetNodeTree(nodeId);
        return Ok(result);
    }
    
    [HttpDelete("{nodeId}")]
    public ActionResult DeleteNode([FromRoute] int nodeId)
    {
        _treeStructureService.DeleteNode(nodeId);
        return Ok();
    }
}