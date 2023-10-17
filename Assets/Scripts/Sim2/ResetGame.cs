using UnityEngine;
using UnityEngine.SceneManagement;

public class ResetGame : MonoBehaviour
{
    public void Reiniciar()
    {
        // Obt�n el nombre de la escena actual
        string nombreEscenaActual = SceneManager.GetActiveScene().name;

        // Recarga la escena actual
        SceneManager.LoadScene(nombreEscenaActual);
    }
}