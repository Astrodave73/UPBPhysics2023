using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class MassChanger : MonoBehaviour
{
    Rigidbody rb;
    [SerializeField] TMP_InputField mass_IF;
    // Start is called before the first frame update
    void Start()
    {
     rb = GetComponent<Rigidbody>();   
    }

    // Update is called once per frame
    void Update()
    {
        if (float.TryParse(mass_IF.text, out float nuevoValor)) {
            rb.mass = nuevoValor;
                }
    }
}
