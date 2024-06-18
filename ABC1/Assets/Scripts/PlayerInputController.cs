using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerInput
{
    public float moveAmount = 5f;  // 5 À¯´Ö¾¿ ÀÌµ¿

    public void OnMove(InputValue value)
    {
        Vector2 moveInput = value.Get<Vector2>();
        CallMoveEvent(moveInput);
    }

    void Start()
    {
        OnMoveEvent += MovePlayer;
    }

    public void MovePlayer(Vector2 direction)
    {
        Vector3 move = Vector3.zero;

        if (direction.y > 0) // W Å°¸¦ ´­·¶À» ¶§
        {
            move.x += moveAmount;
        }
        else if (direction.y < 0) // S Å°¸¦ ´­·¶À» ¶§
        {
            move.x -= moveAmount;
        }

        if (direction.x < 0) // D Å°¸¦ ´­·¶À» ¶§
        {
            move.z += moveAmount;
        }
        else if (direction.x > 0) // A Å°¸¦ ´­·¶À» ¶§
        {
            move.z -= moveAmount;
        }

        transform.position += move;
    }
}
