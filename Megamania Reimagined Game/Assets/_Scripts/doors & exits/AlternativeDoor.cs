using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlternativeDoor : Door
{
    protected override void moveToPos(Collider other)
    {

        if (other.CompareTag("alternativeEnemy"))
        {
            Rigidbody rb = other.GetComponent<Rigidbody>();
            rb.position = new Vector3(exit.position.x, rb.position.y, rb.position.z);
        }

    }
}
