using UnityEngine;

public class DruidLeavesScript : Card
{
    void Start()
    {
        inventoryController = GameObject.FindWithTag("InventoryController");
        healthControllerObject = GameObject.FindWithTag("HealthController");
        dzingsController = GameObject.FindWithTag("DzingsController");
        dc = 4; // Minimum roll needed to succeed
    }
    public override void Fail()
    {
        if (inventoryController.GetComponent<Inventory>().checkInventory("Bark of Lament"))
        {
            dzingsController.GetComponent<DzingsController>().gainDzing(5);
        }else healthControllerObject.GetComponent<HealthController>().LoseHealth(4);
    }

    public override void Success()
    {
        dzingsController.GetComponent<DzingsController>().gainDzing(5);
    }

}
