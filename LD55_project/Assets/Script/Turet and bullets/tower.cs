using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tower : MonoBehaviour
{
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 1f;
    public float launchForce;
    private float timer;


    void Start()
    {
        timer = fireRate;
    }

    void Update()
    {

    }

    // Déclenché lorsque quelque chose entre dans la zone du déclencheur
    private void OnTriggerStay2D(Collider2D other)
    {
        // Vérifie si l'objet qui est entré est un ennemi (vous pouvez ajouter d'autres conditions ici si nécessaire)
        if (other.CompareTag("Units"))
        {
            timer += Time.deltaTime;

            if (timer >= fireRate)
            {
                if (bulletPrefab != null && firePoint != null)
                {
                    LaunchProjectile(other.gameObject.transform.position);
                }
                timer = 0f;
            }
        }
    }
    void LaunchProjectile(Vector3 targetPosition)
    {
        // Instancie le projectile au point de lancement
        GameObject projectileInstance = Instantiate(bulletPrefab, firePoint.position + new Vector3(0,0,-0.05f), Quaternion.identity);
        
        // Calcule la direction vers la cible
        Vector3 launchDirection = (targetPosition - firePoint.position).normalized;

        // Applique une force au projectile
        Rigidbody2D rb = projectileInstance.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.AddForce(launchDirection * launchForce, ForceMode2D.Impulse);
        }
        float angle = Mathf.Atan2(launchDirection.y, launchDirection.x) * Mathf.Rad2Deg;
        projectileInstance.transform.rotation = Quaternion.AngleAxis(angle+90, Vector3.forward);
    }
}