using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExit : Door
{
    Vector2 dimensions;
    private void Start() => dimensions = Observer.getScreenDimensions()/2;
    protected override void MoveToExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Rigidbody body = other.GetComponent<Rigidbody>();
            body.position = new Vector3(Random.Range(-dimensions.x, dimensions.x), exit.position.y, body.position.z);
        }
    }

    
}
