using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class PathFollower : MonoBehaviour
{
    [SerializeField] SplineContainer splineContainer;
    //[SerializeField]
    [Range(0, 100)] public float speed;
    [Range(0, 1)] public float tDistance;

    //float tDistance = 0; // distance along spline (0-1)

    //public float speed { get; set; }
    public float length { get { return splineContainer.CalculateLength(); } }
    public float distance 
    { 
        get { return tDistance * length; } 
        set { tDistance = value / length; } // normalized
    } 

    void Update()
    {
        distance += speed * Time.deltaTime;
        UpdateTransform(math.frac(tDistance));
    }

    void UpdateTransform(float t)
    {
        Vector3 position = splineContainer.EvaluatePosition(t); // 0-1 from start to end, not caring about world distances
        Vector3 up = splineContainer.EvaluateUpVector(t);
        Vector3 forward = Vector3.Normalize(splineContainer.EvaluateTangent(t));
        Vector3 right = Vector3.Cross(up, forward); // cross product of up and forward = right

        transform.position = position;
        transform.rotation = Quaternion.LookRotation(forward, up);
    }
}
