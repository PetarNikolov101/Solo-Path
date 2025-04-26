using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartJourney : MonoBehaviour
{
    void Start()
    {
        Button startJourneyBtn = GetComponent<Button>();
        startJourneyBtn.onClick.AddListener(StartJourneyMethod);
    }

    void StartJourneyMethod()
    {
        Debug.Log("Starting Journey...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }


}
