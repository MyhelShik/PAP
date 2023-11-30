using UnityEngine;

public class ShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 10f;

    public AudioSource sfxAudioSource;
    public ParticleSystem shootingEffect; // Particle System for visual effects
    public Transform vfxSpawnPosition; // Drag and drop the VFX spawn position in the editor

    void Update()
    {
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

        // Play the SFX when shooting
        if (sfxAudioSource != null)
        {
            sfxAudioSource.Play();
        }

        // Spawn the shooting effect at the specified spawn position
        if (shootingEffect != null && vfxSpawnPosition != null)
        {
            shootingEffect.transform.position = vfxSpawnPosition.position;
            shootingEffect.Play();
        }
    }
}