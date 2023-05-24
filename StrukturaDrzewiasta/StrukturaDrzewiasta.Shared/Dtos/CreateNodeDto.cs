using System.ComponentModel.DataAnnotations;

namespace StrukturaDrzewiasta.Shared.Dtos;

public class CreateNodeDto
{
    public string? Name { get; set; }
    [Required] 
    public int? ParentNodeId { get; set; }
}