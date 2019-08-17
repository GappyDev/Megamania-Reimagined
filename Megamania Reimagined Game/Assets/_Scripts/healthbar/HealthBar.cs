using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine;

public enum Status { playing,stop,addScore,gameOver,LoadWave}

public class HealthBar : MonoBehaviour
{
    [SerializeField]
    private Status status;

    [Header("health data")]
    public HealthBarData data;

    [Header("UI elements")]
    public Image fuel;
    public Image tanks;

    [Header("Stop and resume event")]
    public UnityEvent OnStopEvent;
    public UnityEvent OnResumeEvent;
    public UnityEvent OnNextWaveEvent;

    public static int lives = 3; //amount of lives the player has before triggering game over
    private float fuelAspectRatio,tanksAspectRatio,currentHealth,maxLivesAmount,delayIni;

    private void InitializeData()
    {
        currentHealth = data.health;
        maxLivesAmount = lives;
        status = Status.playing;
        delayIni = data.delay;
    }

    private void Start()
    {
        InitializeData();
        OnNextWaveEvent.Invoke(); //instiantiate first wave
    }

    private void UpdateUI()
    {
        //get ratios
        fuelAspectRatio = currentHealth / data.health;
        tanksAspectRatio = lives / maxLivesAmount;
        //update ui elements below
        fuel.fillAmount = fuelAspectRatio;
        tanks.fillAmount = tanksAspectRatio;
        //update UI colors to the gradients
        fuel.color = data.gradient1.Evaluate(fuelAspectRatio);
        tanks.color = data.gradient2.Evaluate(tanksAspectRatio);
       
    }

    private void Refill()
    {
        //add health over time
        currentHealth += Time.deltaTime * data.recoverSpeed;

    }

    private void Consume()
    {

        //consume health over time
        currentHealth -= Time.deltaTime * data.consumeSpeed;

    }

    private void ConsumeToScore()
    {
        currentHealth -= Time.deltaTime * data.consumeToScoreSpeed;
        //add score

    }

    private void checkGameOver()
    {
        if (lives < 0) status = Status.gameOver;
    }

    public void Hurt() => currentHealth = 0; //it is called when the player collides with an Enemy or Bullet

    private void OnGameplay()
    {

        //reset delay effect 
        data.delay = delayIni;

        if (currentHealth <= data.health && currentHealth > 0) Consume();
        else if (currentHealth <= 0)
        {
            lives--;
            OnStopEvent.Invoke(); //triggers the stop event on all ships when the current health reaches 0
            status = Status.stop;
        } 

    }

    private void OnStop()
    {
        if (currentHealth <= data.health) Refill();
        else
        {
            currentHealth = data.health ; //force the value to be equal to the max health amount
            OnResumeEvent.Invoke(); //trigger resume event on ships
            status = Status.playing;
        }
        
    }

    private void OnScore()
    {
        OnStopEvent.Invoke(); //stop ship
        if (currentHealth > 0) ConsumeToScore(); //consume fuel to score
        else status = Status.LoadWave;
    }

    private void OnLoadWave()
    {
        if (currentHealth < data.health) Refill();
        else
        {
            //currentHealth = data.health;
            OnNextWaveEvent.Invoke();
            OnResumeEvent.Invoke();
            status = Status.playing;

        }

    }

    public void setStatus(Status s) => status = s;

    private void FixedUpdate()
    {
        checkGameOver();//check gameOver status

        UpdateUI(); //update bars
        switch (status)
        {
            case Status.playing:
                OnGameplay();
                break;
            case Status.stop:
                if (data.delay <= 0) OnStop();
                else data.delay -= Time.deltaTime;
                break;
            case Status.addScore:
                OnScore();
                break;
            case Status.LoadWave:
                OnLoadWave();
                break;
            case Status.gameOver:
                break;
        }

    }
}
