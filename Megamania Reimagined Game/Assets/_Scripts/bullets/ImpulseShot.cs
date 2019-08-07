using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction { Up, Down };

public class ImpulseShot : BulletBehavior
{
    [Header("Force magnitude")]
    public float magnitude;

    [Header("Direction")]
    public Direction direction;

    protected override void initializeData()
    {
        body = GetComponent<Rigidbody>();

    }

    protected override void moveBullet()
    {
        //by impulse force
        switch (direction)
        {

            case Direction.Up:
                body.AddForce(Vector3.up * Time.deltaTime * data.speed * magnitude, ForceMode.Impulse); // player shot
                break;
            case Direction.Down:
                body.AddForce(Vector3.down * Time.deltaTime * data.speed * magnitude, ForceMode.Impulse); //enemy shot
                break;

        }

        Destroy(gameObject, data.lifeTime);
    }

    private void Start() => moveBullet();

}