using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;

public class StrateFrontierRandomHeight : MonoBehaviour
{
    [SerializeField] Spline strate;

    private void Awake()
    {
        strate = GetComponentInParent<SpriteShapeController>().spline;
    }
    void Start()
    {
        //gere les points en dessous
        strate.InsertPointAt(4, Vector3.zero);
        strate.SetTangentMode(4, ShapeTangentMode.Continuous);
        //gere les point au dessus
        strate.InsertPointAt(2, Vector3.zero);
        strate.SetTangentMode(2, ShapeTangentMode.Continuous);
    }
}
