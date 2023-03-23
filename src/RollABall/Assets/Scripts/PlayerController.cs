using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;

    private Rigidbody rb;
    private float moveX;
    private float moveY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        Vector3 movementVector = new Vector3(moveX, 0.0f, moveY);

        rb.AddForce(movementVector * speed);
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        
        moveX = movementVector.x;
        moveY = movementVector.y;
    }

    void OnTriggerEnter(Collider collided)
    {
       if (collided.gameObject.CompareTag("Pickup"))
       {
           collided.gameObject.SetActive(false);
       }
    }
}
