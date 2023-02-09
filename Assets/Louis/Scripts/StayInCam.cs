using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StayInCam : MonoBehaviour
{
    Rigidbody2D r2D;
    GameObject rootHead;
    void Start()
    {
        r2D = GetComponent<Rigidbody2D>();
        rootHead = r2D.gameObject;
    }


    void Update()
    {
        if (rootHead.transform.position.y >= 3)
        { 
            Debug.Log("trop haut!!!!!!");
        }
    }
}
