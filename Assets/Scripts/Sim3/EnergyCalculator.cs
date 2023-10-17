using UnityEngine;
using UnityEngine.UI;

public class EnergyCalculator : MonoBehaviour
{
    public Slider potentialEnergySlider;
    public Slider kineticEnergySlider;
    private Rigidbody rb;
    float minheight, maxheight;
    private float totalEnergy;

    // Velocidad de suavizado, ajusta seg�n sea necesario
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
        // Calcular la energ�a potencial y cin�tica actuales
        float currentPotentialEnergy = CalculatePotentialEnergy();
        float currentKineticEnergy = CalculateKineticEnergy();

        // Calcular la suma total de energ�a
        totalEnergy = currentPotentialEnergy + currentKineticEnergy;

        // Calcular la diferencia entre las energ�as actuales y las del slider
        float potentialEnergyDifference = currentPotentialEnergy - potentialEnergySlider.value;
        float kineticEnergyDifference = currentKineticEnergy - kineticEnergySlider.value;

        // Aplicar suavizado a los valores de los sliders
        potentialEnergySlider.value += potentialEnergyDifference * Time.deltaTime * smoothingSpeed;
        kineticEnergySlider.value += kineticEnergyDifference * Time.deltaTime * smoothingSpeed;

        // Asegurarse de que la suma total de energ�a sea constante
        float energyDifference = totalEnergy - (currentPotentialEnergy + currentKineticEnergy);

        // Calcular la diferencia en velocidad necesaria para mantener la energ�a constante
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

    // Funci�n para calcular la energ�a cin�tica
    private float CalculateKineticEnergy()
    {
        return 0.5f * rb.mass * rb.velocity.sqrMagnitude;
    }

    // Funci�n para calcular la suma total de energ�a
    private float CalculateTotalEnergy()
    {
        return CalculatePotentialEnergy() + CalculateKineticEnergy();
    }

    // Funci�n para actualizar ambos sliders en proporci�n a la suma total de energ�a
    private void UpdateSliders()
    {
        float currentTotalEnergy = potentialEnergySlider.value + kineticEnergySlider.value;

        if (currentTotalEnergy > 0)
        {
            float potentialEnergyRatio = potentialEnergySlider.value / currentTotalEnergy;
            float kineticEnergyRatio = kineticEnergySlider.value / currentTotalEnergy;

            // Ajustar los sliders para mantener la misma proporci�n
            potentialEnergySlider.value = potentialEnergyRatio * totalEnergy;
            kineticEnergySlider.value = kineticEnergyRatio * totalEnergy;
        }
        else
        {
            // Si la suma total de energ�a es cero, establecer ambos sliders en cero
            potentialEnergySlider.value = 0;
            kineticEnergySlider.value = 0;
        }
    }
}
