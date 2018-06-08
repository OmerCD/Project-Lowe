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
        public void ShowNotification(string text, Color color, float duration)
        {
            var notificator = Instantiate(_notificationObject, transform).GetComponent<Notificator>();
            notificator.ShowNotificationMessage(text,color,duration);
        }

        public void DealDamage(float damage)
        {
            Health -= damage;
            ShowNotification(damage.ToString(),Color.red, 50);
        }
    }
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
        [SerializeField] private GameObject _notificationObject;
        [SerializeField]private float _fullHealth = 100;
        public Action<float, float> OnHealthChanged;
        public string Name = "TestCharacter";
        private float _health;
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

        public float Health
        {
            get
            {
                return _health;
            }
            set
            {
                OnHealthChanged(_fullHealth, value);

                _health = value;
            }
        }

        public WornItems WornItems;

        public Character()
        {
        }

        protected virtual void Start()
        {
            _health = _fullHealth;
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