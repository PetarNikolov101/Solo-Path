using UnityEngine;

public class CanynonJesterScript : Card
{
    public void Start()
    {
        dc = 3;
        dzingsController = GameObject.FindWithTag("DzingsController");
        inventoryController = GameObject.FindWithTag("InventoryController");
        healthControllerObject = GameObject.FindWithTag("HealthController");
    }
    public override void Fail()
    {
        healthControllerObject.GetComponent<HealthController>().LoseHealth(5);
        inventoryController.GetComponent<Inventory>().addToInventory("Jester's Stick");
    }

    public override void Success()
    {
        if (inventoryController.GetComponent<Inventory>().checkInventory("Wooden Cane"))
        {
            dzingsController.GetComponent<DzingsController>().gainDzing(5);
            inventoryController.GetComponent<Inventory>().addToInventory("Jester's Crutch");
        }
    }
}
