using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName ="My Assets/New Ship Data")]
public class ShipData : ScriptableObject
{
    [Header("Movement data")]
    [Range(1,15)]
    public float speed = 1f;

    [Header("Shoot data")]
    public float fireRate = 1f;
    public GameObject bulletPrefab = null;

    [Header("Audio data")]
    public AudioClip shotClip;
    public AudioClip explosionClip;

    [Header("Particles data")]
    public GameObject explosionPrefab;

    [Header("Points per Enemy")]
    public int points = 0;



}
