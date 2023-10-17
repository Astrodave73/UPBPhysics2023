using UnityEngine;

public class Proyectil : MonoBehaviour
{
    public GameObject proyectil;
    public float fuerzaLanzamiento = 10f;
    private bool lanzado = false;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !lanzado)
        {
            LanzarProyectil();
        }
    }

    private void LanzarProyectil()
    {
        Rigidbody proyectilRb = proyectil.GetComponent<Rigidbody>();
        proyectilRb.useGravity = true;
        proyectilRb.isKinematic = false;
        proyectilRb.AddForce(transform.up * fuerzaLanzamiento, ForceMode.Impulse);
        lanzado = true;
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (lanzado && !collision.gameObject.CompareTag("Player")) // Cambia "Player" por la etiqueta correcta del objeto al que quieres que se adhiera
        {
            Rigidbody proyectilRb = proyectil.GetComponent<Rigidbody>();
            proyectilRb.isKinematic = true;
            proyectilRb.useGravity = false;
            // Configura el proyectil para que quede pegado al objeto que golpea
            proyectilRb.transform.parent = collision.transform;
        }
    }
}
