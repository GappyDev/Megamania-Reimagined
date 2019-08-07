using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BulletMovement 
{
    protected float movementSpeed;
    public abstract void move(GameObject body);
}
