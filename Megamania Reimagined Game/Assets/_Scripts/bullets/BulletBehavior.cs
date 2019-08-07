using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletBehavior : MonoBehaviour
{
    [Header("Bullet's data")]
    public BulletData data;

    private BulletMovement movement;

    private void initializeData()
    {
        movement = new Bullet(data.direction,data.speed);
    }

    private void Awake() => initializeData();

    private void Start()
    {
        movement.move(gameObject);
        Destroy(gameObject, data.lifeTime);
    }

}
