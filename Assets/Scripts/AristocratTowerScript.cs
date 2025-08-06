using UnityEngine;

public class AristocratTowerScript : Card
{
    void Start()
    {
        dc = 3;
    }
    public override void Fail()
    {
        Debug.Log("Game Over");
    }
    
    public override void Success()
    {
        ControllersScript.dzingsController.GetComponent<DzingsController>().gainDzing(3);
        ControllersScript.deckControllerObject.GetComponent<DeckController>().drawThree = true;
    }
}
