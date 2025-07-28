using UnityEngine;

public class AristocratTowerScript : Card
{
    void Start()
    {
        deckControllerObject = GameObject.FindWithTag("DeckController");
        dzingsController = GameObject.FindWithTag("DzingsController");
        dc = 3;
    }
    public override void Fail()
    {
        Debug.Log("Game Over");
    }
    
    public override void Success()
    {
        dzingsController.GetComponent<DzingsController>().gainDzing(3);
        deckControllerObject.GetComponent<DeckController>().drawThree = true;
    }
}
