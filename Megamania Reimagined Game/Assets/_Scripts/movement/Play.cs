using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : Movement
{
    public override void move(GameObject body)
    {

        #region DEBUG MOVEMENT

        Rigidbody rb = body.GetComponent<Rigidbody>();
        float posX = rb.position.x + (Input.GetAxis("Horizontal") * Time.deltaTime * Speed) ;

        rb.position = new Vector3(Mathf.Clamp(posX,-8,8),rb.position.y,rb.position.z);

        #endregion

    }

}
