using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 10f; // Time in seconds before the bullet is destroyed

    void Update()
    {
        // Check for left mouse click
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instantiate a new bullet at the firePoint position and rotation
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);

        // Access the Rigidbody component of the bullet and set its velocity
        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();
        if (bulletRb != null)
        {
            bulletRb.velocity = bullet.transform.forward * bulletSpeed;
        }
        else
        {
            Debug.LogError("Bullet prefab must have a Rigidbody component.");
            return; // Exit the method if Rigidbody is not found
        }

        // Destroy the bullet after a specified lifetime
        Destroy(bullet, bulletLifetime);
    }
}
