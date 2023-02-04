using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRoots : MonoBehaviour
{
    public RootData datar;
    public GameObject root;
    public Camera cineCam;
    
    public void OnSpawn()
    {
        //DestroyActor()
        //Debug.Log(transform.position);
        Instantiate(root, transform.position, Quaternion.identity);
        //cineCam.GetComponent<CinemachineVirtualCamera>().Follow;
    }
}
