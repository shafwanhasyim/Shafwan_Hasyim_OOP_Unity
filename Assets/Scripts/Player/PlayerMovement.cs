using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] Vector2 maxSpeed;
    [SerializeField] Vector2 timeToFullSpeed;
    [SerializeField] Vector2 timeToStop;
    [SerializeField] Vector2 stopClamp;

    private Vector2 moveDirection;
    private Vector2 moveVelocity;
    private Vector2 moveFriction;
    private Vector2 stopFriction;
    private Rigidbody2D rb;
    private float padding = 1f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveVelocity = 2 * maxSpeed / timeToFullSpeed;
        moveFriction = -2 * maxSpeed / (timeToFullSpeed * timeToFullSpeed);
        stopFriction = -2 * maxSpeed / (timeToStop * timeToStop);
    }

    public void Move()
    {
        moveDirection = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        if (moveDirection != Vector2.zero)
        {
            Vector2 targetVelocity = moveDirection * maxSpeed;
            rb.velocity = Vector2.MoveTowards(rb.velocity, targetVelocity, moveVelocity.magnitude * Time.deltaTime);
        }
        else
        {
            Vector2 frictionForce = GetFriction();
            rb.velocity = Vector2.MoveTowards(rb.velocity, Vector2.zero, frictionForce.magnitude * Time.deltaTime);
            if (rb.velocity.magnitude < stopClamp.magnitude)
            {
                rb.velocity = Vector2.zero;
            }
            MoveBound();
        }
    }

    private void MoveBound()
    {
        Camera mainCamera = GameObject.FindWithTag("MainCamera").GetComponent<Camera>(); // Access the main camera only within this method
        if (mainCamera != null)
        {
            Vector3 viewportPosition = mainCamera.WorldToViewportPoint(transform.position);
            viewportPosition.x = Mathf.Clamp(viewportPosition.x, padding / 100f, 1 - padding / 100f);
            viewportPosition.y = Mathf.Clamp(viewportPosition.y, padding / 100f, 1 - padding / 100f);
            transform.position = mainCamera.ViewportToWorldPoint(viewportPosition);
        }
        else
        {
            Debug.LogWarning("No main camera found in the scene.");
        }
    }

    public Vector2 GetFriction()
    {
        if (moveDirection != Vector2.zero)
        {
            return new Vector2(
                moveDirection.x != 0 ? moveFriction.x : 0,
                moveDirection.y != 0 ? moveFriction.y : 0
            );
        }
        else
        {
            return new Vector2(
                rb.velocity.x != 0 ? stopFriction.x : 0,
                rb.velocity.y != 0 ? stopFriction.y : 0
            );
        }
    }

    public bool IsMoving()
    {
        return rb.velocity != Vector2.zero;
    }
}
