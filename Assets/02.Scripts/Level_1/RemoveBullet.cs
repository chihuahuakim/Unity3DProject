using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RemoveBullet : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip hitClip;
    [SerializeField] GameObject hitEffect;
    readonly string bulletTag = "BULLET";
    void Start()
    {
        source=GetComponent<AudioSource>();
        hitClip = Resources.Load<AudioClip>("Sounds/bullet_hit_metal_enemy_4");
        hitEffect = Resources.Load<GameObject>("Effects/FlareMobile");
    }


    private void OnCollisionEnter( Collision col)
    {
        if (col.collider.CompareTag(bulletTag)) 
        {
            Destroy(col.gameObject);
            source.PlayOneShot(hitClip, 1.0f);
            GameObject hitEff = Instantiate(hitEffect, col.transform.position, Quaternion.identity);
            Destroy(hitEff, 0.5f );
        }
    }
}
