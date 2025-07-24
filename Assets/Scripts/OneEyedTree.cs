using UnityEngine;

public class OneEyedTree : Card
{
    public void Start()
    {
        dc = 3; // Minimum roll needed to succeed
        cardName = "One Eyed Tree";
        inventoryController = GameObject.FindWithTag("InventoryController");
    }

    public override void Fail()
    {
        inventoryController.GetComponent<Inventory>().addToInventory("Bark of Lament");
    }

    public override void Success()
    {
        inventoryController.GetComponent<Inventory>().addToInventory("Bark of Knowledge");
    }
}