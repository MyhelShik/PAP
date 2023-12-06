using UnityEngine;
using System.Collections;

public class ShootingScript : MonoBehaviour
{
    public GameObject bulletPrefab;
    public GameObject bulletEffect;
    public Transform firePoint;
    public Transform effectPoint;
    public float bulletSpeed = 10f;
    public float bulletLifetime = 10f;
    public float effectLifetime = 1f;
    public AudioSource sfxAudioSource;

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            Shoot();
            StartCoroutine(TriggerEffect());
        }
    }

    IEnumerator TriggerEffect()
    {
        yield return new WaitForSeconds(0.1f); // Adjust the delay as needed
        Effect();
    }

    void Effect()
    {
        GameObject effect = Instantiate(bulletEffect, effectPoint.position, effectPoint.rotation);
        Destroy(effect, effectLifetime);

        // Play the SFX when shooting
        if (sfxAudioSource != null)
        {
            sfxAudioSource.Play();
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
