using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBehavior : MonoBehaviour
{
    [Header("Bullet's data")]
    public BulletData data;

    protected BulletMovement movement;

    protected abstract void initializeData();

    private void executeBehaviour()
    {

        movement.move(gameObject);
        Destroy(gameObject, data.lifeTime);

    }
 

    private void Awake() => initializeData();

    private void Start() => executeBehaviour();
   

}
