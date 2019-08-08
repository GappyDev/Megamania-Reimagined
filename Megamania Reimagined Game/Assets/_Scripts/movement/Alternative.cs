using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Alternative : Movement
{
    private Vector3 towardsLeft, towardsRight;
    
    public override void move(GameObject body)
    {

        Rigidbody rb = body.GetComponent<Rigidbody>();
        towardsLeft = new Vector3(rb.position.x + (Time.deltaTime * -Speed), rb.position.y, rb.position.z);
        towardsRight = new Vector3(rb.position.x + (Time.deltaTime * Speed), rb.position.y, rb.position.z);

        //use timer script to set the direction
        if (body.CompareTag("normalEnemy")) rb.position = towardsRight;
        else if (body.CompareTag("alternativeEnemy")) rb.position = towardsLeft;

    }
}
