using UnityEngine;

public class RandomSpawnInteracibles : MonoBehaviour
{
    public GameObject[] interractibleArray;

    public int minDepth = 0;
    public int maxDepth = 5;
    public int biomeNumberInScene=20;

    Vector3 spawnedPos;

    void Start()
    {
                
        for (int i = 0; i < biomeNumberInScene; i++)
        {
            spawnedPos = RandomPos();
            Instantiate(interractibleArray[ArrayChoice()], spawnedPos, Quaternion.identity);
        }
    }
    int ArrayChoice()
    {
        int arrayChoice = 0;
        int spawnRate = Random.Range(0, 99);
        if (spawnRate < 50)
        {
            arrayChoice = 0;
        }
        else
        {
            arrayChoice = 1;
        }
        return arrayChoice;
    }
    Vector3 RandomPos()
    {
        Vector3 randomPos;
        float randomX = Random.Range(minDepth, maxDepth);
        float randomY = Random.Range(minDepth, maxDepth);
        randomPos = new Vector3( -randomX, -randomY, 0f);

        return randomPos;
    }
}
