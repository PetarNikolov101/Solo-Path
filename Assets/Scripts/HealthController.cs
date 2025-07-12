using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public int currentHealth = 20;
    void LoseHealth(int amount)
    {
        Debug.Log("Health lost: " + amount);
        currentHealth -= amount;
        UpdateHealthText();
    }
    void GainHealth(int amount)
    {
        Debug.Log("Health gained: " + amount);
        currentHealth += amount;
        UpdateHealthText();
    }
    void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
    }   
}
