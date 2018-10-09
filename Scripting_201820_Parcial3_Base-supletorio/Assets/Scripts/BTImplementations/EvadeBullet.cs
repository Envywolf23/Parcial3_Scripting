using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvadeBullet : Task {

    public GameObject balaPlayer;

    public override bool Execute()
    {

        agent.SetDestination(new Vector3(balaPlayer.transform.position.x - transform.position.x, balaPlayer.transform.position.y - transform.position.y, balaPlayer.transform.position.z - transform.position.z));

        return base.Execute();
    }
}
