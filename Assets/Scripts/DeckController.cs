using UnityEngine;

public class DeckController : MonoBehaviour
{
    public GameObject card1; 
    public GameObject card2; 
    public Transform slot1; 
    public Transform slot2; 
    public float moveDuration = 1f; 

    private bool hasDrawn = false;

    void OnMouseDown()
    {
        if (!hasDrawn)
        {
            hasDrawn = true;
            MoveCard(card1, slot1.position);
            MoveCard(card2, slot2.position, 1f); // delay
        }
    }

    void MoveCard(GameObject card, Vector3 targetPosition, float delay = 0f)
    {
        StartCoroutine(MoveCardCoroutine(card, targetPosition, delay));
    }

    System.Collections.IEnumerator MoveCardCoroutine(GameObject card, Vector3 targetPosition, float delay)
    {
        yield return new WaitForSeconds(delay);

        float elapsedTime = 0f;
        Vector3 startPosition = card.transform.position;
        Quaternion startRotation = card.transform.rotation;
        Quaternion targetRotation = Quaternion.identity; // Adjust if slots have specific rotations

        while (elapsedTime < moveDuration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / moveDuration;
            t = t * t * (3f - 2f * t); // Smoothstep
            card.transform.position = Vector3.Lerp(startPosition, targetPosition, t);
            card.transform.rotation = Quaternion.Lerp(startRotation, targetRotation, t);
            yield return null;
        }

        // Ensure final position is exact
        card.transform.position = targetPosition;
        card.transform.rotation = targetRotation;
    }
}