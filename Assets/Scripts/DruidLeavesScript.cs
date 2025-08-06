using UnityEngine;

public class DruidLeavesScript : Card
{
    void Start()
    {
        
        dc = 4; // Minimum roll needed to succeed
    }
    public override void Fail()
    {
        if (ControllersScript.inventoryController.GetComponent<Inventory>().checkInventory("Bark of Lament"))
        {
            ControllersScript.dzingsController.GetComponent<DzingsController>().gainDzing(5);
        }else ControllersScript.healthControllerObject.GetComponent<HealthController>().LoseHealth(4);
    }

    public override void Success()
    {
        ControllersScript.dzingsController.GetComponent<DzingsController>().gainDzing(5);
    }

}
