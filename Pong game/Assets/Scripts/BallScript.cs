using UnityEngine;

public class BallScript : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        rb.linearVelocity = new Vector2(5f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
