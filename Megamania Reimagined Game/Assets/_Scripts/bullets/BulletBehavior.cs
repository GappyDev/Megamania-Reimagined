using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletBehavior : MonoBehaviour
{

    [Header("Bullet Data")]
    public BulletData data;

    //abstract methods
    protected abstract void initializeData();
    protected abstract void moveBullet();

    private void Awake() => initializeData();
}
