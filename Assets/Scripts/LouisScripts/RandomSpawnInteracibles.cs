using System.Collections.Generic;
using UnityEngine;

public class RandomSpawnInteracibles : MonoBehaviour
{
    public GameObject[] interractibleArray;
    List<Vector3> spawnedPosList= new List<Vector3>();

    public int minDepth = 0;
    public int maxDepth = 5;
    public int minWidth = -20;
    public int maxWidth = 20;
    public int biomeNumberInScene = 20;
    public float distanceBetweenSpawn;

    Vector3 spawnedPos;

    void Start()
    {
        spawnedPosList.Add(new Vector3(9, 9, 9));
        for (int i = 0; i < biomeNumberInScene; i++)
        {
            spawnedPos = RandomPos();
            foreach(Vector3 pos in spawnedPosList)
            {
                if (spawnedPos.x >= pos.x - distanceBetweenSpawn && spawnedPos.x <= pos.x + distanceBetweenSpawn && spawnedPos.y >= pos.y - distanceBetweenSpawn && spawnedPos.y <= pos.y + distanceBetweenSpawn) 
                {
                    spawnedPos = RandomPos();
                }
            }
            Instantiate(interractibleArray[ArrayChoice()], spawnedPos, Quaternion.identity);
            spawnedPosList.Add(spawnedPos);
        }
    }
    int ArrayChoice()
    {
        int arrayChoice = 0;
        int spawnRate = Random.Range(0, interractibleArray.Length);
        arrayChoice = spawnRate;

        return arrayChoice;
    }
    Vector3 RandomPos()
    {
        Vector3 randomPos;
        float randomX = Random.Range(minWidth, maxWidth);
        float randomY = Random.Range(minDepth, maxDepth);
        randomPos = new Vector3( -randomX, -randomY, 0f);

        return randomPos;
    }
}
