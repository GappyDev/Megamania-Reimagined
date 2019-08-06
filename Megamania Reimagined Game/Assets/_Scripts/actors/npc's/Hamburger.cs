using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hamburger : NPC
{
    [Header("Shoot data")]
    public bool canShoot;

    protected override void OnDeath()
    {

        Debug.Log("enemy explode");

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

        movement = new Linear();
        base.Start();

    }

    protected override void resetPosition()
    {

    }
}
