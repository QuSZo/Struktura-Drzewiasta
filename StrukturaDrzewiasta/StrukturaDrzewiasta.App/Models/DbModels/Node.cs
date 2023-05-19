using System.ComponentModel.DataAnnotations.Schema;

namespace StrukturaDrzewiasta.App.Models.DbModels;

public class Node
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentNodeId { get; set; }
    
    public Node? ParentNode { get; set; }
    public List<Node> Nodes { get; set; } = new List<Node>();

    public void RecursiveOrder(string sortedBy = "id")
    {
        if (sortedBy == "name")
        {
            Nodes = Nodes.OrderBy(node => node.Name).ToList();
            Nodes.ToList().ForEach(node => node.RecursiveOrder(sortedBy));
        }
        else
        {
            Nodes = Nodes.OrderBy(node => node.Id).ToList();
            Nodes.ToList().ForEach(node => node.RecursiveOrder());
        }
    }
}