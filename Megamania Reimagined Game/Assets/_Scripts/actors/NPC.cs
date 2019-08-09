using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class NPC : Ship
{
    #region ATTRIBUTES
    protected int points;
    protected Vector3 initialPosition;
    protected Rigidbody body;
    #endregion

    #region METHODS
    protected abstract void resetPosition();

    protected override void initializeData(ShipData sd)
    {
        body = GetComponent<Rigidbody>();
        points = sd.points;
        base.initializeData(sd);
    }

    protected override void Start()
    {
        initialPosition = gameObject.GetComponent<Rigidbody>().position; //saves the initial position of the ship npc
        base.Start();
    }

    #endregion
}
