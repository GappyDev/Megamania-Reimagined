using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomExit : Door
{
    Vector2 dimensions;
    private void Start() => dimensions = Observer.getScreenDimensions();
    protected override void MoveToExit(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            Rigidbody body = other.GetComponent<Rigidbody>();
            float randomizedValue = Mathf.Clamp(body.position.x, -dimensions.x, dimensions.x);

            body.position = new Vector3(randomizedValue, exit.position.y, body.position.z);
        }
    }

    
}
