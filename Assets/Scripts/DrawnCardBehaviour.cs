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

    void Start()
    {
        originalPosition = transform.position;
        originalRotation = transform.rotation;
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
                Debug.Log("Moving card up, new Y: " + transform.position.y);
            }

            float currentXRotation = transform.eulerAngles.x;
            if (currentXRotation > 180f) currentXRotation -= 360f; // Normalize to -180 to 180 range

            if (currentXRotation > rotationLimit)
            {
                Vector3 rotation = new Vector3(rotationSpeed, 0, 0) * Time.deltaTime;
                transform.Rotate(rotation, Space.World);
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
                // Move card down
                if (transform.position.y > moveDownLimit)
                {
                    Vector3 movement = Vector3.down * moveDownSpeed * Time.deltaTime;
                    transform.Translate(movement, Space.World);
                    Debug.Log("Moving card down, new Y: " + transform.position.y);
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
