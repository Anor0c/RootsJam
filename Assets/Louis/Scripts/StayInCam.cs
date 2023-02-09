using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StayInCam : MonoBehaviour
{
    Rigidbody2D r2D;
    GameObject rootHead;
    public UnityEvent stopMoveX, stopMoveY;
    void Start()
    {
        r2D = GetComponent<Rigidbody2D>();
        rootHead = r2D.gameObject;
    }


    void Update()
    {
        if (rootHead.transform.position.y >= 3 || rootHead.transform.position.y<=53)
        {
            stopMoveY.Invoke();
        }
        if (rootHead.transform.position.x>=-20|| rootHead.transform.position.x <= 20)
        {
            stopMoveX.Invoke(); 
        }
    }
}
