using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Scrpitable/GunData", fileName = "GunData", order =1)]
public class GunData : ScriptableObject
{
    public AudioClip shotClip;
    public AudioClip reloadClip;
    public float fireRate = 0.12f;
    public float reloadTime = 1.8f;
}
