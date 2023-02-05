using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BruitageColl : MonoBehaviour
{
    AudioSource bruitage;
    // Start is called before the first frame update
    void Start()
    {
        bruitage = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        bruitage.Play();
    }
}
