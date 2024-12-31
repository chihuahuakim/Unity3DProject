using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowCam : MonoBehaviour
{
    [SerializeField] Transform target;
    [SerializeField] float Height = 10f;
    [SerializeField] float Distance = 7f;
    [SerializeField] float moveDamping = 10f;
    [SerializeField] float rotateDamping = 5f;
    [SerializeField] Transform tr;
    public float targetOffset = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        tr=transform;
        target = GameObject.FindWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void LateUpdate()
    {
        var camPos = target.position - (Vector3.forward * Distance) + (Vector3.up * Height);
        tr.position = Vector3.Slerp(tr.position, camPos, Time.deltaTime * moveDamping);
        tr.rotation = Quaternion.Slerp(tr.rotation, target.rotation, Time.deltaTime * rotateDamping);
        tr.LookAt(target.position+(target.up*targetOffset));
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(target.position + (target.up * targetOffset), 0.1f);
        Gizmos.DrawLine(target.position +(target.up * targetOffset), tr.position);
    }
}
