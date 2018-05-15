using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
using UnityEngine.UI;

public class HealthVisualizer : MonoBehaviour
{
    [SerializeField] private Character _character;
    private Transform _characterTransform;

    private Image _healthBar;
	// Use this for initialization
	void Start ()
	{
        _character.OnHealthChanged+=OnHealthChanged;
	    _characterTransform = _character.gameObject.transform;
	    _healthBar= transform.Find("HealthForeground").GetComponent<Image>();

    }

    private void OnHealthChanged(float maxHealth, float newHealth)
    {
        _healthBar.fillAmount = newHealth/ maxHealth;
    }

    // Update is called once per frame
	void Update () {
		transform.position = new Vector3(_characterTransform.position.x,_characterTransform.position.y+ 0.6f);
	}
}
