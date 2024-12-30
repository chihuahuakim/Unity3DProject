using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using UnityEngine;

public class FIreBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform FirePos;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem Cartridge;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] private AudioSource source;
    public GunData gunData_r;
    public GunData gunData_s;
    void Start()
    {
        playerInput = GetComponent<PlayerInput>();
        muzzleFlash = GetComponentsInChildren<ParticleSystem>()[0];
        Cartridge = GetComponentsInChildren<ParticleSystem>()[1];
        FirePos = this.transform.GetChild(0).GetChild(0).GetChild(0).transform;
        source = GetComponent<AudioSource>();
    }


    void Update()
    {
        if (playerInput.fire == true) 
        { 
            muzzleFlash.Play();
            Cartridge.Play();
            Fire();
        }

    }
    void Fire() 
    {
        Instantiate(bulletPrefab, FirePos.position, FirePos.rotation);
        source.PlayOneShot(gunData_r.shotClip, 1.0f);
    }
}
