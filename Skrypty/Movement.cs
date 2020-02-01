using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    CharacterController characterController;
    public float movementSpeed = 15f;
    private Vector3 moveDirection = Vector3.zero;
    public float gravity = 150f;
    public float jumpStrenght = 30f;
    public float faster = 1.0005f;
    public float offsetLine = 3;
    private int currentLine = 2;
    private float changingLineSpeed = 0.1f;
    private void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    private void Update()
    {

        if (characterController.isGrounded)
        {
            moveDirection = new Vector3(0f, 0.0f, 1);
            moveDirection = moveDirection * movementSpeed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            switchLane(-1);
        }
        else if (Input.GetKeyDown(KeyCode.D))
        {
            switchLane(1);
        }
        //jumping
        if (Input.GetKeyDown(KeyCode.W) && transform.position.y < 0.5)
        {
            Jump();
        }
        //Gravity
        if (!characterController.isGrounded)
        {
            moveDirection.y -= gravity * Time.deltaTime;
        }
        characterController.Move(moveDirection * Time.deltaTime);

        //touch movement
        /*
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            if (touch.phase == TouchPhase.Began)//start of touching
            {
                touchStart = touch.position;
                touchEnd = touch.position;
            }
            else if (touch.phase == TouchPhase.Moved)//moving finger
            {
                touchEnd = touch.position;
            }
            else if (touch.phase == TouchPhase.Ended)//end of touch
            {
                if ((touchEnd.x - touchStart.x) > touchlength || (touchEnd.y - touchStart.y) > touchlength)
                {
                    touchEnd = touch.position;
                    if (touchEnd.x > touchStart.x)
                    {
                        switchLane(1);
                    }
                    else if (touchEnd.x < touchStart.x)
                    {
                        switchLane(-1);
                    }
                }
                else // vertical move
                {
                    if (touchEnd.y > touchStart.y)
                    {
                        moveDirection.y += jumpStrenght;//jump
                    }
                }
            }
        }*/
        CenterLine();
    }
    void FixedUpdate()
    {
        if (movementSpeed < 40) movementSpeed *= faster;
    }

    public void switchLane(int x)
    {
        if (currentLine <= 3 || currentLine >= 1)
        {
            if (currentLine == 3 && x > 0) return;
            if (currentLine == 1 && x < 0) return;
            currentLine += x;
        }

    }
    public void Jump()
    {
        moveDirection.y += jumpStrenght;
    }
    private void CenterLine()
    {
        //centering the lines 1,2,3
        if (currentLine == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(-3, transform.position.y, transform.position.z), changingLineSpeed);
        }
        else if (currentLine == 2)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(0, transform.position.y, transform.position.z), changingLineSpeed);
        }
        else if (currentLine == 3)
        {
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(3, transform.position.y, transform.position.z), changingLineSpeed);
        }
    }
}
