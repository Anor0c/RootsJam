using UnityEngine;
using UnityEngine.Events;

public class StayInCam : MonoBehaviour
{
    Rigidbody2D r2D;
    public UnityEvent<Vector2> StopMove;

    [SerializeField]  float maxPosY, minPosY, maxPosX, minPosX;
    void Start()
    {
        r2D = GetComponent<Rigidbody2D>();
    }


    void FixedUpdate()
    {
        if (r2D.position.x <= minPosX )
        {
            StopMove.Invoke(Vector2.left);
            Debug.Log("hit left");
        }
        if ( r2D.position.x >= maxPosX )
        {
            StopMove.Invoke(Vector2.right);
            Debug.Log("hit right");
        }
        if ( r2D.position.y <= minPosY )
        {
            StopMove.Invoke(Vector2.down);
            Debug.Log("hit down");
        }
        if ( r2D.position.y >= maxPosY)
        {
            StopMove.Invoke(Vector2.up);
            Debug.Log("hit up");
        }
    }
}
