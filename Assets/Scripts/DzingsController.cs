using UnityEngine;
using TMPro;

public class DzingsController : MonoBehaviour
{
    public int currentDzings = 0;
    public TextMeshProUGUI dzingsText;

    void gainDzing(int amount)
    {
        currentDzings += amount;
        UpdateDzingsText();
    }

    void loseDzing(int amount)
    {
        currentDzings -= amount;
        UpdateDzingsText();
    }

    void UpdateDzingsText()
    {
        dzingsText.text = currentDzings.ToString();
    }

}
