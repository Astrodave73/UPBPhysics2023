using UnityEngine;
using UnityEngine.UI;

public class Energy : MonoBehaviour
{
    [SerializeField] Shooter constanteResorte; // Constante del resorte (k) +eformaci�n del resorte
    [SerializeField] Shooter deformacionResorte; // Deformaci�n del resorte
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

        // Calcula la energ�a cin�tica
        float energiaCinetica = 0.5f * rb.mass * velocidad * velocidad;

        // Calcula la energ�a potencial el�stica
        float energiaPotencialElastica = 0.5f * constanteResorte.k * deformacionResorte.compression * deformacionResorte.compression;

        //Calcula la ener�a potencial 
        float energiaPotencial = rb.mass * Physics.gravity.y * (height.transform.position.y-rb.gameObject.transform.position.y);

        // Actualiza los valores de los sliders
        energiaPotencialSlider.value = energiaPotencial;
        energiaCineticaSlider.value = energiaCinetica;
        energiaPotencialElasticaSlider.value = energiaPotencialElastica ;
    }
}
