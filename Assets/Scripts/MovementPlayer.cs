using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.U2D;
using UnityEngine.InputSystem;
using Cinemachine;

public class MovementPlayer : MonoBehaviour
{
    public Rigidbody2D rb2D;
    //public float moveSpeed;
    //public float turnSpeed;
    public Vector2 mousePosition;

    Vector2 direction;

    bool isMoving = false;
    bool isAlive = true;
    float troncondistance;

    [SerializeField] float maxDistancePerPoint;
    private TestSpline splineRef;

    //FogOfWar
    [SerializeField] FogOfWar fogOfWar;
    public Transform secondaryFogOfWar;
    [Range(0, 5)]
    public float sightDistance;
    public float checkInterval;
    public RootData datar;

    [SerializeField] Sprite sleepyHead;
    SpriteRenderer _spriteHead;
    public CinemachineVirtualCamera cam;

    private void Awake()
    {
        sightDistance = datar.currentSightDistance;
    }
    // Start is called before the first frame update
    void Start()
    {
        //UpdateMoveSpeed();
        splineRef = GetComponentInParent<TestSpline>();
        _spriteHead = GetComponent<SpriteRenderer>();
        fogOfWar = FindObjectOfType<FogOfWar>();
        StartCoroutine(CheckFogOfWar(checkInterval));
        secondaryFogOfWar.localScale = new Vector2(sightDistance, sightDistance) * 10f;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (!isAlive)
        {
            return;
        }
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
        rb2D.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), datar.currentTurnSpeed * Time.fixedDeltaTime));

        rb2D.velocity = transform.right * datar.currentSpeed;
        splineRef.MoveLastPoint(rb2D.position);
        troncondistance += rb2D.velocity.magnitude * Time.fixedDeltaTime;
        if (troncondistance > maxDistancePerPoint)
        {
            splineRef.DistanceMet(rb2D.position);
            troncondistance = 0;
        }




    }

    /*private void UpdateMoveSpeed()
    {
        datar.currentSpeed = Mathf.Sqrt(datar.currentSpeed * 3);
    }*/

    public void StartMoving()
    {
        isMoving = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "water")
        {
            datar.currentPointLimit += 2;
            datar.currentRessource += 1;
            Debug.Log("c2lo");
            fogOfWar.MakeHole(collision.gameObject.transform.position, datar.currentSightDistance);
            //collision.GetComponent<SpriteRenderer>().maskInteraction;
        }
        if (collision.gameObject.tag == "mushrooms")
        {
            datar.currentSightDistance += 0.5f;
            datar.currentRessource += 1;
            fogOfWar.MakeHole(collision.gameObject.gameObject.transform.position, datar.currentSightDistance);
        }
        if (collision.gameObject.tag == "azote")
        {
            datar.currentTurnSpeed += 2f;
            datar.currentRessource += 1;
            fogOfWar.MakeHole(collision.gameObject.gameObject.transform.position, datar.currentSightDistance);
        }
    }

    private IEnumerator CheckFogOfWar(float checkInterval)
    {
        while (true)
        {
            fogOfWar.MakeHole(transform.position, datar.currentSightDistance);
            yield return new WaitForSeconds(checkInterval);
        }
    }

    public void Die()
    {
        _spriteHead.sprite = sleepyHead;
        rb2D.velocity = Vector2.zero;
        cam.Priority = 2;
        isAlive = false;
        //Destroy(this.gameObject);
    }
}
