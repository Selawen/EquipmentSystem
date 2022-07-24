using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hat : Equippable
{
    private void Start()
    {
        if (offset == new Vector3(0, 0, 0))
            offset = new Vector3(0.25f, 0, 0.5f);
    }

    /// <summary>
    /// put hat on head
    /// </summary>
    public override void Action()
    {
        transform.localPosition = new Vector3(0, 1, 0);
    }
}
