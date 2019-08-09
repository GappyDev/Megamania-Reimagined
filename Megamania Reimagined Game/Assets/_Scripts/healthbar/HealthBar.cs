using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public enum Status { playing,stop,addScore,gameOver}

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Status status;
   
    [Header("health data")]
    public float health = 100f;
    public float consumeSpeed = 1;
    public float consumeToScoreSpeed = 1;
    public float recoverSpeed = 1;

    [Header("UI elements")]
    public Image fuel;
    public Image tanks;

    [Header("Delay data")] //sets a delay on every call of the method
    public float delay;

    public static int lives = 3; //amount of lives the player has before triggering game over
    private float fuelAspectRatio,tanksAspectRatio,currentHealth,livesAmount,delayIni;

    private void InitializeData()
    {
        currentHealth = health;
        livesAmount = lives;
        status = Status.playing;
        delayIni = delay;

    }

    private void Start() => InitializeData();

    private void UpdateUI()
    {
        //get ratios
        fuelAspectRatio = currentHealth / health;
        tanksAspectRatio = lives / livesAmount;
        //update ui elements below
        fuel.fillAmount = fuelAspectRatio;
        tanks.fillAmount = tanksAspectRatio;
    }

    private void Refill()
    {
        UpdateUI(); //update bar
        //add health over time
        currentHealth += Time.deltaTime * recoverSpeed;

    }

    private void Consume()
    {

        UpdateUI(); //update bar
        //consume health over time
        currentHealth -= Time.deltaTime * consumeSpeed;

    }

    private void ConsumeToScore()
    {
        UpdateUI(); //updateBar
        currentHealth -= Time.deltaTime * consumeToScoreSpeed;

    }

    private void checkGameOver()
    {
        if (lives < 0) status = Status.gameOver;
    }

    private void OnGameplay()
    {

        //reset delay effect 
        delay = delayIni;

        if (currentHealth <= health && currentHealth > 0) Consume();
        else if (currentHealth <= 0) { lives--; status = Status.stop; } 
        //else if(currentHealth >= health) 

    }

    private void OnStop()
    {
        //trigger event on ship

        if (currentHealth <= health) Refill();
        else
        {
            currentHealth = health ; //force the value to be equal to the max health amount
            status = Status.playing;
        }
        
    }

    private void FixedUpdate()
    {
        checkGameOver();
        Debug.Log(lives);
        switch (status)
        {
            case Status.playing:
                OnGameplay();
                break;
            case Status.stop:
                if (delay <= 0) OnStop();
                else delay -= Time.deltaTime;
                break;
            case Status.addScore:
                ConsumeToScore();
                break;
            case Status.gameOver:
                break;
        }

    }
}
