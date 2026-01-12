using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshAgentJumper
{
    private float _speed;
    private AnimationCurve _yOffsetCurve;
    private NavMeshAgent _agent;
    private MonoBehaviour _coroutineRunner;
    private Coroutine _jumpProcess;

    public NavMeshAgentJumper(float speed, NavMeshAgent agent, AnimationCurve yOffsetCurve, MonoBehaviour coroutineRunner)
    {
        _speed = speed;
        _agent = agent;
        _yOffsetCurve = yOffsetCurve;
        _coroutineRunner = coroutineRunner;
    }
    
    public bool InProcess => _jumpProcess != null;

    public void Jump(OffMeshLinkData offMeshLinkData)
    {
        if(InProcess)
            return;

        _jumpProcess = _coroutineRunner.StartCoroutine(ProcessJump(offMeshLinkData));
    }

    private IEnumerator ProcessJump(OffMeshLinkData offMeshLinkData)
    {
        Vector3 startPosition = offMeshLinkData.startPos;
        Vector3 endPosition = offMeshLinkData.endPos;
        float progress = 0;
        float duration = Vector3.Distance(startPosition, endPosition) / _speed;

        while(progress < duration)
        {
            float yOffset = _yOffsetCurve.Evaluate(progress / duration);

            progress += Time.deltaTime;
            _agent.transform.position = Vector3.Lerp(startPosition, endPosition, progress / duration) + Vector3.up * yOffset;
            yield return null;
        }

        _agent.CompleteOffMeshLink();
        _jumpProcess = null;
    }
}
