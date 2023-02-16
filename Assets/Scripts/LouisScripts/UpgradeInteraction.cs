using UnityEngine;

public class UpgradeInteraction : MonoBehaviour
{
    public RootData datar;
    FogOfWar fogOfWar;
    PointCounter pointCounter;
    void Start()
    {
        fogOfWar = FindObjectOfType<FogOfWar>();
        pointCounter = FindObjectOfType<PointCounter>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        pointCounter.AddUpgradePoint();
        if (collision.gameObject.tag == "water")
        {
            datar.currentPointLimit += 2;
            datar.currentRessource += 1;
            Debug.Log("c2lo");
            fogOfWar.MakeHole(collision.gameObject.transform.position, (datar.sightDistance * 3));
            Debug.Log("PointLimit");
        }
        if (collision.gameObject.tag == "mushrooms")
        {
            datar.currentSightDistance += 0.5f;
            datar.currentRessource += 1;
            fogOfWar.MakeHole(collision.gameObject.transform.position, (datar.sightDistance * 3));
        }
        if (collision.gameObject.tag == "azote")
        {
            datar.currentTurnSpeed += 2f;
            datar.currentRessource += 1;
            fogOfWar.MakeHole(collision.gameObject.transform.position, (datar.sightDistance * 3));
        }
    }
}
