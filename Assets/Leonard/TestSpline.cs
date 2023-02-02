using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class TestSpline : MonoBehaviour
{
    // Start is called before the first frame update
    Spline targetSpline;
    int lastPoint => targetSpline.GetPointCount() -1;
    int lastFixedPoint => targetSpline.GetPointCount() -2;

    void Start()
    {
        var SplineController = GetComponent<SpriteShapeController>();
        targetSpline = SplineController.spline;
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void DistanceMet(Vector3 newPosition)
    {
        StartCoroutine(DistanceMetCoroutine(newPosition));
        IEnumerator DistanceMetCoroutine(Vector3 newPosition)
        {
            yield return new WaitForSeconds(0.2f);
            Debug.Log($"Count : {lastPoint}, position :{newPosition}");
            targetSpline.InsertPointAt(lastPoint, newPosition);
        }
        
    }

    public void MoveLastPoint(Vector3 newPosition)
    {
        targetSpline.SetPosition(lastPoint, newPosition);
    }
}
