using UnityEngine;
using System.Collections;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    public float forwardSpeed = 10f;
    public float laneDistance = 2.8f;
    public float laneChangeSpeed = 10f;
    public float jumpHeight = 2f;
    public float gravity = -20f;

    private CharacterController controller;
    private int currentLane = 1; // 0 = left, 1 = center, 2 = right
    private float verticalVelocity;

    void Awake()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
            currentLane = Mathf.Max(0, currentLane - 1);

        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
            currentLane = Mathf.Min(2, currentLane + 1);

        if ((Input.GetKeyDown(KeyCode.Space) ||
             Input.GetKeyDown(KeyCode.UpArrow)) && controller.isGrounded)
        {
            verticalVelocity = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        if (controller.isGrounded && verticalVelocity < 0)
            verticalVelocity = -2f;

        verticalVelocity += gravity * Time.deltaTime;

        float targetX = (currentLane - 1) * laneDistance;
        float deltaX = (targetX - transform.position.x) * laneChangeSpeed;

        Vector3 movement = new Vector3(
            deltaX,
            verticalVelocity,
            forwardSpeed
        );

        controller.Move(movement * Time.deltaTime);
    }
}