using System.Linq;
using UnityEngine;

abstract public class Card: MonoBehaviour
{
    protected int dc; //dice check value, minimyum roll needed to succeed
    public abstract void Fail();
    public abstract void Success();
    protected ControllersScript controllersScript = new ControllersScript();

    public void CheckSuccessOrFail(int roll)
    {
        if (roll >= dc)
        {
            Success();
        }
        else
        {
            Fail();
        }
    }
}