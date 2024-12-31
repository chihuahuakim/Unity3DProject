using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class MoveAgent : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;
    [SerializeField] Transform enemyTr;
    [SerializeField] List<Transform> Ppoints;
    public int idx = 0;
    float patrolsp = 4f;
    float tracesp = 7f;
    float damping = 1f;
    bool isPatrol;
    public bool _isPatrol 
    {
        get { return isPatrol; }
        set 
        {
            if (_isPatrol == true) 
            {
                _isPatrol = value;
                agent.speed = patrolsp;
                damping = 1f;
            }
        }
    }
    private Vector3 target;
    public Vector3 _target
    {
        get { return target; }
        set
        {
            _target = value;
            agent.speed = tracesp;
            damping = 7f;
            TraceTarget(target);

        }
    }
    public float speed
    {
        get { return agent.velocity.magnitude; }
    }
    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.autoBraking = false;
        enemyTr = transform;
        var group = GameObject.Find("PatrolPoint").transform;
        if (group != null)
        {
            group.GetComponentsInChildren<Transform>(Ppoints);
            Ppoints.RemoveAt(0);
        }
        MovePpoint();
    }


    void TraceTarget(Vector3 pos) 
    {
        if (agent.isPathStale) return;
        agent.destination = pos;
        agent.isStopped = false;
        Debug.Log("ÃßÀû!");
    }
    public void Stop()
    {
        agent.isStopped = true;
        agent.velocity = Vector3.zero;
        _isPatrol = false;
    }
    void Update()
    {
        if (agent.isStopped == false)
        {
            Quaternion rot = Quaternion.LookRotation(agent.desiredVelocity);
            enemyTr.rotation = Quaternion.Slerp(enemyTr.rotation, rot, Time.deltaTime * damping);
        }

        if (agent.remainingDistance <= 0.5f)
        {
            idx = ++idx % Ppoints.Count;
            MovePpoint();
        }
        if (!_isPatrol) return;
        agent.stoppingDistance = 0f;

    }
    void MovePpoint()
    {
        if (agent.isPathStale) return;
        agent.destination = Ppoints[idx].position;
        agent.isStopped = false;
        agent.speed = 7f;
    }
}
