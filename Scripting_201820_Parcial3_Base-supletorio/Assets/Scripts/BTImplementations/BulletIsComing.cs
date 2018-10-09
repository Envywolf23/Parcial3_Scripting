using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletIsComing : Selector {

    [SerializeField]
    private float areaSafe = 10f;

    public GameObject balaPlayer;

    protected override bool CheckCondition()
    {
        if ((balaPlayer.transform.position - transform.position).magnitude <= areaSafe)
        {
            return true;
        }
        else
        {
            return false;
        }



    }

}
