using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Bullet : MonoBehaviour
{
    private Rigidbody rb;
    private bool enMovimiento = false;
    [SerializeField] GameObject blockGO;
    [SerializeField] TMP_InputField velocidadInput; // Campo de texto para la velocidad en m/s
    [SerializeField] TMP_Text velFinal;

    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Desactiva la f�sica al inicio
        rb.isKinematic = true;
    }

    private void Update()
    {
        rb.gameObject.transform.position = new Vector3(rb.gameObject.transform.position.x, blockGO.transform.position.y, rb.gameObject.transform.position.z);

        if (!enMovimiento)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Shoot();
            }
        }
    }

    public void Shoot()
    {
        // Obtener la velocidad desde el campo de texto y convertirla a un valor num�rico
        if (float.TryParse(velocidadInput.text, out float velocidadMetrosPorSegundo))
        {
            // Activa la f�sica y aplica la velocidad en la direcci�n deseada
            rb.isKinematic = false;
            rb.velocity = transform.forward * velocidadMetrosPorSegundo;
            enMovimiento = true;
            velFinal.text = "Rapidez de la bala = " + velocidadMetrosPorSegundo + "m/s";
        }
        else
        {
            // Manejar el caso en el que la entrada no sea v�lida (puedes mostrar un mensaje de error)
            Debug.LogError("Velocidad de entrada no v�lida");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Block"))
        {
            // Recoger el Rigidbody del bloque
            Rigidbody blockRb = collision.gameObject.GetComponent<Rigidbody>();

            if (blockRb != null)
            {
                // Calcular el momento lineal antes del choque
                Vector3 momentoLinealInicialBala = rb.mass * rb.velocity;

                // Calcular el momento lineal del bloque antes del choque
                Vector3 momentoLinealInicialBloque = blockRb.mass * blockRb.velocity;

                // Calcular el momento lineal total antes del choque
                Vector3 momentoLinealTotalInicial = momentoLinealInicialBala + momentoLinealInicialBloque;

                // Desactivar la f�sica de la bala
                rb.isKinematic = true;

                // Calcular la velocidad final del sistema despu�s del choque (choque inel�stico)
                Vector3 velocidadFinal = momentoLinealTotalInicial / (rb.mass + blockRb.mass);

                // Asignar la velocidad final tanto a la bala como al bloque
                velFinal.text = "Velocidad Final = " + velocidadFinal.x.ToString("F2") + "m/s";
                rb.velocity = velocidadFinal;
                blockRb.velocity = velocidadFinal;

                // Destruir la bala despu�s del choque (puedes manejar el bloque de otra manera)
                Destroy(gameObject);
            }
        }
    }
}