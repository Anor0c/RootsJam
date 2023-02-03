using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiOverlap : MonoBehaviour
{
    CircleCollider2D antiOverlapBox;

    private void Start()
    {
        antiOverlapBox = GetComponent<CircleCollider2D>();
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        float randomOffset = Random.Range(-antiOverlapBox.radius, antiOverlapBox.radius);
        Debug.Log("NOoverlap");
        if (collision.gameObject.tag == "AntiOverlap")
        {
            Debug.Log("overlap");
            //collision.transform.position = new Vector3(collision.transform.position.x + randomOffset, collision.transform.position.y + randomOffset, 0);
        }
    }
    private void OnColliderStay2D(Collider2D collision)
    {
        float randomOffset = Random.Range(-antiOverlapBox.radius, antiOverlapBox.radius);
        Debug.Log("NOoverlap");
        if (collision.gameObject.tag == "AntiOverlap")
        {
            Debug.Log("overlap");
            //collision.transform.position = new Vector3(collision.transform.position.x + randomOffset, collision.transform.position.y + randomOffset, 0);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        float randomOffset = Random.Range(-antiOverlapBox.radius, antiOverlapBox.radius);
        if (collision.gameObject.tag == "AntiOverlap")
        {
            Debug.Log("overlap22");
            //collision.transform.position = new Vector3(collision.transform.position.x + randomOffset, collision.transform.position.y + randomOffset, 0);
        }
    }
}
