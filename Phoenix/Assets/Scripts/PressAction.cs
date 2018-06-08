using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;
using Random = System.Random;

namespace Assets.Scripts
{
    public class PressAction : MonoBehaviour
    {
        bool _pressed = false;
        private string _lastPressed;
        public float _timeCalc;
        private PlayerCharacter _character;
        private Random _random = new Random();
        public static Action<string> OnButtonPressed;
        private EnemyScanner _eScanner;
        

        void Start()
        {
            _eScanner = GetComponent<EnemyScanner>();
            _character = GetComponent<PlayerCharacter>();
        }


        void Update()
        {

            foreach (var assigned in _character.AssignedSkills)
            {
                if (assigned.Value.CurrentCooldownLevel>0)
                {
                    assigned.Value.CurrentCooldownLevel -= Time.deltaTime;
                }
                if (assigned.Value.CurrentCooldownLevel <= 0)
                {
                    if (Input.GetButtonDown(assigned.Key))
                    {
                        if (OnButtonPressed != null) OnButtonPressed(assigned.Key);
                        _pressed = true;
                        _lastPressed = assigned.Key;
                        _timeCalc = Time.time;
                        Debug.Log("Pressed " + assigned.Key + "\nTime:" + _timeCalc);
                        _eScanner.StartCastArea(assigned.Value.DistanceWidth, assigned.Value.DistanceHeight, assigned.Value.Element.AreaColor);
                    }
                }
            }
            if (_pressed && Input.GetButtonDown("RB"))
            {
                if (OnButtonPressed != null) OnButtonPressed("RB");
                var enemies = _eScanner.GetEnemiesInRange();
                var now = Time.time;
                var isPerfect = false;
                var timeDifference = Math.Abs(now - _timeCalc);
                var currentSkill = _character.AssignedSkills[_lastPressed];
                var difference = Math.Abs(currentSkill.PerfectTime - timeDifference);

                var intervalFloat = ((10 - currentSkill.PerfectTime) * 0.5f);
                var interval = (int)Math.Ceiling(intervalFloat);
                var maxVal = currentSkill.PerfectTime + interval;
                var minVal = currentSkill.PerfectTime - interval;

                if (difference < 0.125)
                {
                    isPerfect = true;
                    currentSkill.DealingDamage = currentSkill.Damage.Perfect;
                    Debug.Log("Perfect :"+ currentSkill.DealingDamage);
                }
                else if (timeDifference < minVal || timeDifference > maxVal)
                {
                    currentSkill.DealingDamage = currentSkill.Damage.Minimum;
                    Debug.Log("Minimum :" + currentSkill.DealingDamage);
                }
                else
                {
                    currentSkill.DealingDamage = _random.Next((int) (currentSkill.Damage.Minimum+5),(int) (currentSkill.Damage.Maximum));
                    Debug.Log("Maximum :" + currentSkill.DealingDamage);
                }
                _eScanner.CloseScanner();
                currentSkill.CastSkill(_character,enemies,isPerfect);
                Debug.Log(message: timeDifference);
                _pressed = false;
            }
        }
    }
}
