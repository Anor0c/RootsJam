using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruitageColl : MonoBehaviour
{
    AudioSource bruitage;
    private bool collidedOnce = false;
    Animator animator;
    Collider2D coll;
    // Start is called before the first frame update
    void Start()
    {
        bruitage = GetComponent<AudioSource>();
        animator = GetComponent<Animator>();
        coll = GetComponent<Collider2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {   
        if (collision.gameObject.tag == "Player" && !collidedOnce)
        {
            bruitage.Play();
            collidedOnce = true;
            animator.Play("AnimSonar");
            Destroy(coll);
        }

    }
}
