/// <summary>
/// Task that instructs ControlledAI to follow its designated 'target'
/// </summary>
public class FollowTarget : Task
{
    public override bool Execute()
    {
        agent.SetDestination(GetComponent<TargetIsNear>().targetPosition);
        return base.Execute();
    }
}