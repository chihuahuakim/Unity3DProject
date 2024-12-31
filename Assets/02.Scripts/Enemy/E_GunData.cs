using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(menuName = "Scrpitable/E_GunData", fileName = "E_GunData", order = 2)]

public class E_GunData : ScriptableObject
{
        public AudioClip shotClip;
        public AudioClip reloadClip;
        public float fireRate = 0.15f;
        public float reloadTime = 1.6f;
}
