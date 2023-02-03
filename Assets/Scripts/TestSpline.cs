using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;

public class TestSpline : MonoBehaviour
{   

    // Start is called before the first frame update
    Spline targetSpline;
    int lastPoint => targetSpline.GetPointCount() - 1;
    int lastFixedPoint => targetSpline.GetPointCount() - 2;
    

    float truetotaldistance;
    bool isDead = false;
    public int PointLimit;
    int PointGenerated;
    public UnityEvent<int> OnDeath;
    void Start()
    {
        PointGenerated = 0;
        var SplineController = GetComponent<SpriteShapeController>();
        targetSpline = SplineController.spline;
    }

    // Update is called once per frame
    void Update()
    {   
        
    }

    public void DistanceMet(Vector3 newPosition)
    {
        if (!isDead)
        {
            StartCoroutine(DistanceMetCoroutine(newPosition));
            IEnumerator DistanceMetCoroutine(Vector3 newPosition)
            {
                yield return new WaitForSeconds(0.08f);
                Debug.Log($"Count : {lastPoint}, position :{newPosition}");
                targetSpline.InsertPointAt(lastPoint, newPosition);
            }
            PointGenerated += 1;
            if (PointGenerated == PointLimit)
            {
                isDead = true;
            }
        }


        else
        {
            Death();
        }
        //
    }

    public void MoveLastPoint(Vector3 newPosition)
    {
        targetSpline.SetPosition(lastPoint, newPosition);
    }


    private void Death()
    {
        Debug.Log("Camarche");
        //activate death Head
        //DestroyLivingHead
        //ChangeColor
        //Spawn
        OnDeath.Invoke(PointLimit);
    }
    /*public void AddDistance(float distanceToAdd)
    {
        truetotaldistance += distanceToAdd;
    }*/
}
