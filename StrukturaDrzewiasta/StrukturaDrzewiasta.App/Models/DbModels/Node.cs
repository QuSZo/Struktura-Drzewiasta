namespace StrukturaDrzewiasta.App.Models.DbModels;

public class Node
{
    public int Id { get; set; }
    public string Name { get; set; }
    public ICollection<Node> Nodes { get; set; }
}