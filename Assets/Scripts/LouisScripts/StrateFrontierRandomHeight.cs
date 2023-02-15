using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class StrateFrontierRandomHeight : MonoBehaviour
{
    [SerializeField] Spline strate;
    public int pointNumber=5;
    public float minDepth=5.5f;
    public float minTangent=-5f;

    public float maxDepth=9.5f;
    public float maxTangent=5f;


    float randomDepthDown = 5f;
    float randomTangent = 0f;

    private void Awake()
    {
        strate = GetComponentInParent<SpriteShapeController>().spline;
    }
    void Start()
    {
        //gere les points a la base en bas
        randomDepthDown = Random.Range(-minDepth, -maxDepth);
        strate.SetPosition(0, new Vector3(strate.GetPosition(0).x, randomDepthDown, 0));
        randomDepthDown = Random.Range(-minDepth, -maxDepth);
        strate.SetPosition(3, new Vector3(strate.GetPosition(3).x, randomDepthDown, 0));


        for (int i = 0; i < pointNumber; i++)
        {
            //gere les points en dessous générés au start
            randomDepthDown = Random.Range(-minDepth, -maxDepth);
            randomTangent = Random.Range(minTangent, maxTangent);

            strate.InsertPointAt(4+i,new Vector3(14-i*5, randomDepthDown, 0));
            strate.SetTangentMode(4+i, ShapeTangentMode.Continuous);
            strate.SetRightTangent(4+i, new Vector3(-3, randomTangent, 0));
            strate.SetLeftTangent(4+i, new Vector3(3, -randomTangent, 0));

        }

    }
}
