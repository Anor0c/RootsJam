using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;
using Cinemachine;

public class MovementPlayer : MonoBehaviour
{
    public Rigidbody2D rb2D;
    public Vector2 mousePosition;

    Vector2 direction;

    [SerializeField] bool isStopX = false, isStopY = false;
    [SerializeField] bool boundaryUp, boundaryRight, boundaryDown, boundaryLeft;

    [SerializeField]bool isMoving = false;
    [SerializeField]bool isAlive = true;
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
    void Start()
    {
        //UpdateMoveSpeed();
        splineRef = GetComponentInParent<TestSpline>();
        _spriteHead = GetComponentInChildren<SpriteRenderer>();
        fogOfWar = FindObjectOfType<FogOfWar>();
        StartCoroutine(CheckFogOfWar(checkInterval));
        secondaryFogOfWar.localScale = new Vector2(sightDistance, sightDistance) * 10f;
    }

    void FixedUpdate()
    {
        if (!isAlive)
            return;


        else if (!isMoving)
            return;


        else
        {
            //Get Mouse Position
            mousePosition = Mouse.current.position.ReadValue();
            //Debug.Log(mousePosition);
            var mousePosition3 = new Vector3(mousePosition.x, mousePosition.y, 10);
            var worldpos = Camera.main.ScreenToWorldPoint(mousePosition3);
            //direction
            direction = new Vector2(worldpos.x - transform.position.x, worldpos.y - transform.position.y);
            //RB2D move and rotate
            float angle = Vector2.SignedAngle(Vector2.down, direction);
            Vector3 targetRotation = new Vector3(0, 0, angle);
            rb2D.MoveRotation(Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(targetRotation), datar.currentTurnSpeed * Time.fixedDeltaTime));

            //bloque roothead s'il sort de l'ecran
            var rootVector = -transform.up * datar.currentSpeed;
            if (isStopX)
            {
                rootVector = new Vector2(0, rootVector.y);
            }

            if (isStopY)
            {
                rootVector = new Vector2(rootVector.x, 0);
            }

            rb2D.velocity = rootVector;
            splineRef.MoveLastPoint(rb2D.position);
            troncondistance += rb2D.velocity.magnitude * Time.fixedDeltaTime;
            if (troncondistance > maxDistancePerPoint)
            {
                splineRef.DistanceMet(rb2D.position);
                troncondistance = 0;
            }
        }
    }

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
            fogOfWar.MakeHole(collision.gameObject.transform.position, (datar.sightDistance*3));
            Debug.Log("PointLimit");
        }
        if (collision.gameObject.tag == "mushrooms")
        {
            datar.currentSightDistance += 0.5f;
            datar.currentRessource += 1;
            fogOfWar.MakeHole(collision.gameObject.transform.position, (datar.sightDistance*3));
        }
        if (collision.gameObject.tag == "azote")
        {
            datar.currentTurnSpeed += 2f;
            datar.currentRessource += 1;
            fogOfWar.MakeHole(collision.gameObject.transform.position, (datar.sightDistance*3));
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
    }
    public void StopMove(Vector2 stopDir)
    {
        Debug.Log("StopDir est"+stopDir);

        if (stopDir.y > 0)
        {
            boundaryUp = true;
        }
        else if (stopDir.y < 0)
        {
            boundaryDown = true;
        }
        else if (stopDir.x > 0)
        {
            boundaryLeft = true;
        }
        else if (stopDir.x > 0)
        {
            boundaryRight = true;
        }
        else
        {
            boundaryUp = false;
            boundaryRight = false;
            boundaryLeft = false;
            boundaryDown = false;
        }


        if (rb2D.velocity.y >= 0 && boundaryUp) 
        {
            isStopY = true;
        }
        else if (rb2D.velocity.y <= 0 && boundaryDown)
        {
            isStopY = true;
        }
        else
        {
            isStopY = false;
        }

        if (rb2D.velocity.x >= 0 && boundaryRight) 
        {
            isStopX = true;
        }
        else if (rb2D.velocity.x <= 0 && boundaryLeft)
        {
            isStopX = true;
        }
        else
        {
            isStopX = false;
        }
    }
}
