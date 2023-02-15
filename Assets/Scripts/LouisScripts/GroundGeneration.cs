using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundGeneration : MonoBehaviour
{
    public GameObject[] ground1Array;
    public GameObject[] ground2Array;
    public GameObject[] ground3Array;

    float currentxPos;
    float tileSize=5f;

    private void Start()
    {
        for (int i = 0; i < 20; i++)
        {
            //Génération strate 1
            if (i < 10)
            {
                currentxPos = (i * tileSize) - (5f * tileSize);
                Instantiate(ground1Array[Random.Range(0, ground1Array.Length)], new Vector3(currentxPos, 0, 0), Quaternion.identity);
            }
            else
            {
                currentxPos = ((i - 10) * tileSize) - (5f * tileSize);
                Instantiate(ground1Array[Random.Range(0, ground1Array.Length)], new Vector3(currentxPos, -tileSize, 0), Quaternion.identity);
            }

        }
        //Génération strate 2
        for (int i = 0; i < 50; i++)
        {
            if (i < 10)
            {
                currentxPos = (i * tileSize) - (5f * tileSize);
                Instantiate(ground2Array[Random.Range(0, ground2Array.Length)], new Vector3(currentxPos, -2 * tileSize, 0), Quaternion.identity);
            }
            else if (i < 20) 
            {
                currentxPos = ((i - 10) * tileSize) - (5f * tileSize);
                Instantiate(ground2Array[Random.Range(0, ground2Array.Length)], new Vector3(currentxPos, -3*tileSize, 0), Quaternion.identity);
            }
            else if (i < 30) 
            {
                currentxPos = ((i - 20) * tileSize) - (5f * tileSize);
                Instantiate(ground2Array[Random.Range(0, ground2Array.Length)], new Vector3(currentxPos, -4*tileSize, 0), Quaternion.identity);
            }
            else if (i < 40) 
            {
                currentxPos = ((i - 30) * tileSize) - (5f * tileSize);
                Instantiate(ground2Array[Random.Range(0, ground2Array.Length)], new Vector3(currentxPos, -5*tileSize, 0), Quaternion.identity);
            }
            else  
            {
                currentxPos = ((i - 40) * tileSize) - (5f * tileSize);
                Instantiate(ground2Array[Random.Range(0, ground2Array.Length)], new Vector3(currentxPos, -6*tileSize, 0), Quaternion.identity);
            }
        }
        //Génération strate3
        for (int i = 0; i < 70; i++)
        {
            if (i < 10)
            {
                currentxPos = (i * tileSize) - (5f * tileSize);
                Instantiate(ground3Array[Random.Range(0, ground3Array.Length)], new Vector3(currentxPos, -7 * tileSize, 0), Quaternion.identity);
            }
            else if (i < 20)
            {
                currentxPos = ((i - 10) * tileSize) - (5f * tileSize);
                Instantiate(ground3Array[Random.Range(0, ground3Array.Length)], new Vector3(currentxPos, -8 * tileSize, 0), Quaternion.identity);
            }
            else if (i < 30)
            {
                currentxPos = ((i - 20) * tileSize) - (5f * tileSize);
                Instantiate(ground3Array[Random.Range(0, ground3Array.Length)], new Vector3(currentxPos, -9 * tileSize, 0), Quaternion.identity);
            }
            else if (i < 40)
            {
                currentxPos = ((i - 30) * tileSize) - (5f * tileSize);
                Instantiate(ground3Array[Random.Range(0, ground3Array.Length)], new Vector3(currentxPos, -10 * tileSize, 0), Quaternion.identity);
            }
            else if(i<50)
            {
                currentxPos = ((i - 40) * tileSize) - (5f * tileSize);
                Instantiate(ground3Array[Random.Range(0, ground3Array.Length)], new Vector3(currentxPos, -11 * tileSize, 0), Quaternion.identity);
            }
            else if(i<60)
            {
                currentxPos = ((i - 50) * tileSize) - (5f * tileSize);
                Instantiate(ground3Array[Random.Range(0, ground3Array.Length)], new Vector3(currentxPos, -12 * tileSize, 0), Quaternion.identity);
            }
            else
            {
                currentxPos = ((i - 60) * tileSize) - (5f * tileSize);
                Instantiate(ground3Array[Random.Range(0, ground3Array.Length)], new Vector3(currentxPos, -13 * tileSize, 0), Quaternion.identity);
            }
        }
    }
            
}
