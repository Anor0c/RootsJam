using TMPro;
using UnityEngine;

public class HealthCounter : MonoBehaviour
{
    public TextMeshProUGUI lifeHUD;
    SpawnRoots spawner;
    int lifeNumber;
    void Start()
    {
        spawner = FindObjectOfType<SpawnRoots>();
        lifeNumber = spawner.lifeCounter;
        lifeHUD.text = lifeNumber + "Lives Left";
    }

    public void ChangeLifeHUD()
    {
        lifeNumber--;
        lifeHUD.text= lifeNumber + "Lives Left";
    }
}
