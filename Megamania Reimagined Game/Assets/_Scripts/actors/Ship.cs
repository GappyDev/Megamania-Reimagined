using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Ship : MonoBehaviour
{

    #region ATTRIBUTES
    protected Movement movement,savedMovement;

    [Header("Ship's data")]
    public ShipData data;

    protected float realTime, nextFire,fireRate;
    #endregion

    #region METHODS
    protected abstract void OnDeath();
    protected abstract void shoot();

    protected abstract void Stop();

    protected abstract void Resume();


    protected virtual void initializeData(ShipData sd)
    {
        //movement data
        movement.Speed = sd.speed;

        //shoot data
        fireRate = sd.fireRate;
    }

    protected virtual void Start() => initializeData(data);

    private void FixedUpdate()
    {
        shoot();
        movement.move(gameObject);
    }
    #endregion
}
