using UnityEngine;

public class AtheistInForestScript : Card
{

    public void Start()
    {
        dc = 3; 
    }

    public override void Success()
    {
        ControllersScript.inventoryController.GetComponent<Inventory>().addToInventory("Bible of Atheism");
    }

    public override void Fail()
    {
        if(ControllersScript.inventoryController.GetComponent<Inventory>().checkInventory("Bark of Lament"))
        {
            ControllersScript.healthControllerObject.GetComponent<HealthController>().LoseHealth(3);
        }
        
    }

}
