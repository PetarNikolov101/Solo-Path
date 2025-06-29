using UnityEngine;

public class CardFlip : MonoBehaviour
{
    private bool isFlipped = true;
    private bool isRotating = false;

    public float flipDuration = 0.5f; 

    private Quaternion startRotation;
    private Quaternion endRotation;

    void OnMouseDown()
    {
        if (!isRotating)
        {
            StartCoroutine(FlipCard());
        }
    }

    System.Collections.IEnumerator FlipCard()
    {
        isRotating = true;

        float time = 0f;
        startRotation = transform.rotation;

        if (!isFlipped)
        {
            endRotation = Quaternion.Euler(-37.104f, 363.659f, -1.515f);
        }
        else
        {
            endRotation = Quaternion.Euler(41f, 182f, 1f);
        }

        while (time < flipDuration)
        {
            transform.rotation = Quaternion.Slerp(startRotation, endRotation, time / flipDuration);
            time += Time.deltaTime;
            yield return null;
        }

        transform.rotation = endRotation;
        isFlipped = !isFlipped;
        isRotating = false;
    }
}