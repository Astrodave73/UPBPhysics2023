using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RopeConnection : MonoBehaviour
{
    [SerializeField] Transform pos1;
    [SerializeField] Transform pos2;
    [SerializeField] Transform pos3;
    [SerializeField] GameObject pulley;
    [SerializeField] LineRenderer line;

    private float initialDistance;
    private float maxDistance = 2f;

    // Start is called before the first frame update
    void Start()
    {
        line.positionCount = 3;
        initialDistance = Vector3.Distance(pos1.position, pos3.position);
    }

    // Update is called once per frame
    void Update()
    {
        line.SetPosition(0, pos1.position);
        line.SetPosition(1, pos2.position);
        line.SetPosition(2, pos3.position);

        // Calcula la distancia actual entre pos1 y pos3
        float currentDistance = Vector3.Distance(pos1.position, pos3.position);

        // Calcula la diferencia en la distancia actual y la inicial
        float deltaDistance = currentDistance - initialDistance;

        // Limita la diferencia de distancia para que no exceda el valor máximo
        deltaDistance = Mathf.Clamp(deltaDistance, -maxDistance, maxDistance);

        // Calcula la mitad de la diferencia para redistribuir entre pos1 y pos3
        float deltaDistanceHalf = deltaDistance / 2f;

        // Ajusta las posiciones de pos1 y pos3 en función de la mitad de la diferencia
        Vector3 newPos1 = pos1.position + (pos2.position - pos1.position).normalized * deltaDistanceHalf;
        Vector3 newPos3 = pos3.position - (pos3.position - pos2.position).normalized * deltaDistanceHalf;

        pos1.position = newPos1;
        pos3.position = newPos3;

        // Actualiza la distancia inicial
        initialDistance = currentDistance;

        //// Calcula la dirección en la que se mueve pos1
        //Vector3 pos1MovementDirection = pos1.position - newPos1;
        //// Calcula la dirección en la que se mueve pos2
        //Vector3 pos2MovementDirection = pos2.position - pos2.position;

        //// Calcula el ángulo entre las direcciones
        //float angle = Vector3.SignedAngle(pos1MovementDirection, pos2MovementDirection, Vector3.up);

        //// Determina la rotación del pulley en función del ángulo
        //if (angle < 0)
        //{
        //    // Rota "pulley" hacia la izquierda
        //    pulley.transform.Rotate(Vector3.up * Time.deltaTime);
        //}
        //else if (angle > 0)
        //{
        //    // Rota "pulley" hacia la derecha
        //    pulley.transform.Rotate(-Vector3.up * Time.deltaTime);
        //}
    }
}
