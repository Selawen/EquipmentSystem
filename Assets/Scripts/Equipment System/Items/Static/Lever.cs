using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lever : Interactable
{
    bool up = false;
    public override void Action()
    {
        if (up)
        {
            transform.RotateAround(transform.position - transform.up*0.5f, transform.right, 90);
            up = false;
        }
        else
        {

            transform.RotateAround(transform.position - transform.up*0.5f, transform.right, -90);
            up = true;
        }
    }
}
