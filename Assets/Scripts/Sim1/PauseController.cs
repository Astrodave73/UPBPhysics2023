using UnityEngine;

public class PauseController : MonoBehaviour
{
    private bool isPaused = true;

    private void Start()
    {
        Time.timeScale = 0f; // Pausar el juego al inicio
    }

    

    public void TogglePause()
    {
        isPaused = !isPaused;

        if (isPaused)
        {
            Time.timeScale = 0f; // Pausar el juego
        }
        else
        {
            Time.timeScale = 1f; // Reanudar el juego
        }
    }
}