using UnityEngine;

public class BulletScript : MonoBehaviour
{

    public float damageRate;
    public float bulletSpeed;
    private Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bulletSpeed = 5f;
        damageRate = 10;
    }

    // Update is called once per frame
    void Update()
    {   
        
    }
    private void FixedUpdate()
    {
        rb.linearVelocity = transform.up * damageRate;
    }
}
