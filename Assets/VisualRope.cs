using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class VisualRope : MonoBehaviour
{
    [SerializeField] ConfigurableJoint joint;
    [SerializeField] TMP_Text lText;
    [SerializeField] Transform puntoAnclaje1;
    [SerializeField] Transform puntoAnclaje2;
    [SerializeField] TMP_InputField inputField; // Campo de texto para ingresar el valor

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2; // Dos posiciones para los extremos de la cuerda
    }

    void Update()
    {
        lineRenderer.SetPosition(0, puntoAnclaje1.position);
        lineRenderer.SetPosition(1, puntoAnclaje2.position);

        // Actualiza el anchor del ConfigurableJoint desde el valor del campo de texto
        if (float.TryParse(inputField.text, out float nuevoValor))
        {
            Vector3 nuevoAnchor = joint.anchor;
            nuevoAnchor.y = nuevoValor;
            joint.anchor = nuevoAnchor;
        }

        lText.text = "L= " + joint.anchor.y.ToString("F2") + "m";
    }
}
