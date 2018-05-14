using System;
using Assets.Scripts;
using UnityEngine;
public class Element
{
    public Action<Character,Skill> DrawbackFunc;
    public ElementTypes ElementType;
    public Color AreaColor;

    public Element(ElementTypes eType)
    {
        ElementType = eType;
        Color tempColor;
        DrawbackFunc = DrawbackAssistant.GetDrawback(ElementType,out tempColor);
        AreaColor = tempColor;
    }
    public void ApplyDrawback(Character character,Skill skill)
    {
        DrawbackFunc(character,skill);
    }
}
public enum ElementTypes
{
    Ice, Fire, Earth, Wood, Air, Water, All, None
}

public static class DrawbackAssistant
{
    public static Action<Character,Skill> GetDrawback(ElementTypes elementType,out Color color)
    {
        switch (elementType)
        {
            case ElementTypes.Ice:
                color =RGBToColor(165f,242f,243f);
                return IceDrawback;
            case ElementTypes.Fire:
                color = RGBToColor(246f,40f,23f);
                return FireDrawback;
            case ElementTypes.Earth:
                color = RGBToColor(133, 87, 35);
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
        color = Color.white;
        return null;
    }

    private static Color RGBToColor(float r, float g, float b)
    {
        return new Color(r/255f,g/255f,b/255f,0.2f);
    } 
    private static void FireDrawback(Character character, Skill skill)
    {
        var multiplier = 0.02f;
        if (skill.DealingDamage == skill.Damage.Minimum)
        {
            multiplier = 0.05f;
        }
        Debug.Log("Firewalk With me\nHealth :"+character.Health);
        character.Health -= (float)Math.Floor(character.CurrentEnemy.Health * multiplier);
        Debug.Log("Health:"+character.Health);
    }

    private static void IceDrawback(Character character,Skill skill)
    {
        Debug.Log("Ice baby, Ice");
        var baseSpeed = character.CurrentSpeed;
        character.CurrentSpeed = 0;
        var time = 3f;
        if (skill.DealingDamage == skill.Damage.Minimum)
        {
            time = 4.5f;
        }
        if (time > 0)
        {
            TimerControl timer = new TimerControl(time, c =>
            {
                character.CurrentSpeed = baseSpeed;
            }, character);
        }
        //var buff = new Buff{Amount = -1,BuffType = BuffType.Speed,Skill = skill};
        //character.Buffs.AddBuff(new Buff(), character, 3);
    }
}