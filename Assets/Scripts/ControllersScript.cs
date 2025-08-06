using UnityEngine;

public class ControllersScript : MonoBehaviour
{
    
    static public GameObject healthControllerObject;
    static public GameObject deckControllerObject;
    static public GameObject inventoryController;
    static public GameObject dzingsController;

    void Start()
    {
        inventoryController = GameObject.FindWithTag("InventoryController");
        healthControllerObject = GameObject.FindWithTag("HealthController");
        deckControllerObject = GameObject.FindWithTag("DeckController");
        dzingsController = GameObject.FindWithTag("DzingsController");
    }
}
