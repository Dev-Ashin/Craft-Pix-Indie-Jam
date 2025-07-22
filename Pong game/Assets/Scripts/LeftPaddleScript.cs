using UnityEngine;

public class LeftPaddleScript : MonoBehaviour
{

    private float speed = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 move = Vector3.zero;
        if (Input.GetKey(KeyCode.UpArrow))
        {
            move.y = 1;
            
        }
        if (Input.GetKey(KeyCode.DownArrow))
        {
            move.y = -1;

        }
        transform.position += move * speed * Time.deltaTime;
    }
}
