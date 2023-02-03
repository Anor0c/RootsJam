using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
using UnityEngine.InputSystem;

public class MovementPlayer : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public float moveSpeed;
    public float turnSpeed;
    public Vector2 mousePosition;

    Vector2 direction;

    bool isMoving = false;
    float troncondistance;

    [SerializeField] float maxDistancePerPoint;
    private TestSpline splineRef;

    //FogOfWar
    public FogOfWar fogOfWar;
    public Transform secondaryFogOfWar;
    [Range(0, 5)]
    public float sightDistance;
    public float checkInterval;

    // Start is called before the first frame update
    void Start()
    {
        UpdateMoveSpeed();
        splineRef = GetComponentInParent<TestSpline>();
        StartCoroutine(CheckFogOfWar(checkInterval));
        secondaryFogOfWar.localScale = new Vector2(sightDistance, sightDistance) * 10f;
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
        splineRef.MoveLastPoint(rb2D.position);
        troncondistance += rb2D.velocity.magnitude * Time.fixedDeltaTime;
        if (troncondistance > maxDistancePerPoint)
        {
            splineRef.DistanceMet(rb2D.position);
            troncondistance = 0;
        }




    }

    private void UpdateMoveSpeed()
    {
        moveSpeed = Mathf.Sqrt(moveSpeed * 3);
    }

    public void StartMoving()
    {
        isMoving = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "water")
        {
            //splineRef.pointLimit += 2
            // lumière ?
        }
        if (collision.tag == "mushrooms")
        {
            //fogofwar += 1
        }
        if (collision.tag == "azote")
        {
            // turnspeed += 10
        }
    }

    private IEnumerator CheckFogOfWar(float checkInterval)
    {
        while (true)
        {
            fogOfWar.MakeHole(transform.position, sightDistance);
            yield return new WaitForSeconds(checkInterval);
        }
    }
}
