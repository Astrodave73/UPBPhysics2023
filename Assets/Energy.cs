using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [SerializeField] Shooter constanteResorte; // Constante del resorte (k) +eformación del resorte
    [SerializeField] Shooter deformacionResorte; // Deformación del resorte
    private Rigidbody rb; // Masa del cuerpo
    public GameObject height;

    public Slider energiaPotencialSlider;
    public Slider energiaCineticaSlider;
    public Slider energiaPotencialElasticaSlider;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
    {
        // Registra la velocidad del cuerpo
        float velocidad = rb.velocity.magnitude;

        // Calcula la energía cinética
        float energiaCinetica = 0.5f * rb.mass * velocidad * velocidad;

        // Calcula la energía potencial elástica
        float energiaPotencialElastica = 0.5f * constanteResorte.k * deformacionResorte.compression * deformacionResorte.compression;

        //Calcula la enería potencial 
        float energiaPotencial = rb.mass * Physics.gravity.y * (height.transform.position.y-rb.gameObject.transform.position.y);

        // Actualiza los valores de los sliders
        energiaPotencialSlider.value = energiaPotencial;
        energiaCineticaSlider.value = energiaCinetica;
        energiaPotencialElasticaSlider.value = energiaPotencialElastica ;
    }
}
