using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DistanceCalculator : MonoBehaviour
{
    public Transform pointA; // El primer punto
    public Transform pointB; // El segundo punto
    public TMP_Text distanceText; // Texto para mostrar la distancia
    private float initialDistance;

    private void Start()
    {
        // Calcula la distancia inicial
        initialDistance = Vector3.Distance(pointA.position, pointB.position);
    }

    private void Update()
    {
        // Calcula la distancia entre los dos puntos
        float currentDistance = Vector3.Distance(pointA.position, pointB.position);

        // Calcula el cambio en la distancia desde el valor inicial
        float change = (currentDistance - initialDistance) *-1;

        // Si la distancia cambió, muestra el cambio, de lo contrario, muestra cero
        if (change != 0)
        {
            distanceText.text = "Distancia X: " + change.ToString("F2") + "mm";
        }
        else
        {
            distanceText.text = "Distancia X: 0.00mm";
        }
    }
}
