using StrukturaDrzewiasta.Shared;

namespace StrukturaDrzewiasta.Frontend.Shared;

public class NodeAction
{
    public ReadNodeTreeDto Node { get; set; }
    public NodeActionEnum Action { get; set; }
}

public enum NodeActionEnum {
    Create,
    Edit,
    Delete,
    MoveSource,
    MoveDestination
}