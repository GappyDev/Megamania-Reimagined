using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="My Assets/New Health Bar data")]
public class HealthBarData : ScriptableObject
{
    [Header("gradients")]
    public Gradient gradient1;
    public Gradient gradient2;

    [Header("health data")]
    public float health = 100f;
    public float consumeSpeed = 1;
    public float consumeToScoreSpeed = 1;
    public float recoverSpeed = 1;

    [Header("Delay data")] //sets a delay on the call of the refill method 
    public float delay;

}
