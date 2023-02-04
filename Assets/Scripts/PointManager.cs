using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PointManager : MonoBehaviour
{
    int totalPoints;
    int totalResources;
    public RootData datar;
    
    public void PointAddition()
    {
        totalPoints += datar.currentPointLimit;
        datar.currentFinalDistance = totalPoints * datar.currentSegmentDistance;
        totalResources = datar.currentRessource;
    }

    
}
