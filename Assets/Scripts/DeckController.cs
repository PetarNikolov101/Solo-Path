using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class DeckController : MonoBehaviour
{
    public Transform slot1; 
    public Transform slot2; 
    public float moveDuration = 0.3f; 
    private List<GameObject> availableCards = new List<GameObject>();
    private bool hasDrawn = false;
    private string cardTag = "Undrawn"; 
    public GameObject card1;
    public GameObject card2; 

    void Start()
    {
        availableCards = GameObject.FindGameObjectsWithTag(cardTag).ToList();
    }
    void OnMouseDown()
    {
        if (!hasDrawn && availableCards.Count >= 1)
        {
            hasDrawn = true;
            List<GameObject> selectedCards = PickRandomCards(2);
            card1 = selectedCards[0];
            card2 = selectedCards[1];
            //Move the cards to their slots
            MoveCard(card1, slot1.position, slot1.rotation);//SMENI CARD1
            MoveCard(card2, slot2.position, slot2.rotation, 0.35f); // Delay for second card

            //Tag the cards as drawn
            card1.tag = "Drawn";
            card2.tag = "Drawn"; //KOMENTIRAJ
            selectedCards[1].tag = "Drawn";
        }
        else if (availableCards.Count < 1)
        {
            Debug.LogWarning("You won!");
        }
    }

    List<GameObject> PickRandomCards(int count)
    {
        List<GameObject> pickedCards = new List<GameObject>();
        List<GameObject> tempList = new List<GameObject>(availableCards); // Copy to avoid modifying original

        for (int i = 0; i < count && tempList.Count > 0; i++)
        {
            int randomIndex = Random.Range(0, tempList.Count);
            pickedCards.Add(tempList[randomIndex]);
            tempList.RemoveAt(randomIndex); // Remove to avoid picking the same card twice
            availableCards.Remove(pickedCards[i]); // Remove from available cards
        }

        return pickedCards;
    }
    void MoveCard(GameObject card, Vector3 targetPosition, Quaternion targetRotation, float delay = 0f)
    {
        StartCoroutine(MoveCardCoroutine(card, targetPosition, targetRotation, delay));
    }

    System.Collections.IEnumerator MoveCardCoroutine(GameObject card, Vector3 targetPosition, Quaternion targetRotation, float delay)
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
}