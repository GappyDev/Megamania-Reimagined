using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instantiator : MonoBehaviour
{
    public GameObject[] prefabs;
   

    public void SpecificInstance(int index)
    {
        Instantiate(prefabs[index], transform.position, Quaternion.identity);
    }

    public void RandomInstance()
    {
        int _index = Random.Range(0, prefabs.Length);
        Instantiate(prefabs[_index], transform.position, Quaternion.identity);
    }

}
