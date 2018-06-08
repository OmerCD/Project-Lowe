using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Notificator : MonoBehaviour
{
    private string _message;
    private Color _color;
    private float _duration;
    public void ShowNotificationMessage(string message, Color color, float duration)
    {
        _message = message;
        _color = color;
        _duration = duration;
        StartCoroutine("ShowMessage");
    }

    private IEnumerator ShowMessage()
    {
        var rendererComponent = GetComponent<Renderer>();
        var c = _color;
        var text = GetComponentInChildren<TextMesh>();
        text.color = c;
        text.text = _message;

        var step = 1 / _duration;
        for (float f = 1f; f >= 0; f -= step)
        {
            c.a = f;
            text.color = c;
            yield return null;
        }
        Destroy(gameObject);
    }
}
