using UnityEngine;

public class VisualizarCuerda : MonoBehaviour
{
    public Transform objetoConSpringJoint1;
    public Transform objetoConSpringJoint2;
    public float offset;

    private LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
    }

    void Update()
    {
        if (objetoConSpringJoint1 != null && objetoConSpringJoint2 != null)
        {
            // Actualiza las posiciones de la línea con las posiciones de los objetos conectados.
            lineRenderer.SetPosition(0, new Vector3(objetoConSpringJoint1.position.x, objetoConSpringJoint1.position.y + offset, objetoConSpringJoint1.position.z));
            lineRenderer.SetPosition(1, objetoConSpringJoint2.position);
        }
    }
}
