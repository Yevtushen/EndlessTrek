using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed = 4;
    public float horizontalSpeed = 4;
    public static bool canMove;
    public bool isJumping;
    public bool comingDown;
    public GameObject playerObject;
    public float maxSpeed = 42;
    private float _cooldownTime;


    void Update()
    {
        transform.Translate(Vector3.forward * Time.deltaTime * movementSpeed, Space.World);
        if (canMove == true)
        {
            MoveToTheLeft();
            MoveToTheRight();
            Jump();
        }
        ComingDown();
        Accelerating();
    }

    void MoveToTheLeft()
    {
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            if (this.gameObject.transform.position.x > LevelBoundary.leftSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed);
            }
        }
    }

    void MoveToTheRight()
    {
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            if (this.gameObject.transform.position.x < LevelBoundary.rightSide)
            {
                transform.Translate(Vector3.left * Time.deltaTime * horizontalSpeed * -1);
            }
        }
    }

    void Jump()
    {
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.Space))
        {
            if (isJumping == false)
            {
                isJumping = true;
                playerObject.GetComponent<Animator>().Play("Jump");
                StartCoroutine(Jumping());
            }
        }
    }

    void ComingDown()
    {
        if (isJumping == true)
        {
            if (comingDown == false)
            {
                transform.Translate(Vector3.up * Time.deltaTime * 3, Space.World);
            }
            if (comingDown == true)
            {
                transform.Translate(Vector3.up * Time.deltaTime * -3, Space.World);
            }
        }
    }

    IEnumerator Jumping()
    {
        float initialHeight = transform.position.y;
        yield return new WaitForSeconds(0.45f);
        comingDown = true;
        yield return new WaitForSeconds(0.45f);
        isJumping = false;
        comingDown= false;
        playerObject.GetComponent<Animator>().Play("Running");
        transform.position = new Vector3(transform.position.x, initialHeight, transform.position.z);
    }

    void Accelerating()
    {
        if (_cooldownTime > 0)
        {
            _cooldownTime -= Time.deltaTime;
        }
        if (LevelDistance.publicDistanceRun % 50 == 0)
        {
            if (_cooldownTime <= 0 && movementSpeed < maxSpeed)
            {
                _cooldownTime = 5;
                movementSpeed++;
                horizontalSpeed++;
            }
        }
    }
}