using UnityEngine;

public class BulletPointScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireCoolDown = 0.2f;
    private float fireTimer = 0f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        fireTimer -= Time.deltaTime;
        if (Input.GetMouseButton(0) && fireTimer <= 0) 
        {

            Fire();
            fireTimer = fireCoolDown;
        }
       

    }
   
    private void Fire()
    {
        Instantiate(bulletPrefab , firePoint.position, firePoint.rotation);
    }
}
