using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StickyShot : BulletBehavior
{
    Rigidbody player;

    protected override void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
        base.Awake();
    }

    protected override void initializeData() => movement = new Sticky(player);
   
}
