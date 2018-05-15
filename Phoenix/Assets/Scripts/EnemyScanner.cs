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
        private static HashSet<GameObject> _enemiesInSpellRange = new HashSet<GameObject>();
        private BoxCollider2D _boxCollider2D;

        void Start()
        {
            _gOCollider = GameObject.Find("CastArea");
            _spriteRenderer = _gOCollider.GetComponent<SpriteRenderer>();
        }
        public void StartCastArea(float rangeX, float rangeY, Color areaColor)
        {
            var player = GameObject.FindObjectOfType<PlayerCharacter>();

            _gOCollider.SetActive(true);
            _boxCollider2D = _gOCollider.GetComponent<BoxCollider2D>();
            _boxCollider2D.enabled = true;
            var rTransform = _gOCollider.GetComponent<RectTransform>();
            rTransform.localScale = new Vector3(rangeX * 0.5f, rangeY * 0.5f);
            rTransform.localPosition = new Vector3(rangeX * 0.25f + 0.25f, 0);
            //gOCollider.GetComponent<SpriteRenderer>().material.SetColor("_Color",areaColor);
            _spriteRenderer.color = areaColor;
            _spriteRenderer.enabled = true;
            
        }

        public IEnumerable<EnemyCharacter> GetEnemiesInRange()
        {
            return _enemiesInSpellRange.Select(x=>x.GetComponent<EnemyCharacter>());
        }

        private EnemyCharacter GetClossest()
        {
            foreach (var enemy in _enemiesInSpellRange)
            {
                
            }
            return null;
        }

        void OnTriggerEnter2D(Collider2D obj)
        {
            if (obj.tag == "Enemy")
            {
                if (!_enemiesInSpellRange.Contains(obj.gameObject))
                {
                    _enemiesInSpellRange.Add(obj.gameObject);
                }
            }
        }

        void OnTriggerExit2D(Collider2D obj)
        {
            if (obj.tag == "Enemy")
            {
                if (_enemiesInSpellRange.Contains(obj.gameObject))
                {
                    _enemiesInSpellRange.Remove(obj.gameObject);
                }
            }
        }
        private bool IsInRange(Vector2 playerLoc, Vector2 enemyLoc, float rangeX, float rangeY)
        {
            //todo
            return false;
        }

        public void CloseScanner()
        {
            _gOCollider.SetActive(false);
            _spriteRenderer.enabled = false;
            _boxCollider2D.enabled = false;
            _enemiesInSpellRange= new HashSet<GameObject>();
        }
    }
}
