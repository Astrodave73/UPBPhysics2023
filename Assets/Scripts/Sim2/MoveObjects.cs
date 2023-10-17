using UnityEngine;

public class MoveObjects : MonoBehaviour
{
    public Transform leftObject; // Asigna el objeto izquierdo en el Inspector
    public Transform rightObject; // Asigna el objeto derecho en el Inspector

    private Vector3 initialPositionLeft;
    private Vector3 initialPositionRight;

    void Start()
    {
        initialPositionLeft = leftObject.position;
        initialPositionRight = rightObject.position;
    }

    void Update()
    {
        // Mueve el objeto izquierdo y el objeto derecho inversamente
        float moveAmount = Input.GetAxis("Horizontal"); // Puedes usar otra entrada según tus necesidades

        leftObject.position = initialPositionLeft + Vector3.right * moveAmount;
        rightObject.position = initialPositionRight - Vector3.right * moveAmount;
    }
}