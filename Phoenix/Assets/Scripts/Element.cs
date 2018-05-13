using System;
using Assets.Scripts;
using UnityEngine;
[CreateAssetMenu(fileName = "Element", menuName = "Element")]
public class Element
{
    public Action<Character> DrawbackFunc;
    public ElementTypes ElementType;

    public Element()
    {
        DrawbackFunc = DrawbackAssistant.GetDrawback(ElementType);
    }
    public void ApplyDrawback(Character character)
    {
        DrawbackFunc(character);
    }
}
public enum ElementTypes
{
    Ice, Fire, Earth, Wood, Air, Water, All, None
}

public static class DrawbackAssistant
{
    public static Action<Character> GetDrawback(ElementTypes elementType)
    {
        switch (elementType)
        {
            case ElementTypes.Ice:
                return IceDrawback;
                break;
            case ElementTypes.Fire:
                break;
            case ElementTypes.Earth:
                break;
            case ElementTypes.Wood:
                break;
            case ElementTypes.Air:
                break;
            case ElementTypes.Water:
                break;
            case ElementTypes.All:
                break;
            case ElementTypes.None:
                break;
            default:
                throw new ArgumentOutOfRangeException(elementType.GetType().Name, elementType, null);
        }
        return null;
    }

    private static void IceDrawback(Character character)
    {
        Debug.Log("Ice baby, Ice");
        character.Buffs.AddBuff(new Buff(), character, 3);
    }
}