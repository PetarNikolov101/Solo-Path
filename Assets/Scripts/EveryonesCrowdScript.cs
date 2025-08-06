using UnityEngine;

public class EveryonesCrowdScript : Card
{
    public override void Fail()
    {
        ControllersScript.healthControllerObject.GetComponent<HealthController>().LoseHealth(5);
    }

    public override void Success()
    {
        if (ControllersScript.inventoryController.GetComponent<Inventory>().checkInventory("Jester's Crutch")){
            ControllersScript.dzingsController.GetComponent<DzingsController>().gainDzing(5);
        }
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        dc = 4;
    }
}
