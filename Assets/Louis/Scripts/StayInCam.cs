using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StayInCam : MonoBehaviour
{
    Rigidbody2D r2D;
    GameObject rootHead;
    public UnityEvent stopMoveX, stopMoveY;

    [SerializeField] float maxPosY, minPosY, maxPosX, minPosX;
    void Start()
    {
        r2D = GetComponent<Rigidbody2D>();
        rootHead = r2D.gameObject;
    }


    void LateUpdate()
    {
        if (rootHead.transform.position.y <= minPosY || rootHead.transform.position.y>=maxPosY)
        {
            stopMoveY.Invoke();
        }
        if (rootHead.transform.position.x<=minPosX|| rootHead.transform.position.x >= maxPosX)
        {
            stopMoveX.Invoke(); 
        }
    }
}
