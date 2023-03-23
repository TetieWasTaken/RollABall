using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerController : MonoBehaviour
{
    public float speed = 10;
    public TextMeshProUGUI scoreText;
    public GameObject winTextObject;

    private Rigidbody rb;
    private int score = 0;
    private float moveX;
    private float moveY;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        SetCountText();
        winTextObject.SetActive(false);
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

    void SetCountText()
    {
        scoreText.text = $"Score: {score}";
        if (score >= 12)
            winTextObject.SetActive(true);
    }

    void OnTriggerEnter(Collider collided)
    {
       if (collided.gameObject.CompareTag("Pickup"))
       {
            collided.gameObject.SetActive(false);
            score++;

            SetCountText();
       }
    }
}
