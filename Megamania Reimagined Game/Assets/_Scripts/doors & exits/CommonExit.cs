using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation { Horizontal, Vertical }

public class CommonExit : Door
{
    [Header("Set Orientation")]
    public Orientation orientation;

    protected override void MoveToExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {

            Rigidbody body = other.GetComponent<Rigidbody>();
            switch (orientation)
            {
                case Orientation.Horizontal:
                    body.position = new Vector3(exit.position.x, body.position.y, body.position.z);
                    break;
                case Orientation.Vertical:
                    body.position = new Vector3(body.position.x, exit.position.y, body.position.z);
                    break;

            }

        }
    }
}
