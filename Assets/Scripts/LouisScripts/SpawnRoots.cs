using UnityEngine;
using UnityEngine.Events;

public class SpawnRoots : MonoBehaviour
{
    public RootData datar;
    public GameObject root;

    public int lifeCounter=2;
    public UnityEvent onGameOver, onSpawn;

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
            onSpawn.Invoke();
        }     
    }
    public void GameOver()
    {
        onGameOver.Invoke();
    }
}
