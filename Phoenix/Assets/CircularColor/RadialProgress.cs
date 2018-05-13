using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RadialProgress : MonoBehaviour
{
    [SerializeField] private float _time=10;
    [SerializeField] private Text _loadingText;

    [SerializeField] private Image _loadingBar;

    private float _currentValue;

    void Start()
    {
        _currentValue = _time;
    }
	// Update is called once per frame
	void Update () {
	    if (_currentValue>0)
	    {
	        _currentValue -= Time.deltaTime;
	        _loadingBar.fillAmount = _currentValue / _time;
	        _loadingText.text = "Time :" + _currentValue;
	    }
	}
}
