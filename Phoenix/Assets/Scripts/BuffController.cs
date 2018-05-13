using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class BuffController
{
    public List<Buff> Buffs = new List<Buff>();

    public Buff this[int index]
    {
        get { return Buffs[index]; }
    }

    public void AddBuff(Buff buff, Character character, float time = 0)
    {
        if (time > 0)
        {
            TimerControl timer = new TimerControl(time, c =>
             {
                 Debug.Log("Out of Ice");
                 Buffs.Remove(buff);
             }, character);
        }
        Buffs.Add(buff);
    }

    public IEnumerable<Buff> GetEffectorBuffs(ElementTypes elementType, BuffType buffType = BuffType.All)
    {
        if (buffType != BuffType.All)
        {
            foreach (var buff in Buffs)
            {
                if (buff.Skill.ElementType == elementType && buff.BuffType == buffType)
                {
                    yield return buff;
                }
            }
        }
        else
        {
            foreach (var buff in Buffs)
            {
                if (buff.Skill.ElementType == elementType)
                {
                    yield return buff;
                }
            }
        }
    }
}
public class Buff
{
    public float Amount { get; set; }
    public Skill Skill { get; set; }
    public BuffType BuffType { get; set; }
}

public enum BuffType
{
    Damage,
    Speed,
    All
}