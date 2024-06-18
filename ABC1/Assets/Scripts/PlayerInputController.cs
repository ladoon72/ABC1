using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputController : PlayerInput
{
    public float moveAmount = 5f;  // 5 ���־� �̵�

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

        if (direction.y > 0) // W Ű�� ������ ��
        {
            move.x += moveAmount;
        }
        else if (direction.y < 0) // S Ű�� ������ ��
        {
            move.x -= moveAmount;
        }

        if (direction.x < 0) // D Ű�� ������ ��
        {
            move.z += moveAmount;
        }
        else if (direction.x > 0) // A Ű�� ������ ��
        {
            move.z -= moveAmount;
        }

        transform.position += move;
    }
}
