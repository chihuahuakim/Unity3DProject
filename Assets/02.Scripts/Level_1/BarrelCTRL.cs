using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class BarrelCTRL : MonoBehaviour
{
    [SerializeField] GameObject expEffect;
    [SerializeField] Mesh[] meshes;
    [SerializeField] Texture[] textures;
    [SerializeField] AudioSource source;
    [SerializeField] AudioClip expClip;
    
    public int hitCount = 0;

    [SerializeField] MeshRenderer renderer;
    [SerializeField] MeshFilter meshfilter;
    public float expRadius = 15f;
    readonly string bulletTag = "BULLET";

    Vector3 Pos =Vector3.zero;
    void Start()
    {
        expEffect = Resources.Load<GameObject>("Effects/sprite_realExplosion_c_example");
        renderer = GetComponent<MeshRenderer>();
        textures = Resources.LoadAll<Texture>("BarrelTextures");
        renderer.material.mainTexture = textures[Random.Range(0, textures.Length)];
        source = GetComponent<AudioSource>();
        expClip = Resources.Load<AudioClip>("Sounds/bullet_hit_metal_enemy_4");
        meshfilter = GetComponent<MeshFilter>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter(Collision col)
    {
        if (col.collider.CompareTag(bulletTag)) 
        {
            if (++hitCount == 3)
            {
                Pos= col.transform.position;
                ExpBarrel();
            }
        }
    }
    void ExpBarrel() 
    {
        GameObject effect = Instantiate(expEffect, transform.position, Quaternion.identity);
        Destroy(effect, 1.0f);
        Collider[] Cols = Physics.OverlapSphere(Pos, expRadius, 1<<8);
        foreach (Collider col in Cols) 
        {
            var rb = col.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass = 1.0f;
                rb.AddExplosionForce(1200f, Pos, expRadius, 1000f);
                
            }
        }
        source.PlayOneShot(expClip, 1.0f);
        int idx = Random.Range(0, meshes.Length);
        meshfilter.sharedMesh = meshes[idx];
        GetComponent<MeshCollider>().sharedMesh = meshes[idx];
        Invoke("BarrelMass", 3.0f);
    }
    void BarrelMass() 
    {
        Collider[] Cols = Physics.OverlapSphere(Pos, expRadius, 1 << 8);
        foreach (Collider col in Cols)
        {
            var rb = col.GetComponent<Rigidbody>();
            if (rb != null)
            {
                rb.mass = 60f;
            }
        }
    }
}
