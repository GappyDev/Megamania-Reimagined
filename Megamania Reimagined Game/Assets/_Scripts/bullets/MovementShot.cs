using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementShot : BulletBehavior
{
    private Rigidbody playerBody;

    protected override void initializeData()
    {
        playerBody = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        body = GetComponent<Rigidbody>();

    }

    protected override void moveBullet()
    {

        float MovY = body.position.y + (Time.deltaTime * data.speed);
        body.position = new Vector3(playerBody.position.x, MovY, body.position.z);
        Destroy(gameObject, data.lifeTime);

    }

    private void FixedUpdate() => moveBullet();

}
