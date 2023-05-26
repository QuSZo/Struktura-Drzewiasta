using StrukturaDrzewiasta.Shared.Dtos;

namespace StrukturaDrzewiasta.Frontend.Shared;

public class NodeAction
{
    public ReadNodeTreeDto Node { get; set; }
    public NodeActionEnum Action { get; set; }
}

public class ToClose
{
    public bool IsChildrenNodesClosed { get; set; }
    public int SignalTTL { get; set; }
}

public enum NodeActionEnum {
    Create,
    Edit,
    Delete,
    MoveSource,
    MoveDestination,
    ReorderUp,
    ReorderDown
}