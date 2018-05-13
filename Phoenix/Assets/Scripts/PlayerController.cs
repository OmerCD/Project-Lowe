using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerCharacter _character;
    [SerializeField] private Vector3 _move;
    void Start()
    {
        _character = GetComponent<PlayerCharacter>();
    }
    void Update()
    {
        _move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
        transform.position += _move * _character.Speed * Time.deltaTime;
    }
}
