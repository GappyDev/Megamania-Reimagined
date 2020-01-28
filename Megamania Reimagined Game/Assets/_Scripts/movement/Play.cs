using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Play : Movement
{
    private Joystick virtualJoystick;
    private Vector2 screenDinWorldUnits;
    private float min, max,offset = 0.75f;
    private Animator anim;

    public Play(Joystick joystick,GameObject body)
    {

        virtualJoystick = joystick;
        screenDinWorldUnits = Observer.getScreenDimensions() / 2;
        max = screenDinWorldUnits.x - offset;
        min = -screenDinWorldUnits.x + offset;
        anim = body.GetComponent<Animator>();
        //screenDinWorldUnits.x = 8.3333, screenDinWorldUnits.y = 5
    }

    public override void move(GameObject body)
    {

        Rigidbody rb = body.GetComponent<Rigidbody>();
        float posX = rb.position.x + (virtualJoystick.Horizontal * Time.deltaTime * Speed);
        anim.SetFloat("Xvalue",Input.GetAxis("Horizontal"));
        rb.position = new Vector3(Mathf.Clamp(posX, min, max), rb.position.y, rb.position.z);

        //controller input
        if(Input.GetButtonDown("joystick button 5") || Input.GetButtonDown("joystick button 4"))
            Dash(posX,rb);

    }

    //dash mechanic
    private void Dash(float dirX, Rigidbody rb)
    {

        rb.velocity = Vector3.zero;
        rb.velocity += new Vector3(dirX,0f,0f).normalized * 30;

    }

}
