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
        // je divise mes points d'upgrade par mon pointMultiplier car il sera annulé par le passage a PointAmount
        pointIncrement += pointUpgradeAmount/pointMultiplier;
        Debug.Log(pointAmount);
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
    public void StopPointCounter()
    {
        playerMoving = false;
    }
}
