using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sticky : BulletMovement
{
    private Rigidbody playerRb;

    public Sticky(Rigidbody playerRef) => playerRb = playerRef;

    public override void move(GameObject body)
    {
        Rigidbody rb = body.GetComponent<Rigidbody>();
        rb.position = new Vector3(playerRb.position.x, rb.position.y +Time.deltaTime * movementSpeed, rb.position.z); //sticks the shot to the position of the player

    }
}
