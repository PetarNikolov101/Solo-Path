using TMPro;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public TextMeshProUGUI healthText;
    public int currentHealth = 20;
    public void LoseHealth(int amount)
    {
        Debug.Log("Health lost: " + amount);
        currentHealth -= amount;
        UpdateHealthText();
    }
    public void GainHealth(int amount)
    {
        Debug.Log("Health gained: " + amount);
        currentHealth += amount;
        UpdateHealthText();
    }
    public void UpdateHealthText()
    {
        healthText.text = currentHealth.ToString();
    } 

    public int getHealth()
    {
        return currentHealth;
    }  
}
