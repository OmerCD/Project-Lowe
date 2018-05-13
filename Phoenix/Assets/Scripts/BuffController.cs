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
        if (time>0)
        {
            TimerControl timer = new TimerControl(time,c =>
            {
                Debug.Log("Out of Ice");
                Buffs.Remove(buff);
            },character);
        }
        Buffs.Add(buff);
    }
}
public class Buff
{
    public float Amount { get; set; }
    public Skill Skill { get; set; }
}