using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public abstract class Door : MonoBehaviour
{

    [Header("set Exit")]
    public Transform exit;

    protected abstract void MoveToExit(Collider other);

    private void OnTriggerEnter(Collider other) => MoveToExit(other);

}
