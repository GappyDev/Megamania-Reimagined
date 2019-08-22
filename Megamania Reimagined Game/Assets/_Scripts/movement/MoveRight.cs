using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveRight : Movement
{
    public override void move(GameObject body)
    {
        Rigidbody rb = body.GetComponent<Rigidbody>();
        rb.position = new Vector3(rb.position.x + Time.deltaTime * Speed, rb.position.y, rb.position.z);
    }
}
