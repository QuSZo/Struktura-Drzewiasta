using System.ComponentModel.DataAnnotations;

namespace StrukturaDrzewiasta.Shared.Dtos;

public class MoveNodeDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public int ParentNodeId { get; set; }
}