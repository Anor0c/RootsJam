using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointManager : MonoBehaviour
{
    [SerializeField] int pointMultiplier;
    int totalPoints;
    int finalDistance;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //récupérer la true total distance
    // et l'ajouter à la distance final.

    
    
    
    public void PointAddition(int currentRootPoint)
    {
        totalPoints += currentRootPoint;
        finalDistance = totalPoints * pointMultiplier;
    }

    //public void OnGameOver
}
