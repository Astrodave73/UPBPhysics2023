using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DentedPixel;
using UnityEngine.UI;
using TMPro;

public class Shooter : MonoBehaviour
{
    [SerializeField] Rigidbody rb;
    Transform disparadorObj;
    [SerializeField] SpringDrag springDrag;
    public float k;
    [SerializeField] TMP_InputField inputFieldK;
    int valueToAssign;
    bool hasLaunched;
    bool isSpringActive = false;
    [SerializeField] TMP_Text springForceText;
    public float compression;

    Vector3 initialPosition;
    Vector3 positionOffset;

    void Start()
    {
        disparadorObj = GetComponent<Transform>();
        initialPosition = transform.position;
        positionOffset = transform.position - rb.position;
        k = 100;
    }

    void Update()
    {
        compression = CalculateSpringForce();
        if (int.TryParse(inputFieldK.text, out int parsedValue))
        {
            if (valueToAssign >= 0)
            {
                valueToAssign = parsedValue;
                k = valueToAssign;
            }
            else
            {
                Debug.LogError("Invalid input. Please enter a valid number.");
            }
        }

        if (!hasLaunched)
        {
            disparadorObj.transform.position = rb.position + positionOffset;
        }

        // Registra la compresión del resorte
        compression = springDrag.xDistance;

        if (Input.GetKeyDown(KeyCode.Space) && !hasLaunched)
        {
            disparadorObj.transform.LeanMove(initialPosition, 0.1f);
            ActivateSpring();
            Shooting();
            hasLaunched = true;

            // Restablece la compresión a cero después de lanzar el objeto
            compression = 0f;
        }

        if (Input.GetKeyUp(KeyCode.Space) && hasLaunched)
        {
            DeactivateSpring();
        }

    }

    public void Shooting()
    {
        if (isSpringActive)
        {
            Vector3 springForce = rb.transform.forward * CalculateSpringForce();
            rb.AddForce(springForce, ForceMode.Impulse);

            // Actualiza el texto de springForceText con el valor de la fuerza del resorte
            springForceText.text = "Fuerza del Resorte= " + CalculateSpringForce().ToString("F2") + " N";

            print(Vector3.left * CalculateSpringForce());

            hasLaunched = false;
            isSpringActive = false;
        }
    }

    public void ActivateSpring()
    {
        isSpringActive = true;
    }

    public void DeactivateSpring()
    {
        isSpringActive = false;
    }

    public float CalculateSpringForce()
    {
        if (isSpringActive)
        {
            float result = 0.5f * k * springDrag.xDistance * springDrag.xDistance * springDrag.direction;
            return result;
        }
        return 0f;
    }
}
