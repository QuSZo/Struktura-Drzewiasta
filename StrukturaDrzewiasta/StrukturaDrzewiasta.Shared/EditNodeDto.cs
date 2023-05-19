using System.ComponentModel.DataAnnotations;

namespace StrukturaDrzewiasta.Shared;

public class EditNodeDto
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; }
}