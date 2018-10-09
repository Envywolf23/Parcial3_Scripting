using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(Collider))]
public abstract class ActorController : MonoBehaviour
{
    protected NavMeshAgent agent;

    [SerializeField]
    private Bullet bulletGO;

    [SerializeField]
    private float healthPoints = 100F;

    [SerializeField]
    private float spawnOffset = 1.5F;

    public delegate void OnDamageTaken(float damagePts);

    public OnDamageTaken onDamageTaken;

    public float CurrentHP { get; protected set; }

    // Use this for initialization
    protected virtual void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        CurrentHP = healthPoints;

        onDamageTaken += ApplyDamage;
    }

    private void ApplyDamage(float damagePts)
    {
        CurrentHP -= damagePts;

        if (CurrentHP <= 0F)
        {
        }
    }

    protected abstract Vector3 GetTargetLocation();

    protected void Shoot()
    {
        if (bulletGO != null)
        {
            Instantiate<Bullet>(bulletGO, transform.position + new Vector3(0F, 0F, spawnOffset), transform.rotation);
        }
    }

    protected void MoveActor()
    {
        agent.SetDestination(GetTargetLocation());
    }

    protected virtual void OnDestroy()
    {
        agent = null;
    }
}