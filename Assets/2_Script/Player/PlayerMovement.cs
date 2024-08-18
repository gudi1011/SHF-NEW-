using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Searcher.SearcherWindow.Alignment;

public class PlayerMovement : MonoBehaviour
{
    public Joystick joystick;

    public float inputThreshold = 0.1f;

    public float moveSpeed = 1;

    private float moveX;
    private float moveZ;

    private bool isFacingRight = true;

    private Rigidbody rb;
    public Animator anim;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Move();
        //Flip();
        MoveAnimation();
    }

    private void Move()
    {
        float keyboardMoveX = Input.GetAxis("Horizontal");
        float keyboardMoveZ = Input.GetAxis("Vertical");

        float joystickMoveX = joystick.Horizontal;
        float joystickMoveZ = joystick.Vertical;

        moveX = keyboardMoveX + joystickMoveX;
        moveZ = keyboardMoveZ + joystickMoveZ;

        if (Mathf.Abs(moveX) >= inputThreshold || Mathf.Abs(moveZ) >= inputThreshold)
        {
            Vector3 move = new Vector3(moveX, 0, moveZ) * moveSpeed;
            rb.velocity = new Vector3(move.x, rb.velocity.y, move.z);
        }
        else
        {
            rb.velocity = new Vector3(0, rb.velocity.y, 0);
        }

        //���� �ִϸ��̼�
        if (moveX != 0 || moveZ != 0)
        {
            //anim.SetBool("Walk", true);
        }
        else
        {
            //anim.SetBool("Walk", false);
        }
    }

    private void Flip()
    {
        if (isFacingRight && moveX < 0 || !isFacingRight && moveX > 0)
        {
            isFacingRight = !isFacingRight;
            Vector3 localScale = transform.localScale;
            localScale.x *= -1f;
            transform.localScale = localScale;
        }
    }

    private void MoveAnimation()
    {
        if (Mathf.Abs(moveX) >= inputThreshold || Mathf.Abs(moveZ) >= inputThreshold)
        {
            // ��
            anim.SetBool("Walk_F", moveZ < -inputThreshold);

            // ��
            anim.SetBool("Walk_B", moveZ > inputThreshold);

            // ��
            anim.SetBool("Walk_R", moveX > inputThreshold);

            // ��
            anim.SetBool("Walk_L", moveX < -inputThreshold);
        }
        else
        {
            // ��� �ִϸ��̼� ����
            anim.SetBool("Walk_F", false);
            anim.SetBool("Walk_B", false);
            anim.SetBool("Walk_R", false);
            anim.SetBool("Walk_L", false);
        }
    }
}