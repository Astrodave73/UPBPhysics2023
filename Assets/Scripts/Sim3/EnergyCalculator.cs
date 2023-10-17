using UnityEngine;
using UnityEngine.UI;

public class EnergyCalculator : MonoBehaviour
{
    public Slider potentialEnergySlider;
    public Slider kineticEnergySlider;
    private Rigidbody rb;
    float minheight, maxheight;
    private float totalEnergy;

    // Velocidad de suavizado, ajusta según sea necesario
    public float smoothingSpeed = 5.0f;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        minheight = 0.2f;
        maxheight = 5.5f;
        totalEnergy = CalculateTotalEnergy();
        UpdateSliders();
    }

    private void Update()
    {
        // Calcular la energía potencial y cinética actuales
        float currentPotentialEnergy = CalculatePotentialEnergy();
        float currentKineticEnergy = CalculateKineticEnergy();

        // Calcular la suma total de energía
        totalEnergy = currentPotentialEnergy + currentKineticEnergy;

        // Calcular la diferencia entre las energías actuales y las del slider
        float potentialEnergyDifference = currentPotentialEnergy - potentialEnergySlider.value;
        float kineticEnergyDifference = currentKineticEnergy - kineticEnergySlider.value;

        // Aplicar suavizado a los valores de los sliders
        potentialEnergySlider.value += potentialEnergyDifference * Time.deltaTime * smoothingSpeed;
        kineticEnergySlider.value += kineticEnergyDifference * Time.deltaTime * smoothingSpeed;

        // Asegurarse de que la suma total de energía sea constante
        float energyDifference = totalEnergy - (currentPotentialEnergy + currentKineticEnergy);

        // Calcular la diferencia en velocidad necesaria para mantener la energía constante
        float velocityDifference = energyDifference / rb.mass;

        // Aplicar la diferencia de velocidad al objeto
        rb.velocity += new Vector3(0f, velocityDifference, 0f);

        print(CalculatePotentialEnergy());
    }

    private float CalculatePotentialEnergy()
    {
        float heightAboveGround = Mathf.Clamp(transform.position.y - minheight, 0, maxheight - minheight);
        return rb.mass * Physics.gravity.magnitude * heightAboveGround;
    }

    // Función para calcular la energía cinética
    private float CalculateKineticEnergy()
    {
        return 0.5f * rb.mass * rb.velocity.sqrMagnitude;
    }

    // Función para calcular la suma total de energía
    private float CalculateTotalEnergy()
    {
        return CalculatePotentialEnergy() + CalculateKineticEnergy();
    }

    // Función para actualizar ambos sliders en proporción a la suma total de energía
    private void UpdateSliders()
    {
        float currentTotalEnergy = potentialEnergySlider.value + kineticEnergySlider.value;

        if (currentTotalEnergy > 0)
        {
            float potentialEnergyRatio = potentialEnergySlider.value / currentTotalEnergy;
            float kineticEnergyRatio = kineticEnergySlider.value / currentTotalEnergy;

            // Ajustar los sliders para mantener la misma proporción
            potentialEnergySlider.value = potentialEnergyRatio * totalEnergy;
            kineticEnergySlider.value = kineticEnergyRatio * totalEnergy;
        }
        else
        {
            // Si la suma total de energía es cero, establecer ambos sliders en cero
            potentialEnergySlider.value = 0;
            kineticEnergySlider.value = 0;
        }
    }
}
