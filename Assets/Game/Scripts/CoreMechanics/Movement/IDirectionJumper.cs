using UnityEngine.AI;

public interface IDirectionJumper
{
    bool InJumpProcess{get;}
    public bool IsOnNavMeshLink(out OffMeshLinkData offMeshLinkData);
    public void Jump(OffMeshLinkData offMeshLinkData);
}
