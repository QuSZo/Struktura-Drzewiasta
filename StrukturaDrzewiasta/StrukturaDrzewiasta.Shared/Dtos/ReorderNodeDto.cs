using StrukturaDrzewiasta.Shared.Enums;

namespace StrukturaDrzewiasta.Shared.Dtos;

public class ReorderNodeDto
{
    public int NodeId { get; set; }
    public OrderDirectionEnum OrderDirectionEnum { get; set; }
}