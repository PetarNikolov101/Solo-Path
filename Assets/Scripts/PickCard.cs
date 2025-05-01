using UnityEngine;

public class PickCard : MonoBehaviour
{
    private GameObject card1;
    private GameObject card2;
    public Transform discardPile;
    private DeckController deckController;
    public float moveDuration = 0.3f;
    private Vector3 originalPosition;
    private Quaternion originalRotation;

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
    void OnMouseDown()
    {
        Debug.Log("Card clicked: " + gameObject.name);
        if(transform.tag == "Drawn")
        {
            Debug.Log("Is drawn: " + gameObject.name);
            if(gameObject == card1)
            {
                Debug.Log("Card 1 clicked");
                MoveCardToDiscard(card2, discardPile.position,originalRotation, 0.2f);
                card2.tag="Discarded";
            }
            else if(gameObject == card2)
            {
                Debug.Log("Card 2 clicked");
                MoveCardToDiscard(card1, discardPile.position, originalRotation, 0.2f);
                card1.tag="Discarded";
            }
            MoveCardToScreen(gameObject, transform.position, transform.rotation, 0.4f);
        }
    }


    //Moving card scripts start here
    System.Collections.IEnumerator MoveCardToDiscardCoroutine(GameObject card, Vector3 targetPosition, Quaternion targetRotation, float delay)
    {
        yield return new WaitForSeconds(delay);
        float elapsedTime = 0f;
        Vector3 startPosition = card.transform.position;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / moveDuration;
            t = t * t * (3f - 2f * t); // Smoothstep
            card.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        // Ensure final position and rotation are exact
        card.transform.position = targetPosition;
        card.transform.rotation = targetRotation;
    }

    System.Collections.IEnumerator MoveCardToScreenCoroutine(GameObject card, Vector3 targetPosition, Quaternion targetRotation, float delay)
    {
        yield return new WaitForSeconds(delay);
    }

    void MoveCardToScreen(GameObject card, Vector3 targetPosition, Quaternion targetRotation, float delay = 0f)
    {
        StartCoroutine(MoveCardToScreenCoroutine(card, targetPosition, targetRotation, delay));
    }
    void MoveCardToDiscard(GameObject card, Vector3 targetPosition, Quaternion targetRotation, float delay = 0f)
    {
        StartCoroutine(MoveCardToDiscardCoroutine(card, targetPosition, targetRotation, delay));
    }
    //Moving card scripts end here

    void Update()
    {
        if (deckController != null)
        {
            card1 = deckController.card1; 
            card2 = deckController.card2; 
        }
    }
}
