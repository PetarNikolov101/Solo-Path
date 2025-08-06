using UnityEngine;

public class OneEyedTree : Card
{
    public void Start()
    {
        dc = 3; // Minimum roll needed to succeed
        
    }

    public override void Fail()
    {
        ControllersScript.inventoryController.GetComponent<Inventory>().addToInventory("Bark of Lament");
    }

    public override void Success()
    {
        ControllersScript.inventoryController.GetComponent<Inventory>().addToInventory("Bark of Knowledge");
    }
}