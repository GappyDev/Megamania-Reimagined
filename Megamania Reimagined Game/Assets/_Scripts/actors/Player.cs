using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public enum Version{Mobile, Web}

public class Player : Ship
{

    #region 
    [Header("Version")]
    public Version version = Version.Web;
    public string joystickShotButton = "joystick button 0"; //button A on the xbox controller
    
    #endregion

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

            if ((Input.GetKey(DebugKey) || shootButton.pressed || Input.GetKey(joystickShotButton)) && realTime >= nextFire)
            {
                Instantiate(data.bulletPrefab, cannon.position, Quaternion.identity);
                nextFire = realTime + fireRate;
            }
        }

    }

    public override void Stop()
    {
        movement = new Idle();
        canShoot = false;
    }

    public override void Resume()
    {
        movement = savedMovement;
        canShoot = true;

    }

    // Start is called before the first frame update
    protected override void Start()
    {

        switch (version)
        {
            case Version.Mobile:
            movement = new Play(joystick,gameObject);
            break;
            case Version.Web:
            movement = new PlayWeb(gameObject);
            break;
            default:
            break;
        }
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
