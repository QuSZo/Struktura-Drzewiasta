using System.ComponentModel.DataAnnotations.Schema;

namespace StrukturaDrzewiasta.App.Models.DbModels;

public class Node
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int ParentNodeId { get; set; }
    
    public Node ParentNode { get; set; }
    public ICollection<Node> Nodes { get; set; }
}