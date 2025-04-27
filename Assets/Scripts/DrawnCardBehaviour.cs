using UnityEngine;

public class DrawnCardBehaviour: MonoBehaviour
{
    public float moveUpLimit = 4.65f;
    public float speed = 1f;
    public float rotationLimit = 65f;
    public float rotationSpeed = 55f;
    public float moveDownLimit = 4.5f;
    public float moveDownSpeed = 0.7f;
    public float rotateBackSpeed = 70f; 
    private bool isHovered = false;
    private bool hovered_once = false; 
    private Vector3 originalPosition; 
    private Quaternion originalRotation; 
    public Light light1;
    public Light light2;
    private DeckController deckController;
    private GameObject card1;
    private GameObject card2;
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

        if (deckController != null)
        {
            card1 = deckController.card1; 
            card2 = deckController.card2; 
        }
        
    }
    
    //Tilt the card towards the camera when it's hovered
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
            if (currentXRotation > 180f) currentXRotation -= 360f; // Normalize to -180 to 180 range

            if (currentXRotation > rotationLimit)
            {
                Vector3 rotation = new Vector3(rotationSpeed, 0, 0) * Time.deltaTime;
                transform.Rotate(rotation, Space.World);
            }

            if(gameObject == card1){
                light1.intensity = 0.2f;
                lastHoveredCard = card1;
            }else {
                light2.intensity = 0.2f;
                lastHoveredCard = card2;
            }
        }
    }

    void OnMouseExit()
    {
        isHovered = false;
    }

    void Update()
    {
        if (gameObject.tag == "Drawn")
        {
            if (!isHovered && hovered_once) // Only move/rotate back if previously hovered
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

                // Move card down
                if (transform.position.y > moveDownLimit)
                {
                    Vector3 movement = Vector3.down * moveDownSpeed * Time.deltaTime;
                    transform.Translate(movement, Space.World);
                }

                // Rotate back to original rotation
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
