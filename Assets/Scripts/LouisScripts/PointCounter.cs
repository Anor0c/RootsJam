using UnityEngine;
using TMPro;

public class PointCounter : MonoBehaviour
{
    public TextMeshProUGUI pointUI;
    [SerializeField] MovementPlayer activeHead;

    int pointAmount;
    void Start()
    {
        
    }


    void Update()
    {

        pointUI.text =  pointAmount + " points";
    }
}
