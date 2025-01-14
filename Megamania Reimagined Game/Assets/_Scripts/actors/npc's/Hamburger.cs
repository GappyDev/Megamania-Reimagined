﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : NPC
{
    [Header("Shoot data")]
    public bool canShoot;

    protected override void OnDeath()
    {

        Debug.Log("enemy explode");
        Destroy(gameObject);

    }

    protected override void shoot()
    {

        if (canShoot)
        {
            realTime = Time.time;
  
            if (realTime >= nextFire)
            {
                Debug.Log("Shot Enemy");
                nextFire = realTime + fireRate;
            }
        }

    }

    protected override void Start()
    {

        movement = new MoveRight();
        base.Start();

    }

    protected override void resetPosition()=> body.position = initialPosition;

    public override void Stop()
    {
        movement = new Idle();
        resetPosition();
    }

    public override void Resume()
    {
        movement = savedMovement;
    }
}
