using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public TextMeshProUGUI pointUI;
    [SerializeField] MovementPlayer activeHead;

    [SerializeField] bool playerMoving;
    [SerializeField] float pointMultiplier;

     float pointIncrement;
    [SerializeField] int pointUpgradeAmount;
    [SerializeField] int pointAmount;

    void Update()
    {
        if (!playerMoving)
            return;

        pointIncrement++;
        pointAmount = Mathf.FloorToInt(pointIncrement * pointMultiplier);
        pointUI.text = pointAmount + " points";
    }
    public void AddUpgradePoint()
    {
        Debug.Log("BonusPoint");
        pointAmount += pointUpgradeAmount;
    }
    public void SearchForNewHead()
    {
        activeHead = FindObjectOfType<MovementPlayer>();
        playerMoving = activeHead.isMoving;
    }
    public void CheckIsMoving()
    {
        playerMoving = activeHead.isMoving;
    }
}
