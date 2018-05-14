using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Scripts
{
    class EnemyScanner : MonoBehaviour
    {
        static SpriteRenderer _spriteRenderer;
        static GameObject _gOCollider;

        void Start()
        {
            _gOCollider = GameObject.Find("CastArea");
            _spriteRenderer = _gOCollider.GetComponent<SpriteRenderer>();
        }
        public static EnemyCharacter FindClossestEnemy(float rangeX, float rangeY, Color areaColor)
        {
            var player = GameObject.FindObjectOfType<PlayerCharacter>();

            _gOCollider.SetActive(true);
            var rTransform = _gOCollider.GetComponent<RectTransform>();
            rTransform.localScale = new Vector3(rangeX * 0.5f, rangeY * 0.5f);
            rTransform.localPosition = new Vector3(rangeX * 0.25f + 0.25f, 0);
            //gOCollider.GetComponent<SpriteRenderer>().material.SetColor("_Color",areaColor);
            _spriteRenderer.color = areaColor;
            _spriteRenderer.enabled = true;
            EnemyCharacter clossest;
            var enemyCharacters = GameObject.FindObjectsOfType<EnemyCharacter>();
            clossest = enemyCharacters[0];
            for (int i = 1; i < enemyCharacters.Length; i++)
            {
                //todo
            }
            return clossest;
        }

        private static bool IsInRange(Vector2 playerLoc, Vector2 enemyLoc, float rangeX, float rangeY)
        {
            //todo
            return false;
        }

        public static void CloseScanner()
        {
            _gOCollider.SetActive(false);
            _spriteRenderer.enabled = false;
        }
    }
}
