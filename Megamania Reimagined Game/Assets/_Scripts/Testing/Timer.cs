using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Timer : MonoBehaviour
{
    public UnityEvent OnTimer; //methods to be executed

    Coroutine T; //reference to the timer Routine

    [SerializeField]
    private bool _loop = false; //wether the timer should repeat after execution

    [SerializeField]
    private bool _executeOnStart = false; // wether the methods should be executed on the very first frame

    [SerializeField]
    private bool __runOnAwake = false;//wether the timer should start inmedeatly

    [SerializeField]
    private float _intervalLength = 0f; // length of the intervals

    public bool lerpIntervals; // wether the intervals shoul lerp after execution

    [SerializeField]
    private float _targetInterval = 0f; // interval to lerp if lerpintervals is true

    [SerializeField]
    private float _lerpT = 0; // amount to lerpt the intervals by

    private float _timeLeft = 0f; // time left before execution

    public bool canExecute = true; // wether the methods can be executed when timeLeft <= 0

    [HideInInspector]
    public bool running = false; // tells if the timer is runnning


    private void Start()
    {
        if (_executeOnStart)
        {
            OnTimer.Invoke(); // executes the methods
        }

        _timeLeft = _intervalLength; 

        if (__runOnAwake)
        {
            T = StartCoroutine(TimerRoutine()); //starts the timer routine if runOnAwake is true
        }
    }

    public IEnumerator TimerRoutine()
    {
        running = true;
        do
        {
            _timeLeft -= Time.deltaTime; // reduces timeleft by the time it takes to render a frame

            if (_timeLeft <= 0 && canExecute) // checks if is time to execute the methods
            {
                OnTimer.Invoke();
                Debug.Log("executed at: " + Time.time);

                if (lerpIntervals) // checks if the intervals should be lerped
                {
                    _intervalLength = Mathf.Lerp(_intervalLength, _targetInterval, _lerpT * Time.deltaTime);
                }

                if (_loop) // checks if the timer is looping
                {
                    _timeLeft = _intervalLength;
                }

            }

            yield return null;

        } while (_loop); // repeats if the timer is looping


        running = false;
    }

    public void StopTimer() // stops the timer
    {
        if (running)
        {
            StopCoroutine(T);
            running = false;
        }
     
    }

    public void StartTimer() // resets the timer with the current value of intervalLenght
    {
        if (running)
        {
            StopCoroutine(T);
            running = false;
        }

        _timeLeft = _intervalLength;

        T = StartCoroutine(TimerRoutine());
    }

    public void StartTimer(float length) // resets the timer with a new value for intervalLength
    {
        if (running)
        {
            StopCoroutine(T);
            running = false;
        }

        _intervalLength = length;

        _timeLeft = _intervalLength;

        T = StartCoroutine(TimerRoutine());
    }

    public void ResumeTimer()//resumes timer without altering timeLeft;
    {
        if (running)
        {
            StopCoroutine(T);
            running = false;
        }

        T = StartCoroutine(TimerRoutine());
    }


    public float PercentageLeft()
    {
        return _timeLeft / _intervalLength;
    }

}
