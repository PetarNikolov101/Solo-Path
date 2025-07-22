using UnityEngine;

public class DrawnCardBehaviour: MonoBehaviour
{
    public float moveUpLimit = 4.65f;
    public float speed = 1f;
    public float rotationLimit = 65f;
    public float rotationSpeed = 55f;
    public float moveDownLimit = 4.6f;
    public float moveDownSpeed = 0.7f;
    public float rotateBackSpeed = 70f; 
    private bool isHovered = false;
    private bool hovered_once = false; 
    private Vector3 originalPosition; 
    private Quaternion originalRotation; 
    public Light light1;
    public Light light2;
    public Light light3;
    private DeckController deckController;
    private GameObject card1;
    private GameObject card2;
    private GameObject card3;
    private GameObject lastHoveredCard;

    [System.Obsolete]
    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
        if (deckController == null)
        {
            deckController = FindObjectOfType<DeckController>();
        }
        
    }
    
    //tilt the card towards the camera when it's hovered
     void OnMouseOver()
    {
        isHovered = true;
        hovered_once = true;
        if(gameObject.tag == "Drawn")
        {
            if(transform.position.y < moveUpLimit){
                Vector3 movement = Vector3.up * speed * Time.deltaTime; 
                transform.Translate(movement, Space.World); 
            }

            float currentXRotation = transform.eulerAngles.x;
            if (currentXRotation > 180f) currentXRotation -= 360f; // normalize to -180 to 180 range

            if (currentXRotation > rotationLimit)
            {
                Vector3 rotation = new Vector3(rotationSpeed, 0, 0) * Time.deltaTime;
                transform.Rotate(rotation, Space.World);
            }

            if(gameObject == card1){
                light1.intensity = 0.2f;
                lastHoveredCard = card1;
            }else if(gameObject == card2){
                light2.intensity = 0.2f;
                lastHoveredCard = card2;
            }else if(gameObject == card3){
                light3.intensity = 0.2f;
                lastHoveredCard = card3;
            }
        }
    }

    void OnMouseExit()
    {
        isHovered = false;
    }

    void Update()
    {
        if (deckController != null)
        {
            card1 = deckController.card1;
            card2 = deckController.card2;
            if (deckController.card3 != null)
            {
                card3 = deckController.card3;
            }
            else
            {
                card3 = null;
            }
        }
        if (gameObject.tag == "Drawn")
        {
            if (!isHovered && hovered_once) // only move/rotate back if previously hovered
            {
                //lights!
                if (light1.intensity > 0 && lastHoveredCard == card1)
                {
                    light1.intensity = 0;
                }
                else if (light2.intensity > 0 && lastHoveredCard == card2)
                {
                    light2.intensity = 0;
                }
                else if (light3.intensity > 0 && lastHoveredCard == card3)
                {
                    light3.intensity = 0;
                }

                // move card down
                if (transform.position.y > moveDownLimit)
                {
                    Vector3 movement = Vector3.down * moveDownSpeed * Time.deltaTime;
                    transform.Translate(movement, Space.World);
                }

                // rotate back to original rotation
                if (transform.rotation != originalRotation)
                {
                    transform.rotation = Quaternion.RotateTowards(
                        transform.rotation,
                        originalRotation,
                        rotateBackSpeed * Time.deltaTime
                    );
                }
            }
        }
    }
}
