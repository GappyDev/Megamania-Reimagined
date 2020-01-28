using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public enum Version{Mobile, Web}

public class Player : Ship
{

    #region VERSION
    [Header("Version")]
    public Version version = Version.Web;
    public string joystickShotButton = "joystick button 0"; //button A on the xbox controller
    
    #endregion

    #region ATTRIBUTES

    [Header("Movement Input (Mobile)")]
    public Joystick joystick;

    [Header("Shooting Input")]
    public KeyCode DebugKey; 
    public ImageTouchableButton shootButton;
    public Transform cannon;

    [Header("Health Bar Event")]
    public UnityEvent hurt;

    private bool canShoot = true;

    #region Dimensions & dash mechanic
    private Vector2 ScreenDimensions;
    private float min, max;
    private bool dashing = false;
    private Rigidbody rb;

    [Header("Dash Effect particles")]
    public GameObject particlePrefab;
    #endregion
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
        ScreenDimensions = Observer.getScreenDimensions()/2;
        min = -ScreenDimensions.x;
        max = ScreenDimensions.x;
        rb = GetComponent<Rigidbody>();
        base.Start();

    }

    //implementation of dash mechanic (have to limit the use of the dash mechanic for tank refill or end of wave)
    protected override void FixedUpdate() 
    {
        if((Input.GetAxis("Horizontal")>0) && (Input.GetKeyDown("joystick button 5")) && (rb.position.x < max-2) && !dashing)
            StartCoroutine(Dash(0.5f,1));
        else if((Input.GetAxis("Horizontal")<0) && (Input.GetKeyDown("joystick button 4")) && (rb.position.x > min +2) && !dashing)
            StartCoroutine(Dash(0.5f,-1));

        if(dashing && ((rb.position.x > max -1)||(rb.position.x < min +1)))
            {
                rb.velocity = Vector3.zero;
                dashing = false;   
            }
        base.FixedUpdate();
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


    //dash mechanic
    private IEnumerator Dash(float duration, float direction)
    {
        Rigidbody rb = GetComponent<Rigidbody>();
        rb.velocity = Vector3.zero;
        movement = new Idle();
        GameObject particleIns =Instantiate(particlePrefab,rb.position,Quaternion.identity);//instantiate particle effects
        Destroy(particleIns,2f);
        yield return new WaitForSeconds(2f); //wait till effect dissapears
        dashing = true;
        rb.velocity += new Vector3(direction,0f,0f).normalized * 30;
        yield return new WaitForSeconds(duration);
        movement = savedMovement;
        dashing = false;
        rb.velocity = Vector3.zero;

    }
}
