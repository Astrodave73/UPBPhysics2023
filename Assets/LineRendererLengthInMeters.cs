using UnityEngine;

public class LengthInMeters : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public float unityToMetersScale = 1.0f; // Ajusta esto según la escala de tu proyecto

    private Vector3[] positions;
    private float totalLength = 0f; // Variable de clase para almacenar la longitud

    private void Start()
    {
        // Obtén la lista de puntos (vértices) del Line Renderer
        positions = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(positions);

        // Calcula la longitud sumando las distancias entre puntos consecutivos
        for (int i = 0; i < positions.Length - 1; i++)
        {
            totalLength += Vector3.Distance(positions[i], positions[i + 1]);
        }

        // Aplica la escala para convertir de unidades de Unity a metros
        float lengthInMeters = totalLength * unityToMetersScale;

        Debug.Log("Longitud total del Line Renderer en metros: " + lengthInMeters + " metros.");
    }

    private void Update()
    {
        // Puedes actualizar la longitud en Update si necesitas seguimiento en tiempo real
        // No necesitas calcularla nuevamente, ya que se calculó en Start
        // Esto es útil si el Line Renderer cambia en tiempo real

        Debug.Log("Longitud total del Line Renderer en metros (actualizada en Update): " + totalLength * unityToMetersScale + " metros.");
    }
}
