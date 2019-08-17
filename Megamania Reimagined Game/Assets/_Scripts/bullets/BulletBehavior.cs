using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBehavior : MonoBehaviour
{
    //public attributes
    [Header("Bullet Data")]
    public BulletData data;

    //private attributes
    protected Rigidbody body;

    //abstract methods
    protected abstract void initializeData();
    protected abstract void moveBullet();

    private void Awake() => initializeData();

}
