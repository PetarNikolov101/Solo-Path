using UnityEngine;

public class DrawnCardBehaviour: MonoBehaviour
{
     void OnMouseOver()
    {
        if(gameObject.tag == "Drawn")
        {
            // Add your logic here for when the mouse is over a drawn card
            Debug.Log("Mouse is over a drawn card.");
        }
    }
}
