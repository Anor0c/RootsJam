using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SreenBoundaries : MonoBehaviour
{
    public PolygonCollider2D _camConfiner;

    Vector2 screenBounds;
    float playerWidth;
    float playerHeight;

    void Start()
    {
        screenBounds = new Vector2(_camConfiner.bounds.size.x/2, _camConfiner.bounds.size.y/2);
        playerHeight = GetComponent<SpriteRenderer>().bounds.size.y/2;
        playerWidth = GetComponent<SpriteRenderer>().bounds.size.x/2;
    }


    private void Update()
    {
        Vector3 viewPos = transform.position;
        viewPos.x = Mathf.Clamp(viewPos.x,-screenBounds.x - playerWidth, screenBounds.x + playerWidth);
        viewPos.y = Mathf.Clamp(viewPos.y, -screenBounds.y-18.5f - playerHeight, screenBounds.y + playerHeight-18.5f);
    }
    
}
