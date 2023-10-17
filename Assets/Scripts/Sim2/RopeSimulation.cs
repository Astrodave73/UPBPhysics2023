using UnityEngine;

public class RopeSimulation : MonoBehaviour
{
    public Transform object1;  // Objeto 1 que estará unido por la cuerda
    public Transform object2;  // Objeto 2 que estará unido por la cuerda
    public Transform ropeAttachmentPoint;  // Punto de fijación de la cuerda
    public float forceMagnitude = 10f;  // Magnitud de la fuerza aplicada a uno de los objetos

    private ConfigurableJoint joint;

    void Start()
    {
        // Configurar el ConfigurableJoint
        joint = ropeAttachmentPoint.gameObject.AddComponent<ConfigurableJoint>();
        joint.connectedBody = object1.GetComponent<Rigidbody>();
        joint.xMotion = ConfigurableJointMotion.Locked;
        joint.yMotion = ConfigurableJointMotion.Locked;
        joint.zMotion = ConfigurableJointMotion.Locked;

        // Aplicar una fuerza inicial a object1 para que se mueva hacia arriba
        object1.GetComponent<Rigidbody>().AddForce(Vector3.up * forceMagnitude, ForceMode.Impulse);
    }

    void Update()
    {
        // Aplicar una fuerza inversa a object2 para que se mueva en la dirección opuesta
        Vector3 forceDirection = (ropeAttachmentPoint.position - object2.position).normalized;
        object2.GetComponent<Rigidbody>().AddForce(forceDirection * forceMagnitude, ForceMode.Force);
    }
}
