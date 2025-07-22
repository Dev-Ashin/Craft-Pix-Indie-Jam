using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float normalSpeed = 5f;
    public float brakeSpeed = 2f;
    public float boostSpeed = 8f;
    public float boostDuration = 2f;
    public float boostCooldown = 3f;

    private float currentSpeed;
    private float boostTimer = 0f;
    private float cooldownTimer = 0f;
    private bool isBoosting = false;

    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentSpeed = normalSpeed;
    }

    void Update()
    {
        // Rotate towards mouse
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = (mouseWorldPos - transform.position);
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90f;
        rb.rotation = angle;

        // Braking
        if (Input.GetKey(KeyCode.Space))
        {
            currentSpeed = brakeSpeed;
        }
        // Boosting
        else if (Input.GetKey(KeyCode.LeftShift) && cooldownTimer <= 0f)
        {
            isBoosting = true;
            boostTimer = boostDuration;
            cooldownTimer = boostCooldown + boostDuration;
        }
        // Normal Speed
        else if (!isBoosting)
        {
            currentSpeed = normalSpeed;
        }

        // Handle Boost Timer
        if (isBoosting)
        {
            boostTimer -= Time.deltaTime;
            currentSpeed = boostSpeed;

            if (boostTimer <= 0f)
            {
                isBoosting = false;
                currentSpeed = normalSpeed;
            }
        }

        // Handle Cooldown Timer
        if (cooldownTimer > 0f)
        {
            cooldownTimer -= Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        // Constant forward movement
        rb.linearVelocity = transform.up * currentSpeed;
    }
}
