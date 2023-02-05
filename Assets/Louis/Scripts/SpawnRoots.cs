using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoots : MonoBehaviour
{
    public RootData datar;
    public GameObject root;

    public int lifeCounter=2;

    private void Start()
    {
        OnSpawn();
    }
    public void OnSpawn()
    {
        Debug.Log("spawn");
        if (lifeCounter <= 0)
            return;

        Instantiate(root, transform.position, Quaternion.identity);
        lifeCounter--;

    }
}
