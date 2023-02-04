using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RootData", menuName = "WanderRoot/Root Data")]
public class RootData : ScriptableObject
{
    public void OnEnable()
    {
        currentSpeed = Mathf.Sqrt(moveSpeed * 3);
        currentSightDistance = sightDistance;
        currentTurnSpeed = turnSpeed;
        currentPointLimit = pointLimit;
        currentRessource = ressource;
        currentSegmentDistance = SegmentDistance;
    }

    [Header("Movement")]
    public float moveSpeed;
    [HideInInspector] public float currentSpeed;
    public float turnSpeed;
    [HideInInspector] public float currentTurnSpeed;

    [Header("Spline")]
    public int pointLimit;
    [HideInInspector] public int currentPointLimit;

    [Header("FogOfWar")]
    public float sightDistance;
    [HideInInspector] public float currentSightDistance;

    [Header("Score")]
    public int ressource;
    [HideInInspector] public int currentRessource;
    [HideInInspector] public int currentSegmentDistance;
    public int SegmentDistance;
    public int finalDistance;
    [HideInInspector] public int currentFinalDistance;

   [Header("SpawnValue")]
   public Vector3

}
