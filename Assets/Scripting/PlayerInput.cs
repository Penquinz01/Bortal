using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 moveVec { get; private set; }
    public event Action Shoot;

    public void OnMovement(InputValue value)
    {
        moveVec = value.Get<Vector2>();
    }
    public void OnShoot(InputValue value)
    {
        if (value.isPressed)
            Shoot?.Invoke();
    }
}
