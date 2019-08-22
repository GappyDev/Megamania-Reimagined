using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sine : Movement
{

    private float amplitude = 2, frequency = 2;

    public override void move(GameObject body)
    {
        Rigidbody rb = body.GetComponent<Rigidbody>();
        float posX = rb.position.x + (Time.deltaTime*Speed); //linear on x
        float posY = rb.position.y + Mathf.Sin(Time.time * frequency) * amplitude * Time.deltaTime;
        rb.position = new Vector3(posX, posY, rb.position.z);
    }
}
