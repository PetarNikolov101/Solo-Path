using UnityEngine;
using UnityEngine.UI;

public class Quit : MonoBehaviour
{
    void Start()
    {
        //click event listener
        Button quitButton = GetComponent<Button>();
        quitButton.onClick.AddListener(QuitGame);
    }

    void QuitGame()
    {
        Debug.Log("Quitting game...");
        Application.Quit();
    }
}