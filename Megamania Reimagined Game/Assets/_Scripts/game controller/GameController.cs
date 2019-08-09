using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Ship[] inGameShips;

    private void getReference() => inGameShips = FindObjectsOfType<Ship>();

    private void delegateStop()
    {
        getReference();
        foreach (Ship ship in inGameShips) ship.Stop();
    }

    private void delegateResume()
    {
        getReference();
        foreach (Ship ship in inGameShips) ship.Resume();

    }


    //methods to be triggered on an event on Health bar object
    public void Stop() => delegateStop();

    public void Resume() => delegateResume();
}
