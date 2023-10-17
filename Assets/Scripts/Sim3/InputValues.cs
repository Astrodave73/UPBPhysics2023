using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InputValues : MonoBehaviour
{
   [SerializeField] TMP_InputField massField;
    [SerializeField] Shooter kValue;
    public int valueToAssign;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        if (int.TryParse(massField.text, out int parsedValue))
        {
            if(valueToAssign >= 0) {
                valueToAssign = parsedValue;
              //  rb.mass = valueToAssign;
            }
            else
            {
                Debug.LogError("Invalid input. Please enter a valid number.");
            }
        }
       
    }
   // rb.mass = massField.;
    }

