using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoots : MonoBehaviour
{
    public GameObject root;
    public void OnSpawn()
    {
        Instantiate(root, transform.position, Quaternion.identity);
    }
}
