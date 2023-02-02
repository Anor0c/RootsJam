using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    public Rigidbody2D rb2D;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    public Vector2 mousePosition;
    
    Vector2 direction;

    bool isMoving = false;
    float totalDistance;
    [SerializeField] float maxDistancePerPoint;



    
    

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoveSpeed();
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isMoving)
        {
            return;
        }
        //Get Mouse Position
        mousePosition = Mouse.current.position.ReadValue();
        //Debug.Log(mousePosition);
        var mousePosition3 = new Vector3(mousePosition.x, mousePosition.y, 10);
        var worldpos = Camera.main.ScreenToWorldPoint(mousePosition3);
        //direction
        direction = new Vector2(worldpos.x - transform.position.x, worldpos.y - transform.position.y);
        //RB2D move and rotate
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        rb2D.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.fixedDeltaTime));
        
        rb2D.velocity = transform.right * moveSpeed;
        GetComponentInParent<TestSpline>().MoveLastPoint(rb2D.position);
        totalDistance += rb2D.velocity.magnitude * Time.fixedDeltaTime;
        if (totalDistance > maxDistancePerPoint)
        {
            GetComponentInParent<TestSpline>().DistanceMet(rb2D.position);
            totalDistance = 0;
        }




    }

    private void UpdateMoveSpeed()
    {
        moveSpeed = Mathf.Sqrt(moveSpeed*3);
    }

    public void StartMoving()
    {
        isMoving = true;
    }

   
}
