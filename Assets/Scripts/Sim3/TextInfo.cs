using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TextInfo : MonoBehaviour
{
    [SerializeField] TMP_Text massText;
    [SerializeField] Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        massText.text = "MASA= " + rb.mass.ToString() + " kg.";
    }
}
