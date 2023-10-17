using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class ProjectileShooter : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform shootPoint;
    [SerializeField] TMP_Text projectileSpeedText;

    [SerializeField] private Rigidbody helicopterRb; // Rigidbody del helic�ptero
    [SerializeField] private GameObject currentProjectile; // Referencia al proyectil actualmente sostenido

    private void Start()
    {
        //helicopterRb = GetComponent<Rigidbody>(); // Obt�n el Rigidbody del helic�ptero
    }

    void Update()
    {

        //  SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Barco")
        {
            if (currentProjectile == null)
            {

                // Crear el proyectil y hacerlo hijo del helic�ptero
                currentProjectile = Instantiate(projectilePrefab, shootPoint.position, Quaternion.identity);
                currentProjectile.transform.parent = transform;
                ReleaseProjectile();


            }
        }
    }

    public void ReleaseProjectile()
    {
        if (currentProjectile != null)
        {
            Rigidbody rb = currentProjectile.GetComponent<Rigidbody>();

            if (rb != null)
            {
                // Heredar la velocidad del helic�ptero al proyectil
                rb.velocity = helicopterRb.velocity;
            }

            // Desvincular el proyectil del helic�ptero para que caiga
            currentProjectile.transform.parent = null;

            // Actualizar el texto de la velocidad del proyectil
            projectileSpeedText.text = "Rapidez del proyectil: " + rb.velocity.magnitude.ToString("F2") + " m/s";

            currentProjectile = null; // Reiniciar la referencia al proyectil
        }
    }

    public void Reset()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
