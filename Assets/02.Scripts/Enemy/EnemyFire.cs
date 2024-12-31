using System.Collections;
using System.Collections.Generic;
using Unity.Collections;
using UnityEngine;

public class EnemyFire : MonoBehaviour
{
    [SerializeField] AudioClip fireClip;
    [SerializeField] AudioSource source;
    [SerializeField] Animator animator;
    [SerializeField] Transform PlayerTr;
    [SerializeField] Transform tr;

    public E_GunData enemyGun;
    readonly int hashFire = Animator.StringToHash("Fire");

    private float nxtFire = 0f;
    readonly float damping = 10f;
    public bool isFire = false; 

    void Start()
    {
        source = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        tr = transform;
        PlayerTr = GameObject.FindWithTag("Player").transform;
        
    }

    void Update()
    {
        if (isFire) 
        {
            if (Time.time >= nxtFire) 
            {
                Fire();
                nxtFire = Time.time + enemyGun.fireRate+Random.Range(0.0f, 0.3f);
            }
            Quaternion rot = Quaternion.LookRotation(PlayerTr.position - tr.position);
            tr.rotation = Quaternion.Slerp(tr.rotation, rot, damping*Time.deltaTime);
        } 
    }
    void Fire()
    {
        animator.SetTrigger(hashFire);
        source.PlayOneShot(enemyGun.shotClip, 1.0f);
    }
}
