namespace StrukturaDrzewiasta.Shared.Dtos;

public class ReadNodeTreeDto
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int? ParentNodeId { get; set; }
    public int CustomSortId { get; set; }

    public List<ReadNodeTreeDto>? Nodes { get; set; }
}