using System.Linq;
using UnityEngine;

abstract public class Card : MonoBehaviour
{
    protected string cardName;
    protected GameObject healthControllerObject;
    protected GameObject deckControllerObject;
    protected int dc; //dice check value, minimyum roll needed to succeed

    public abstract void Fail();
    public abstract void Success();

}