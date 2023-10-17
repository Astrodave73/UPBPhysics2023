using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class PauseGame : MonoBehaviour
{
    private bool estaPausado;
    public TMP_Text estadoTexto; // Texto para mostrar el estado (pausado/reproducir)

    private void Start()
    {
        
        CambiarEstado();
    }

    public void CambiarEstado()
    {
        estaPausado = !estaPausado;
        CambiarEstadoTexto();

        if (estaPausado)
        {
            Time.timeScale = 0f; // Pausar el juego
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el juego
        }
    }

    void CambiarEstadoTexto()
    {
        estadoTexto.text = estaPausado ? "Iniciar" : "Pausa";
    }
}