using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;

public class TestSpline : MonoBehaviour
{   
    Spline targetSpline;
    int lastPoint => targetSpline.GetPointCount() - 1;
    int lastFixedPoint => targetSpline.GetPointCount() - 2;


    public Vector2 rightTangentPos = new Vector2(1,1);
    bool isDead = false;
    int pointGenerated;

    public UnityEvent OnDeath;
    
    public RootData datar;
    void Start()
    {
        pointGenerated = 0;
        var SplineController = GetComponent<SpriteShapeController>();
        targetSpline = SplineController.spline;
        targetSpline.SetTangentMode(1, ShapeTangentMode.Continuous);
        
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
                targetSpline.SetTangentMode(lastPoint, ShapeTangentMode.Continuous);

                targetSpline.SetTangentMode(lastFixedPoint, ShapeTangentMode.Continuous);
                targetSpline.SetLeftTangent(lastFixedPoint, rightTangentPos*-1);
                targetSpline.SetRightTangent(lastFixedPoint, rightTangentPos);
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
    }

    public void MoveLastPoint(Vector3 newPosition)
    {
        targetSpline.SetPosition(lastPoint, newPosition);
    }

    public Vector2 LeftTangentPosition(Vector3 playerDirectionNormalised)
    {
        //probablement il faudrat retoucher a ce script pour que la spline soit continue en C²
        var tangentVector = playerDirectionNormalised;
        return tangentVector;
    }
   
    private void Death()
    {   
        Debug.Log("Camarche");
        OnDeath.Invoke();
    }

}
