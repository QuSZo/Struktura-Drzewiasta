using StrukturaDrzewiasta.Shared.Enums;

namespace StrukturaDrzewiasta.App.Models.DbModels;

public class Node
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentNodeId { get; set; }
    public int CustomSortId { get; set; }
    public Node? ParentNode { get; set; }
    public List<Node> Nodes { get; set; } = new List<Node>();

    public void RecursiveOrder(SortTypeEnum sortedBy = SortTypeEnum.CreatedDate)
    {
        switch(sortedBy)
        {
            case SortTypeEnum.Name:
                Nodes = Nodes.OrderBy(node => node.Name).ToList();
                break;
            case SortTypeEnum.Custom:
                Nodes = Nodes.OrderBy(node => node.CustomSortId).ToList();
                break;
            case SortTypeEnum.CreatedDate:
                Nodes = Nodes.OrderBy(node => node.Id).ToList();
                break;
        }
        Nodes.ForEach(node => node.RecursiveOrder(sortedBy));
    }
}