using System.ComponentModel.DataAnnotations;

namespace StrukturaDrzewiasta.Shared;

public class EditNodeDto
{
    [Required]
    public int Id { get; set; }
    public string? Name { get; set; }
}