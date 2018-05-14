using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security;
using ItemControl;
using UnityEngine;

namespace Assets.Scripts
{
    public partial class Character
    {
        public class Immunity
        {
            public string Name
            {
                get { return ElementType + " " + Value; }
            }
            public ElementTypes ElementType;
            public float Value;
        }
        public class ImmunityLevel
        {
            private const int MAX_IMMUNITY = 25;
            private readonly List<Immunity> _immunities = new List<Immunity>();

            public Immunity this[int i]
            {
                get { return _immunities[i]; }
            }

            public void IncreaseImmunity(ElementTypes elementType)
            {
                var immunity = _immunities.FirstOrDefault(x => x.ElementType == elementType);
                if (immunity != null)
                {
                    if (immunity.Value < MAX_IMMUNITY)
                    {
                        immunity.Value += 0.05f;
                    }
                }
                else
                {
                    _immunities.Add(new Immunity { ElementType = elementType, Value = 0.05f });
                }
            }
        }

    }
    public partial class Character : MonoBehaviour
    {
        public string Name = "TestCharacter";
        public float Health = 100;
        public List<Item> Inventory;
        public List<Skill> Skills;
        public BuffController Buffs = new BuffController();
        public ImmunityLevel ImmunityLevels = new ImmunityLevel();
        public float BaseSpeed = 10;
        public float CurrentSpeed;
        public float VisionLevel;
        public bool CanMove;
        public EnemyCharacter CurrentEnemy;

        public float Weight
        {
            get
            {
                return Inventory.Sum(item => item.Weight);
            }
        }
        public WornItems WornItems;

        public Character()
        {
        }

        void Start()
        {
        }
    }

    [System.Serializable]
    public struct Damage
    {
        public float Minimum;
        public float Maximum;
        public float Perfect;
    }
}