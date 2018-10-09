using UnityEngine;
using UnityEngine.AI;


public abstract class Node : MonoBehaviour
{
    protected AIController IA;
    protected NavMeshAgent agent;
    protected AIController ControlledAI { get; set; }

    public abstract bool Execute();

    protected void Start()
    {
        IA = GetComponent<AIController>();
        agent = GetComponent<NavMeshAgent>();
    }

    public virtual void SetControlledAI(AIController newControlledAI)
    {
        ControlledAI = newControlledAI;
    }
}