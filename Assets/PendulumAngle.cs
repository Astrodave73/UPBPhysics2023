using TMPro;
using UnityEngine;

public class PendulumAngleWithLineRenderer : MonoBehaviour
{
    [SerializeField] TMP_Text angleText;
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Transform puntoAnclaje1;
    [SerializeField] Transform puntoAnclaje2;

    private Vector3[] linePositions;
    private int currentPosition = 0;
    private float maxAngle = 0f; // Variable para rastrear el máximo ángulo alcanzado

    void Start()
    {
        linePositions = new Vector3[lineRenderer.positionCount];
        lineRenderer.positionCount = 0;
    }

    void Update()
    {
        // Calcula el vector desde el puntoAnclaje1 al puntoAnclaje2
        Vector3 anchorVector = puntoAnclaje2.position - puntoAnclaje1.position;

        // Calcula el ángulo en radianes entre el vector y el eje hacia arriba (por ejemplo, Vector3.up)
        float angleInRadians = Vector3.Angle(anchorVector, Vector3.up) * Mathf.Deg2Rad;

        // Convierte el ángulo a grados
        float angleInDegrees = angleInRadians * Mathf.Rad2Deg;

        // Si el ángulo actual es mayor que el máximo registrado, actualiza el máximo
        if (angleInDegrees > maxAngle)
        {
            maxAngle = angleInDegrees;
        }

        // Muestra el máximo ángulo alcanzado en el TextMeshPro
        angleText.text = "Ángulo Máximo: " + maxAngle.ToString("F2") + "°";

        // Agrega el ángulo actual al registro de posiciones
        if (currentPosition < linePositions.Length)
        {
            linePositions[currentPosition] = puntoAnclaje1.position + anchorVector;
            currentPosition++;
        }

        // Actualiza el Line Renderer
        lineRenderer.positionCount = currentPosition;
        lineRenderer.SetPositions(linePositions);
    }
}
