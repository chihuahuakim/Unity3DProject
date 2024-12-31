using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAi : MonoBehaviour
{
    public enum State { PATROL, TRACE, ATTACK, DIE };
    [SerializeField] public State state = State.PATROL;
    MoveAgent moveAgent;

    readonly int HashDie = Animator.StringToHash("Die");
    readonly int HashFire = Animator.StringToHash("Fire");
    readonly int HashTrace = Animator.StringToHash("Trace");

    Animator animator; 
    Rigidbody rb;
    CapsuleCollider capCol;

    public AudioClip atksound;
    [SerializeField] private AudioSource source;

    [SerializeField] private Transform playerTr;
    [SerializeField] private Transform EnemyTr;

    float attackDist= 5f;
    float traceDist = 10f;

    WaitForSeconds ws = new WaitForSeconds(0.3f);

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
