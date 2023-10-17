using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoleaController : MonoBehaviour
{
    public Transform caja1;  // Asigna las cajas desde el Inspector
    public Transform caja2;
    public float masaCaja1 = 1.0f;  // Masa de las cajas
    public float masaCaja2 = 2.0f;

    private Rigidbody rbCaja1;
    private Rigidbody rbCaja2;
    private float radioPolea;

    private void Start()
    {
        rbCaja1 = caja1.GetComponent<Rigidbody>();
        rbCaja2 = caja2.GetComponent<Rigidbody>();
        radioPolea = Vector3.Distance(transform.position, caja1.position);

        // Calcula la aceleración debido a la gravedad
        float g = Physics.gravity.magnitude;
        float aceleracion = (masaCaja1 - masaCaja2) * g / (masaCaja1 + masaCaja2);

        // Calcula las fuerzas iniciales
        float fuerza1 = masaCaja1 * aceleracion;
        float fuerza2 = masaCaja2 * aceleracion;

        // Aplica las fuerzas iniciales
        rbCaja1.AddForce(Vector3.down * fuerza1);
        rbCaja2.AddForce(Vector3.down * fuerza2);
    }

    private void Update()
    {
        // Actualiza la posición de la polea según el movimiento de las cajas
        Vector3 posicionPolea = new Vector3(caja1.position.x, transform.position.y, caja1.position.z);
        transform.position = posicionPolea;
    }
}