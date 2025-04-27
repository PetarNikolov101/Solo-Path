using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeToIntroScene : MonoBehaviour
{
    void Start()
    {
        StartCoroutine(LoadScene());
    }

    public IEnumerator LoadScene(){
        yield return new WaitForSeconds(17f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex+1);
    }

}
