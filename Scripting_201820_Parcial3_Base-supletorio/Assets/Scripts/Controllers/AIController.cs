using UnityEngine;
using UnityEngine.AI;

public class AIController : ActorController
{
    [SerializeField]
    private float moveRadius = 50F;

    [SerializeField]
    private Root btRootNode;

    [SerializeField]
    private bool repeatInvoke = true;

    [SerializeField]
    private float rootInvokeTime = 1F;

    public void MoveAI()
    {
        MoveActor();
    }

    protected override void Start()
    {
        base.Start();

        if (btRootNode != null)
        {
            btRootNode.SetControlledAI(this);
        }

        AIMoveTest.Instance.onAIMoveIssued += MoveAI;

        if (btRootNode != null)
        {
            if (repeatInvoke)
            {
                InvokeRepeating("ExecuteBtRoot", 0.5F, rootInvokeTime);
            }
        }
    }

    protected override void OnDestroy()
    {
        AIMoveTest.Instance.onAIMoveIssued -= MoveAI;
        base.OnDestroy();
    }

    protected override Vector3 GetTargetLocation()
    {
        Vector3 result = transform.position;

        Vector3 randomDirection = Random.insideUnitSphere * moveRadius;
        randomDirection += transform.position;

        NavMeshHit hit;

        if (NavMesh.SamplePosition(randomDirection, out hit, moveRadius, 1))
        {
            result = hit.position;
        }

        return result;
    }

    private void ExecuteBtRoot()
    {
        btRootNode.Execute();
    }
}