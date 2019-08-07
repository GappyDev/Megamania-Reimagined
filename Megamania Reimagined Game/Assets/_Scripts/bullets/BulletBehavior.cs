using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [Header("Bullet's data")]
    public BulletData data;

    private Movement movement;

    private void initializeDataData()
    {
        movement = new Bullet(data.direction,data.speed);
    }

    private void Awake() => initializeDataData();

    private void Start()
    {
        movement.move(gameObject);
        Destroy(gameObject, data.lifeTime);
    }

}
