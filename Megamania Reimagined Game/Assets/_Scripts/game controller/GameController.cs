using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Ship[] inGameShips;
    private bool isPaused = false;

    [SerializeField]
    private GameObject[] gameHUD;
    [SerializeField]
    private GameObject[] pauseUI;

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

    //button methods
    public void PauseGame()
    {
        if (isPaused)
        {
            foreach (GameObject obj in pauseUI) obj.SetActive(false);//deactivate pause menu
            foreach (GameObject obj in gameHUD) obj.SetActive(true); //activate digital controls

            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            Time.timeScale = 0;
            isPaused = true;

            foreach (GameObject obj in gameHUD) obj.SetActive(false); //deactivate digital Controls
            foreach (GameObject obj in pauseUI) obj.SetActive(true);//activate pause menu
        }

    }

    //methods to be triggered on an event on Health bar object
    public void Stop() => delegateStop();

    public void Resume() => delegateResume();

    public void NextWave()=> FindObjectOfType<WaveManager>().InstantiateWave();
}
