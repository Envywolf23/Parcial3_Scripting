using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetIsNear : Selector {

    [SerializeField]
    private float areaDamage = 8F;

    public Vector3 targetPosition;

    GameObject Player;

    protected override bool CheckCondition()
    {
        Player = GameObject.FindGameObjectWithTag("Player");

        targetPosition = Player.GetComponent<Transform>().position;

        if ((Player.transform.position - transform.position).magnitude <= areaDamage)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
