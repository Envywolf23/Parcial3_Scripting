using UnityEngine;

[RequireComponent(typeof(Collider))]
[RequireComponent(typeof(Rigidbody))]
public class Bullet : MonoBehaviour
{
    [SerializeField]
    private float damagePts = 1F;

    [SerializeField]
    private float destroyTime = 3F;

    [SerializeField]
    private float launchForce = 100F;

    private void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * launchForce, ForceMode.Impulse);
        Invoke("DestroyBullet", destroyTime);
    }

    private void DestroyBullet()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        ActorController actor = other.GetComponent<ActorController>();

        if (actor != null)
        {
            actor.onDamageTaken(damagePts);
        }
    }
}