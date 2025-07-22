using UnityEngine;

public class LoneTowerScript : Card
{

    public void Start()
    {
        dc = 4;
        cardName = "Lone Tower";
        healthControllerObject = GameObject.FindWithTag("HealthController");
        deckControllerObject = GameObject.FindWithTag("DeckController");
    }

    public override void Fail()
    {
        HealthController healthController = healthControllerObject.GetComponent<HealthController>();
        if (healthController != null)
        {
            healthController.LoseHealth(5);
        }
        else
        {
            Debug.LogError("Nema HealthController");
        }
        Debug.Log(healthController.getHealth());
    }

    public override void Success()
    {
        DeckController deckController = deckControllerObject.GetComponent<DeckController>();
        if (deckController != null)
        {
            deckController.drawThree = true;
        }
        else
        {
            Debug.LogError("Nema DeckController");
        }
        Debug.Log(deckController.drawThree);
    }
}