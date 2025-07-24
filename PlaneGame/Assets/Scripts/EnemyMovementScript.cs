using Unity.VisualScripting;
using UnityEngine;

public class EnemyMovementScript : MonoBehaviour
{
    public GameObject player;
    private Rigidbody2D rb;
    public float moveSpeed = 2f;
    public float stoppingDistance = 5f;
    private bool isVisible;
    public GameObject BulletPrefab;
    public Transform Firepoint;
    public float fireCoolDown = 0.2f;
    private float fireTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb= GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(player.transform.position, transform.position);
        Vector2 direction = player.transform.position - transform.position;

        direction = direction.normalized;
        if (distance > stoppingDistance) 
        {
            

            transform.position += (Vector3)(direction * moveSpeed * Time.deltaTime);
        }
        
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90;
        transform.rotation = Quaternion.Euler(0, 0, angle);

        if (isVisible) 
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0)
            {

                Fire();
                fireTimer = fireCoolDown;
            }

        }
    }
    void OnBecameVisible()
    {
        isVisible = true;
    }
    private void OnBecameInvisible()
    {
        isVisible= false;
    }
    void Fire()
    {
        Instantiate(BulletPrefab, Firepoint.transform.position, Firepoint.transform.rotation);
    }
}
