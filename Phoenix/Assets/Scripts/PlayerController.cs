using System;
using System.Collections;
using System.Collections.Generic;
using Assets.Scripts;
using UnityEngine;
public enum MoveDirection { Up, Down, Left, Right }

public class PlayerController : MonoBehaviour
{
    private PlayerCharacter _character;
    [SerializeField] private Vector3 _move;

    private bool _canMove = true, _moving = false;
    private int _buttonCooldown = 0;
    private MoveDirection _moveDirection = MoveDirection.Down;
    private Vector3 _pos;
    private int _rotationCooldown = 0;

    public float JoyX;
    public float JoyY;

    void Start()
    {
        _character = GetComponent<PlayerCharacter>();
    }
    void Update()
    {
        if (_canMove)
        {
            _pos = transform.position;
            Move();
        }
        if (_moving)
        {
            if (transform.position == _pos)
            {
                _moving = false;
                _canMove = true;
                Move();
            }
            transform.position = Vector3.MoveTowards(transform.position, _pos, Time.deltaTime * _character.CurrentSpeed);
        }
        Rotate();
    }

    private void Rotate()
    {
        _rotationCooldown--;
        if (_rotationCooldown <= 0)
        {
            if (Input.GetAxis("RT") > 0.8)
            {
                PressAction.OnButtonPressed("RT");
                _rotationCooldown = 15;
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z - 90);
            }
            if (Input.GetAxis("LT") > 0.8)
            {
                PressAction.OnButtonPressed("LT");
                _rotationCooldown = 15;
                transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + 90);
            }
        }
    }

    private void Move()
    {
        _buttonCooldown--;
        if (_buttonCooldown <= 0)
        {
            _move = new Vector3(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"), 0);
            if (Math.Abs(_move.x - _move.y) > 0.4)
            {
                var absX = Math.Abs(_move.x);
                var absY = Math.Abs(_move.y);
                if (absX > absY)
                {
                    if (_move.x < 0)
                    {
                        if (_moveDirection != MoveDirection.Left)
                        {
                            _buttonCooldown = 5;
                            _moveDirection = MoveDirection.Left;
                        }
                        else
                        {
                            _canMove = false;
                            _moving = true;
                            _pos += Vector3.left;
                        }
                    }
                    else if (_move.x > 0)
                    {
                        if (_moveDirection != MoveDirection.Right)
                        {
                            _buttonCooldown = 5; _moveDirection = MoveDirection.Right;
                        }
                        else
                        {
                            _canMove = false;
                            _moving = true;
                            _pos += Vector3.right;
                        }
                    }
                }
                else if (absY > absX)
                {
                    if (_move.y < 0)
                    {
                        if (_moveDirection != MoveDirection.Down)
                        {
                            _buttonCooldown = 5; _moveDirection = MoveDirection.Down;
                        }
                        else
                        {
                            _canMove = false;
                            _moving = true;
                            _pos += Vector3.down;
                        }
                    }
                    else if (_move.y > 0)
                    {
                        if (_moveDirection != MoveDirection.Up)
                        {
                            _buttonCooldown = 5; _moveDirection = MoveDirection.Up;
                        }
                        else
                        {
                            _canMove = false;
                            _moving = true;
                            _pos += Vector3.up;
                        }
                    }
                }
            }
        }
    }
}

