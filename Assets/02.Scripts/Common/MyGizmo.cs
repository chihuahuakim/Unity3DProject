using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyGizmo : MonoBehaviour
{
    public Color GizmoCor = Color.red;
    public float _radous = 0.05f;
    private void OnDrawGizmos()
    {
        Gizmos.color = GizmoCor;
        Gizmos.DrawSphere(transform.position, _radous);
    }

}
