using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : Task {

    [SerializeField]
    private Bullet balaIA;

    [SerializeField]
    private float spawnOffset = 1.5F;

    public override bool Execute()
    {
        Instantiate<Bullet>(balaIA, transform.position + new Vector3(0F, 0F, spawnOffset), transform.rotation);

        return base.Execute();
    }

}
