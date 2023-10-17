using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HelicopterMovement : MonoBehaviour
{
    Transform helicopterIniPos;
    private Rigidbody rb;
    public float forwardSpeed = 80.0f; // Velocidad hacia adelante en metros por segundo
    [SerializeField] Slider speedSlider;
    [SerializeField] TMP_Text speedText;

    void Start()
    {
        helicopterIniPos = GetComponent<Transform>();
        helicopterIniPos.position = new Vector3 (-160, 180, 0);
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        Vector3 forwardDirection = transform.forward ;

        if (speedSlider.value == 1)
        {
            rb.velocity = forwardDirection * 60;
        }
        else if (speedSlider.value == 2)
        {
            rb.velocity = forwardDirection * 80;
        }

        else if (speedSlider.value == 3)
        {
            rb.velocity = forwardDirection * 100;
        }

        speedText.text = "Rapidez del Helicoptero: " + rb.velocity.x.ToString("F2") + "m/s";
    }
    //void FixedUpdate()
    //{
    //    if (speedSlider.value == 1)
    //    {
    //        // Calcula la velocidad necesaria para alcanzar 60 m/s hacia adelante
    //        Vector3 desiredVelocity = transform.forward * 60;
    //        // Calcula la fuerza requerida para alcanzar la velocidad deseada
    //        Vector3 force = (desiredVelocity - rb.velocity) * rb.mass / Time.fixedDeltaTime;
    //        // Aplica la fuerza al helicóptero
    //        rb.AddForce(force, ForceMode.Force);
    //    }
    //    if (speedSlider.value == 2)
    //    {
    //        // Calcula la velocidad necesaria para alcanzar 80 m/s hacia adelante
    //        Vector3 desiredVelocity = transform.forward * 80;
    //        // Calcula la fuerza requerida para alcanzar la velocidad deseada
    //        Vector3 force = (desiredVelocity - rb.velocity) * rb.mass / Time.fixedDeltaTime;
    //        // Aplica la fuerza al helicóptero
    //        rb.AddForce(force, ForceMode.Force);
    //    }
    //    if (speedSlider.value == 3)
    //    {
    //        // Calcula la velocidad necesaria para alcanzar 100 m/s hacia adelante
    //        Vector3 desiredVelocity = transform.forward * 100;
    //        // Calcula la fuerza requerida para alcanzar la velocidad deseada
    //        Vector3 force = (desiredVelocity - rb.velocity) * rb.mass / Time.fixedDeltaTime;
    //        // Aplica la fuerza al helicóptero
    //        rb.AddForce(force, ForceMode.Force);
    //    }

    //    speedText.text = "Rapidez del helicóptero: " + rb.velocity.x.ToString() + "m/s";

    //}
}
