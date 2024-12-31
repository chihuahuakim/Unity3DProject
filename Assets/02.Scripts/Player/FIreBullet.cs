using System.Collections;
using System.Collections.Generic;
using System.Data.Common;
using System.Diagnostics;
using UnityEngine;

public class FIreBullet : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform FirePos;
    [SerializeField] ParticleSystem muzzleFlash;
    [SerializeField] ParticleSystem Cartridge;
    [SerializeField] PlayerInput playerInput;
    [SerializeField] private AudioSource source;
    [SerializeField] private Animator animator;
    public GunData gunData_r;
    public GunData gunData_s;
    readonly int hashReload = Animator.StringToHash("Reload");
    int curBullet = 10;
    readonly int maxbullet = 10;
    WaitForSeconds reloadWs;
    bool isReloading = false;
    void Start()
    {
        animator = GetComponent<Animator>();
        playerInput = GetComponent<PlayerInput>();
        muzzleFlash = GetComponentsInChildren<ParticleSystem>()[0];
        Cartridge = GetComponentsInChildren<ParticleSystem>()[1];
        FirePos = this.transform.GetChild(0).GetChild(0).GetChild(0).transform;
        source = GetComponent<AudioSource>();
        reloadWs = new WaitForSeconds(gunData_r.reloadTime);
    }


    void Update()
    {
        if (playerInput.fire == true) 
        { 
            if(!isReloading && !playerInput.sprint)
                Fire(); 
        }

    }
    void Fire() 
    {
        Instantiate(bulletPrefab, FirePos.position, FirePos.rotation);
        Cartridge.Play();
        muzzleFlash.Play();
        source.PlayOneShot(gunData_r.shotClip, 1.0f);
        isReloading = (--curBullet % maxbullet == 0);
        if (isReloading)
            StartCoroutine(Reloading());
    }
    IEnumerator Reloading() 
    {
        animator.SetTrigger(hashReload);
        source.PlayOneShot(gunData_r.reloadClip, 1.0f);
        yield return reloadWs;
        curBullet = maxbullet;
        isReloading = false;
    }
}
