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
        public float Speed = 10;
        public float VisionLevel;
        public bool CanMove;

        public float Weight
        {
            get
            {
                return Inventory.Sum(item => item.Weight);
            }
        }
        public WornItems WornItems;

        void Start()
        {
        }
    }

    [CreateAssetMenu(fileName = "Skill", menuName = "Skill")]


    public class Skill : ScriptableObject
    {

        private Element _element;
        public string Name;
        private float _mainCooldownTime;
        public float AdjustedCooldownTime;
        internal float CurrentCooldownLevel = 0;
        public float PerfectTime;
        public Damage Damage;
        public int DistanceWidth;
        public int DistanceHeight;
        public float MainSpeed;
        public float BuffedSpeed;
        public ElementTypes ElementType;
        public float DealingDamage { get; set; }
        public void CastSkill(Character character, bool isPerfect = false)
        {

            if (isPerfect)
            {
                character.ImmunityLevels.IncreaseImmunity(ElementType);
            }

            AdjustAttackWithBuffs(character);

            CurrentCooldownLevel = AdjustedCooldownTime;
            ApplyDrawback(character);
        }

        private void AdjustAttackWithBuffs(Character character)
        {
            var effectingBuffs = character.Buffs.GetEffectorBuffs(ElementType);
            foreach (var effectingBuff in effectingBuffs)
            {
                if (effectingBuff.BuffType==BuffType.Damage)
                {
                    DealingDamage += effectingBuff.Amount * DealingDamage;
                }
                else if (effectingBuff.BuffType==BuffType.Speed)
                {
                    BuffedSpeed += effectingBuff.Amount * MainSpeed;
                }
            }
            
        }

        public Skill()
        {
            BuffedSpeed = MainSpeed;
            _element = new Element
            {
                ElementType = ElementType
            };
            AdjustedCooldownTime = _mainCooldownTime;
        }
        /// <summary>
        /// Applies Drawback to the given character
        /// </summary>
        /// <param name="character"></param>
        public void ApplyDrawback(Character character)
        {
            _element.DrawbackFunc(character);
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