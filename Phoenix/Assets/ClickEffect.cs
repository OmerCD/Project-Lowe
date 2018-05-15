using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class ClickEffect : MonoBehaviour
{
    private Vector3 _from = Vector3.one;
    [SerializeField] private Vector3 _to = (Vector3.one * 0.95f);
    [SerializeField] private string _buttonKey;
    private RectTransform _rectTransform;
    void Start()
    {
        _rectTransform = GetComponent<RectTransform>();
        PressAction.OnButtonPressed+=OnButtonPressed;
    }

    private void OnButtonPressed(string s)
    {
        if (_buttonKey==s)
        {
            _rectTransform.localScale = _from;
            StartCoroutine(Scaling());

           
        }
    }
    IEnumerator Scaling()
    {
        _rectTransform.localScale = _to;
        yield return new WaitForSeconds(Time.fixedDeltaTime * 3);
        _rectTransform.localScale = _from;
    }
}
