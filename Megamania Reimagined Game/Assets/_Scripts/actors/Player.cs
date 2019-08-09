using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class Player : Ship
{

    #region ATTRIBUTES

    [Header("Movement Input")]
    public Joystick joystick;

    [Header("Shooting Input")]
    public KeyCode DebugKey; 
    public ImageTouchableButton shootButton;
    public Transform cannon;

    [Header("Health Bar Event")]
    public UnityEvent hurt;

    private bool canShoot = true;
    #endregion

    protected override void OnDeath()
    {
        Debug.Log("explode");
    }

    protected override void shoot()
    {
        if (canShoot)
        {
            realTime = Time.time;

            if ((Input.GetKey(DebugKey) || shootButton.pressed) && realTime >= nextFire)
            {
                Instantiate(data.bulletPrefab, cannon.position, Quaternion.identity);
                nextFire = realTime + fireRate;
            }
        }

    }

    protected override void Stop()
    {
        movement = new Idle();
        canShoot = false;
    }

    protected override void Resume()
    {
        movement = savedMovement;
        canShoot = true;

    }

    // Start is called before the first frame update
    protected override void Start()
    {

        movement = new Play(joystick);
        savedMovement = movement;
        base.Start();

    }

  
    private void Onhurt(GameObject other)
    {

        if (other.CompareTag("Enemy") || other.CompareTag("Bullet")) hurt.Invoke();

    }

    private void OnTriggerEnter(Collider other)
    {

        Onhurt(other.gameObject);
        Destroy(other.gameObject);

    }

}
