using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class Play : Movement
{
    private Joystick virtualJoystick;
    private Vector2 screenDinWorldUnits;
    private float min, max,offset = 0.75f;

    public Play(Joystick joystick)
    {

        virtualJoystick = joystick;
        screenDinWorldUnits = Observer.getScreenDimensions() / 2;
        max = screenDinWorldUnits.x - offset;
        min = -screenDinWorldUnits.x + offset;
        //screenDinWorldUnits.x = 8.3333, screenDinWorldUnits.y = 5
    }

    public override void move(GameObject body)
    {

        Rigidbody rb = body.GetComponent<Rigidbody>();
        float posX = rb.position.x + (virtualJoystick.Horizontal * Time.deltaTime * Speed);

        rb.position = new Vector3(Mathf.Clamp(posX, min, max), rb.position.y, rb.position.z);

    }

}
