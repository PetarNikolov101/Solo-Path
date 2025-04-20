using UnityEngine;
using UnityEngine.UI;

public class OpenLink : MonoBehaviour
{
    [SerializeField] private string url = "https://www.galacticomnivore.com/"; 
    void Start()
    {
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OpenURL);
    }

    void OpenURL()
    {
        Debug.Log($"Opening URL: {url}");
        Application.OpenURL(url);
    }
}