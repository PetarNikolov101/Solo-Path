using UnityEngine;

public class FourEnterancesScript : Card
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dc = 4; // Minimum roll needed to succeed
    }

    public override void Fail()
    {
        ControllersScript.healthControllerObject.GetComponent<HealthController>().LoseHealth(4);
        ControllersScript.deckControllerObject.GetComponent<DeckController>().drawThree = true;
    }

    public override void Success()
    {
        ControllersScript.dzingsController.GetComponent<DzingsController>().gainDzing(4);
        ControllersScript.deckControllerObject.GetComponent<DeckController>().drawOne = true;
    }
}
