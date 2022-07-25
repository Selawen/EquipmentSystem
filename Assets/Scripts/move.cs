using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class move : MonoBehaviour
{
    private Vector3 moveVec;
    public float speed = 5f;

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Translate(moveVec*speed*Time.deltaTime);
    }

    /// <summary>
    /// updates moveVec when state of move action set up in new input system updates
    /// </summary>
    /// <param name="input">input registered by inputcontrols</param>
    public void OnMove(InputValue input)
    {
        Vector2 inputVec = input.Get<Vector2>();

        moveVec = new Vector3(inputVec.x, 0, inputVec.y);
    }
}
