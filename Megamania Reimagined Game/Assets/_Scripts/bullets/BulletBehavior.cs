using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { sticky,linear}
public abstract class BulletBehavior : MonoBehaviour
{
    [Header("Bullet's data")]
    public BulletData data;

    [Header("Bullet Type")]
    public Type type;

    protected BulletMovement movement;
    private bool executeOnUpdate = false;

    private void executeBehaviour()
    {

        movement.move(gameObject);
        Destroy(gameObject, data.lifeTime);

    }

    private void checkOnUpdateExecution()
    {

        if (executeOnUpdate) executeBehaviour();

    }

    private void Start()
    {

        switch (type)
        {

            case Type.linear:
                executeBehaviour();
                break;
            case Type.sticky:
                executeOnUpdate = true;
                break;
        }
    }

    private void FixedUpdate() => checkOnUpdateExecution();

    protected abstract void initializeData();

    private void Awake() => initializeData();


}
