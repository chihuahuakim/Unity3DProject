using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PatrolGizmo : MonoBehaviour
{
    public Color patCor = Color.blue;
    public float pRadous = 0.5f;
    public List<Transform> points;
    void Start()
    {

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = patCor;
        Transform[] tr = GetComponentsInChildren<Transform>();
        points = new List<Transform>();
        for (int i = 0; i < tr.Length; i++)
        {
            if (tr[i] != this.transform)
                points.Add(tr[i]);
        }
        for (int i = 0; i < points.Count; i++) 
        {
            Vector3 Cpoints = points[i].position;
            Vector3 Ppoints = Vector3.zero;
            if (i > 0) { Ppoints = points[i - 1].position; }
            else if (i == 0 && points.Count > 1) { Ppoints = points[points.Count - 1].position; }
            Gizmos.DrawSphere(Cpoints, pRadous);
            Gizmos.DrawLine(Cpoints, Ppoints);  
        }

    }
}
