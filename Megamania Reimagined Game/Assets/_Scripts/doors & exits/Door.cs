using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Orientation {Horizontal, Vertical}

public class Door : MonoBehaviour
{

    [Header("Set orientation")]
    public Orientation orientation;

    [Header("set Exit")]
    public Transform exit;

    protected virtual void moveToPos(Collider other)
    {
        Rigidbody rb = other.GetComponent<Rigidbody>();
        Vector3 pos = new Vector3();

        if (other.CompareTag("normalEnemy"))
        {

            switch (orientation)
            {

                case Orientation.Horizontal:
                pos = new Vector3(exit.position.x, rb.position.y, rb.position.z);
                break;

                case Orientation.Vertical:
                pos = new Vector3(rb.position.x, exit.position.y, rb.position.z);
                break;

                default:
                break;
            }

            rb.position = pos;
        }
        else if (other.CompareTag("Dice") && orientation == Orientation.Vertical)
        {

            int randomPosX = Random.Range(-7, 7);
            rb.position = new Vector3(randomPosX, exit.position.y, rb.position.z);

        }

    }

    private void OnTriggerEnter(Collider other) => moveToPos(other);

}
