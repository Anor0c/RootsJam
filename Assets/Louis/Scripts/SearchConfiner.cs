using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class SearchConfiner : MonoBehaviour
{
    PolygonCollider2D confiner;
    CinemachineConfiner cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<CinemachineConfiner>();
        var collArray = FindObjectsOfType<PolygonCollider2D>();
        foreach(PolygonCollider2D coll in collArray)
        {
            if (coll.CompareTag("Confiner"))
            {
                confiner = coll;
            }
        }
        cam.m_BoundingShape2D = confiner;
    }
}
