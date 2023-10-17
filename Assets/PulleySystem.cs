using UnityEngine;

public class PulleySystem : MonoBehaviour
{
    public Transform objetoAtado1;
    public Transform objetoAtado2;
    public Transform puntoDeGiro;

    private Rigidbody rbObjetoAtado1;
    private Rigidbody rbObjetoAtado2;
    private float longitudInicial;

    private void Start()
    {
        rbObjetoAtado1 = objetoAtado1.GetComponent<Rigidbody>();
        rbObjetoAtado2 = objetoAtado2.GetComponent<Rigidbody>();

        // Calcula la longitud inicial de la cuerda
        longitudInicial = Vector3.Distance(objetoAtado1.position, puntoDeGiro.position) +
                         Vector3.Distance(objetoAtado2.position, puntoDeGiro.position);
    }

    private void Update()
    {
        // Calcula la longitud actual de la cuerda
        float longitudActual = Vector3.Distance(objetoAtado1.position, puntoDeGiro.position) +
                              Vector3.Distance(objetoAtado2.position, puntoDeGiro.position);

        // Calcula la diferencia entre la longitud actual y la inicial
        float diferenciaLongitud = longitudActual - longitudInicial;

        // Aplica fuerza para mantener la longitud de la cuerda constante
        Vector3 direccionTension = (objetoAtado1.position - puntoDeGiro.position).normalized +
                                   (objetoAtado2.position - puntoDeGiro.position).normalized;

        // Calcula la fuerza necesaria para mantener la longitud constante
        Vector3 fuerzaTension = -direccionTension * diferenciaLongitud * 50f; // Ajusta el valor según sea necesario

        rbObjetoAtado1.AddForce(fuerzaTension);
        rbObjetoAtado2.AddForce(fuerzaTension);
    }
}
