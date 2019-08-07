using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Player : Ship
{

    #region ATTRIBUTES

    [Header("Movement Input")]
    public Joystick joystick;

    [Header("Shooting Input")]
    public KeyCode DebugKey; //change this to touch controls
    public ImageTouchableButton shootButton;
    #endregion

    protected override void OnDeath()
    {
        Debug.Log("explode");
    }

    protected override void shoot()
    {
        realTime = Time.time;

        if ((Input.GetKey(DebugKey) || shootButton.pressed) && realTime >= nextFire)
        {
            Debug.Log("shot");
            nextFire =realTime + fireRate;
        }

    }

    // Start is called before the first frame update
    protected override void Start()
    {

        movement = new Play(joystick);
        base.Start();

    }

}
