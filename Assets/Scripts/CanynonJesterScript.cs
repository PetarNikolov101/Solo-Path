using UnityEngine;

public class CanynonJesterScript : Card
{
    public void Start()
    {
        dc = 3;
    }
    public override void Fail()
    {
        ControllersScript.healthControllerObject.GetComponent<HealthController>().LoseHealth(5);
        ControllersScript.inventoryController.GetComponent<Inventory>().addToInventory("Jester's Stick");
    }

    public override void Success()
    {
        if (ControllersScript.inventoryController.GetComponent<Inventory>().checkInventory("Wooden Cane"))
        {
            ControllersScript.dzingsController.GetComponent<DzingsController>().gainDzing(5);
            ControllersScript.inventoryController.GetComponent<Inventory>().addToInventory("Jester's Crutch");
        }
    }
}
