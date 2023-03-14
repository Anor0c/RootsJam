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
    [SerializeField] int ScoreShown;

    void Update()
    {
        if (!playerMoving)
            return;

        pointIncrement++;
        ScoreShown = Mathf.FloorToInt(pointIncrement * pointMultiplier);
        pointUI.text = ScoreShown + " points";
    }
    public void AddUpgradePoint()
    {
        // Dividing UpgradeAmount by Point Multiplier cuz it cancels out line 22
        pointIncrement += pointUpgradeAmount/pointMultiplier;
        Debug.Log(ScoreShown);
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
