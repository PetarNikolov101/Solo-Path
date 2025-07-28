using UnityEngine;
using UnityEngine.UI;
public class DiceRoll : MonoBehaviour
{
    int roll;
    GameObject card;
    public GameObject dice;
    public TMPro.TextMeshProUGUI rollText;

    void Start()
    {
        Button button = dice.GetComponent<Button>();
        button.onClick.AddListener(CallCardScript);
    }
    void Update()
    {
        card = GameObject.FindWithTag("Picked");
    }
    
    // roll the dice when the card is clicked, and call the appropriate method based on the card and roll result
    public void CallCardScript()
    {
        Debug.Log("Dice clicked");
        if (dice.tag == "NotRolled")
        {
            RollDice();
            if (card == null)
            {
                Debug.LogError("No card with tag 'Picked' found!");
                return;
            }
            switch (card.name)
            {
                case "Lone Tower":
                    card.GetComponent<LoneTowerScript>().CheckSuccessOrFail(roll);
                    break;
                case "Atheist in Forest":
                    card.GetComponent<AtheistInForestScript>().CheckSuccessOrFail(roll);
                    break;
                case "One Eyed Tree":
                    card.GetComponent<OneEyedTree>().CheckSuccessOrFail(roll);
                    break;
                case "Aristocrats Tower":
                    card.GetComponent<AristocratTowerScript>().CheckSuccessOrFail(roll);
                    break;
            }
            dice.tag = "Rolled";
        }
    }

    // roll dice function
    public void RollDice()
    {
        roll = Random.Range(1, 7);
        rollText.text = roll.ToString();
    }

}
