using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    public Rigidbody2D rb2D;
    [SerializeField] float moveSpeed;
    [SerializeField] float turnSpeed;
    public Vector2 mousePosition;
    Vector2 currentVelocityV2;
    float currentVelocity;
    Vector2 direction;
    
    [SerializeField] float maxTurnSpeed;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        UpdateMoveSpeed();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        //Get Mouse Position
        mousePosition = Mouse.current.position.ReadValue();
        Debug.Log(mousePosition);
        var mousePosition3 = new Vector3(mousePosition.x, mousePosition.y, 10);
        var worldpos = Camera.main.ScreenToWorldPoint(mousePosition3);
        
        //direction
        direction = new Vector2(worldpos.x - transform.position.x, worldpos.y - transform.position.y);
        


        //RB2D move and rotate
        float angle = Vector2.SignedAngle(Vector2.right, direction);
        Vector3 targetRotation = new Vector3(0, 0, angle);
        rb2D.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime));
        rb2D.MovePosition(rb2D.position + ((Vector2)transform.right * moveSpeed * Time.deltaTime));

        // rotate sprite towards mouse
        //float angle = Vector2.SignedAngle(Vector2.right, direction);
        //Vector3 targetRotation = new Vector3(0, 0, angle);
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), turnSpeed * Time.deltaTime);

        //rotateSprite SmoothDamp
        //float targetAngle = Vector2.SignedAngle(Vector2.right, direction);
        //angle = Mathf.SmoothDampAngle(angle, targetAngle, ref currentVelocity, smoothTime, maxTurnSpeed);
        //transform.eulerAngles = new Vector3(0, 0, angle);

    }

    private void UpdateMoveSpeed()
    {
        moveSpeed = Mathf.Sqrt(moveSpeed);
    }
    public void Steer()
    {   /*
        screenPosition = Mouse.current.position.ReadValue();
        screenPosition.z = Camera.main.nearClipPlane + 1;
        WorldPosition = Camera.main.ScreenToWorldPoint(screenPosition);
        transform.position = WorldPosition;
        */

    }
}
