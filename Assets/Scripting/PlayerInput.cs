using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInput : MonoBehaviour
{
    public Vector2 moveVec { get; private set; }

    public void OnMovement(InputValue value)
    {
        Debug.Log("Working");
        moveVec = value.Get<Vector2>();
    }
}
