using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : Interactable
{
    bool open = false;
    public override void Action()
    {
        if (open)
        {
            transform.RotateAround(transform.position + transform.right, transform.up, -90);
            open = false;
        } else
        {

            transform.RotateAround(transform.position + transform.right, transform.up, 90);
            open = true;
        }

    }
}
