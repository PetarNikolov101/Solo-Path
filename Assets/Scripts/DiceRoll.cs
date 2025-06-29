using UnityEngine;

public class DiceRoll : MonoBehaviour
{
    int target;
    public int Target
    {
        get { return target; }
        set { target = value; }
    }

    // roll
    public int RollDice()
    {
        return Random.Range(1, 7); // Returns a random number between 1 and 6
    }

    public bool getFailOrSuccess(int roll, int target)
    {
        if (roll >= target)
        {
            return true;
        }   
        else
        {
            return false;
        }
    }
}
