using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class SpawnRoots : MonoBehaviour
{
    public RootData datar;
    public GameObject root;

    public int lifeCounter=2;
    public UnityEvent onGameOver;

    private void Start()
    {
        OnSpawn();
    }
    public void OnSpawn()
    {
        Debug.Log("spawn");
        if (lifeCounter <= 0)
            GameOver();
        else
        {
            Instantiate(root, transform.position, Quaternion.identity);
            lifeCounter--;
        }
    }
    public void GameOver()
    {
        onGameOver.Invoke();
    }
}
