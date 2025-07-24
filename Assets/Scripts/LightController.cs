using UnityEngine;

public class LightController : MonoBehaviour
{
    public int currentLight = 0;
    public void GainLight(int amount)
    {
        currentLight += amount;
    }

    public void LoseLight(int amount)
    {
        currentLight -= amount;
    }
}
