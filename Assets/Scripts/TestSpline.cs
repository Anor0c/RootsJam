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
    //public int pointLimit;
    int pointGenerated;
    //public GameObject currentRoot;
    public UnityEvent OnDeath;
    
    public RootData datar;
    void Start()
    {
        pointGenerated = 0;
        var SplineController = GetComponent<SpriteShapeController>();
        targetSpline = SplineController.spline;
        targetSpline.SetTangentMode(1, ShapeTangentMode.Continuous);
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
                targetSpline.SetTangentMode(lastFixedPoint, ShapeTangentMode.Continuous);
            }
            pointGenerated += 1;
            if (pointGenerated == datar.currentPointLimit)
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

    private void OnDestroy()
    {
        
    }
    private void Death()
    {
        Debug.Log("Camarche");
        //activate death Head
        //DestroyLivingHead
        //ChangeColor
        //Spawn
        //targetSpline.Clear();
        OnDeath.Invoke();
        

    }
    /*public void AddDistance(float distanceToAdd)
    {
        truetotaldistance += distanceToAdd;
    }*/
}
