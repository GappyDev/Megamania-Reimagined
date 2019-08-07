using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Type { impulseByMovement,impulseByForce}
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

        if (executeOnUpdate)
        {

            movement.move(gameObject);
            Rigidbody rb = GetComponent<Rigidbody>();
            float MovY = rb.position.y + Time.deltaTime * data.speed;
            rb.position = new Vector3(rb.position.x, MovY, rb.position.z);
            Destroy(gameObject, data.lifeTime);
        }

    }

    private void Start()
    {

        switch (type)
        {

            case Type.impulseByForce:
                executeBehaviour();
                Debug.Log("force");
                break;
            case Type.impulseByMovement:
                executeOnUpdate = true;
                break;
        }
    }

    private void FixedUpdate() => checkOnUpdateExecution();

    protected abstract void initializeData();

    protected virtual void Awake() => initializeData();


}
