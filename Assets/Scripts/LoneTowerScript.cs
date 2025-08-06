using UnityEngine;

public class LoneTowerScript : Card
{

    public void Start()
    {
        dc = 4;
    }

    public override void Fail()
    {
        
        ControllersScript.healthControllerObject.GetComponent<HealthController>().LoseHealth(5);
        
    }

    public override void Success()
    {
        
        ControllersScript.deckControllerObject.GetComponent<DeckController>().drawThree = true;
        
    }
}