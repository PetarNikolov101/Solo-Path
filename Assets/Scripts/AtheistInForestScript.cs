using UnityEngine;

public class AtheistInForestScript : Card
{

    public void Start()
    {
        inventoryController = GameObject.FindWithTag("InventoryController");
        healthControllerObject = GameObject.FindWithTag("HealthController");
        dc = 3; 
    }

    public override void Success()
    {
        inventoryController.GetComponent<Inventory>().addToInventory("Bible of Atheism");
    }

    public override void Fail()
    {
        if(inventoryController.GetComponent<Inventory>().checkInventory("Bark of Lament"))
        {
            healthControllerObject.GetComponent<HealthController>().LoseHealth(3);
        }
        
    }

}
