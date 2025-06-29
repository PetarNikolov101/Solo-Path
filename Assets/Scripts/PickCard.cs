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
    public Light lightAbovePickedCard;
    public Transform frontOfCamera;

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
        if (transform.tag == "Drawn")
        {
            if (gameObject == card1)
            {
                MoveCardToDiscard(card2, discardPile.position, discardPile.rotation, 0.2f);
                card2.tag = "Discarded";
                card2.GetComponent<Renderer>().material.shader = Shader.Find("Custom/Desaturate");
            }
            else if (gameObject == card2)
            {
                MoveCardToDiscard(card1, discardPile.position, discardPile.rotation, 0.2f);
                card1.tag = "Discarded";
            }
            gameObject.tag = "Picked";
            MoveCardToScreen(gameObject, frontOfCamera.position, Quaternion.Euler(761, 182, 361), 0.4f);
        }
    }

    System.Collections.IEnumerator MoveCardToDiscardCoroutine(GameObject card, Vector3 targetPosition, float delay)
    {
        yield return new WaitForSeconds(delay);
        float elapsedTime = 0f;
        Vector3 startPosition = card.transform.position;
        Quaternion startRotation = card.transform.rotation;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / moveDuration;
            t = t * t * (3f - 2f * t); // smoothstep
            card.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            card.transform.rotation = Quaternion.Lerp(startRotation, Quaternion.Euler(90, 180, 0), t);
            yield return null;
        }

        card.transform.position = targetPosition;
    }

    System.Collections.IEnumerator MoveCardToScreenCoroutine(GameObject card, Vector3 targetPosition, Quaternion targetRotation, float delay)
    {
        yield return new WaitForSeconds(delay);
        lightAbovePickedCard.intensity = 0.7f;

        float elapsedTime = 0f;
        Vector3 startPosition = card.transform.position;
        Quaternion startRotation = card.transform.rotation;

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / moveDuration;
            t = t * t * (3f - 2f * t); // smoothstep
            card.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            yield return null;
        }

        card.transform.position = targetPosition;
        card.transform.rotation = targetRotation;
    }



    void MoveCardToScreen(GameObject card, Vector3 targetPosition, Quaternion targetRotation, float delay = 0f)
    {
        StartCoroutine(MoveCardToScreenCoroutine(card, targetPosition, targetRotation, delay));
    }

    void MoveCardToDiscard(GameObject card, Vector3 targetPosition, Quaternion targetRotation, float delay = 0f)
    {
        StartCoroutine(MoveCardToDiscardCoroutine(card, targetPosition, delay));
    }

    void Update()
    {
        if (deckController != null)
        {
            card1 = deckController.card1;
            card2 = deckController.card2;
        }
    }
}