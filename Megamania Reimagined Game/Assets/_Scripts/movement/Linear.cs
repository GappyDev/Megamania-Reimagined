using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Linear : Movement
{
    public override void move(GameObject body)
    {
        Rigidbody rb = body.GetComponent<Rigidbody>();
        Vector3 movement = new Vector3(rb.position.x  + (Time.deltaTime * Speed),rb.position.y,rb.position.z);
        rb.MovePosition(movement);
    }

}
