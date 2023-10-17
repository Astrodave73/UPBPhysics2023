using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LineAndValueDisplay : MonoBehaviour
{
    public Transform pointA; // Punto A
    public Transform pointB; // Punto B
    public LineRenderer lineRenderer;
    public TMP_Text valueText;

    private void Start()
    {
        lineRenderer.positionCount = 2;
    }

    private void Update()
    {
        // Actualizar la posición de los puntos A y B
        lineRenderer.SetPosition(0, pointA.position);
        lineRenderer.SetPosition(1, pointB.position);

        // Calcular y mostrar la distancia entre los puntos A y B en el Texto UI
        float distance = Vector3.Distance(pointA.position, pointB.position);
        valueText.text = "Distancia: " + distance.ToString("F2"); // Formato de dos decimales
    }
}
