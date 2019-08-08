using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName =("My Assets/New Bullet Data"))]
public class BulletData : ScriptableObject
{
    [Header("Life time")]
    [Range(0,1)]
    public float lifeTime = 0.1f;

    [Header("movement data")]
    public float speed = 200f;
}
