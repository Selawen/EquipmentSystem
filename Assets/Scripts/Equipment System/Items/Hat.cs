using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : Equippable
{
    /// <summary>
    /// put hat on head
    /// </summary>
    public override void Action()
    {
        equipManager.OnHead(this);
        transform.localPosition = new Vector3(0, 1, 0);
    }
}
