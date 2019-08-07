using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : BulletMovement
{
    Direction direction;

    public Bullet(Direction dir, float speed)
    {

        direction = dir;
        movementSpeed = speed;

    }
    public override void move(GameObject body)
    {

        Rigidbody rb = body.GetComponent<Rigidbody>();
        float posY = 0;
        switch (direction)
        {
            case Direction.down:
                posY = Time.deltaTime * -movementSpeed;
                break;
            case Direction.up:
                posY = Time.deltaTime * movementSpeed;
                break;
        }
        
        rb.AddForce(Vector3.up * posY, ForceMode.Impulse);

    }
}
