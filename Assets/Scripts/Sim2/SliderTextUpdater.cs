using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SliderTextUpdater : MonoBehaviour
{
    public Slider slider;
    public TMP_Text textToUpdate;
    public Rigidbody rb;
    private string defaultText = "kg"; // Texto inicial predeterminado

    private void Start()
    {
        // Asigna el valor inicial del texto
        textToUpdate.text = defaultText;
        rb.mass = 1.0f;
    }

    private void Update()
    {
        UpdateText();
        UpdateMass();
    }
    public void UpdateText()
    {
        // Actualiza el texto con el valor actual del Slider
        textToUpdate.text =  slider.value.ToString("F1") + " kg"; // Formatea el valor a dos decimales si es necesario
    }
    public void UpdateMass()

    {
        rb.mass = slider.value;
    }
}