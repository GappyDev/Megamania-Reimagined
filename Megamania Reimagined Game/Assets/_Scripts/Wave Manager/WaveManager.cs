using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
   [SerializeField]
    private GameObject[] waves; //filled manually
    int index = -1;

    public void InstantiateWave()
    {
        index++;
        if (index >= waves.Length) index = 0; //reset index
        GameObject currentWave =Instantiate(waves[index], Vector3.zero, Quaternion.identity);
        currentWave.transform.SetParent(transform);

    }

    private void CheckEnd()
    {

        if(transform.childCount > 0)
        {
            if(transform.GetChild(0).childCount == 0)
            {
                Destroy(transform.GetChild(0).gameObject);
                FindObjectOfType<HealthBar>().setStatus(Status.addScore);
            }
        }

    }

    private void Update() => CheckEnd(); //check end of wave every frame

}
