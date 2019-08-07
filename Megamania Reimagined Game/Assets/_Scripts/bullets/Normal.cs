using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Normal : BulletBehavior
{
    protected override void initializeData()=> movement = new Bullet(data.direction, data.speed);

}
