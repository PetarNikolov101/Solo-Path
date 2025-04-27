using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartJourney : MonoBehaviour
{
    FadeInOut fade;
    void Start()
    {
        fade = FindAnyObjectByType<FadeInOut>();
        Button startJourneyBtn = GetComponent<Button>();
        startJourneyBtn.onClick.AddListener(StartJourneyMethod);
    }

    public IEnumerator FadeAndLoadScene(){
        fade.FadeIn();
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

    void StartJourneyMethod()
    {
        StartCoroutine(FadeAndLoadScene());
    }
}
