using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Assets.Scripts
{
    [CreateAssetMenu(fileName = "Skill", menuName = "Skill")]


    public class Skill : ScriptableObject
    {

        public Element Element;
        public string Name;
        [SerializeField]private float _mainCooldownTime;
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
        public void CastSkill(Character character, IEnumerable<EnemyCharacter> enemies, bool isPerfect = false)
        {
            character.CurrentEnemy = enemies.FirstOrDefault();

            if (isPerfect)
            {
                character.ImmunityLevels.IncreaseImmunity(ElementType);
            }
            else
            {

                ApplyDrawback(character);
            }
            AdjustAttackWithBuffs(character);
            if (character.CurrentEnemy != null)
            {
                foreach (var enemy in enemies)
                {
                    enemy.GetComponent<EnemyCharacter>().DealDamage(DealingDamage);
                }
            }
            CurrentCooldownLevel = AdjustedCooldownTime;
        }

        private void AdjustAttackWithBuffs(Character character)
        {
            var effectingBuffs = character.Buffs.GetEffectorBuffs(ElementType);
            foreach (var effectingBuff in effectingBuffs)
            {
                if (effectingBuff.BuffType == BuffType.Damage)
                {
                    DealingDamage += effectingBuff.Amount * DealingDamage;
                }
                else if (effectingBuff.BuffType == BuffType.Speed)
                {
                    BuffedSpeed += effectingBuff.Amount * MainSpeed;
                }
            }

        }

        public void OnEnable()
        {
            BuffedSpeed = MainSpeed;
            Element = new Element(eType: ElementType);
            AdjustedCooldownTime = _mainCooldownTime;
        }
        /// <summary>
        /// Applies Drawback to the given character
        /// </summary>
        /// <param name="character"></param>
        public void ApplyDrawback(Character character)
        {
            Element.DrawbackFunc(character, this);
        }
    }
}