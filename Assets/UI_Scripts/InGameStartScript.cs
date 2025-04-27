using System.Collections;
using UnityEngine;

public class InGameStartScript : MonoBehaviour
{
    public FadeInOut fade;
    void Start()
    {
        fade.FadeOut(); 
    }
}
