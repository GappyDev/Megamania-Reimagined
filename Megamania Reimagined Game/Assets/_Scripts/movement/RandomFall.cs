using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomFall : Movement
{
    public override void move(GameObject body)
    {
        Rigidbody rb = body.GetComponent<Rigidbody>();
        float Ypos = rb.position.y + (Time.deltaTime * -Speed);
        Vector3 moveDown = new Vector3(rb.position.x,Ypos,rb.position.z);
        rb.position = moveDown;
    }
}
