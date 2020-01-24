using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;
using UnityEngine;

public class GameController : MonoBehaviour
{

    private Ship[] inGameShips;
    private bool isPaused = false;

    [SerializeField]
    private GameObject[] gameHUD;
    [SerializeField]
    private GameObject[] pauseUI;

    [Header("Game Version")]
    public Version version = Version.Web;
    public KeyCode pauseKey; 
    public GameObject firstSelectedButton; //button to be selected first while the game is puased;

    //private event handler
    private EventSystem es;

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
            es.SetSelectedGameObject(null);
            foreach (GameObject obj in pauseUI) obj.SetActive(false);//deactivate pause menu
            foreach (GameObject obj in gameHUD) obj.SetActive(true); //activate digital controls

            Time.timeScale = 1;
            isPaused = false;
        }
        else
        {
            es.SetSelectedGameObject(firstSelectedButton); //set the first selected object to the first button of the pause menu
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

    //Built in Methods
    private void Start()=> es=  EventSystem.current;

    private void Update()
    {

        if(version == Version.Web)
        {

            if(Input.GetKeyDown("joystick button 7") || Input.GetKeyDown(pauseKey))
            {

                 PauseGame();
            }

        }else return;

    }
}
