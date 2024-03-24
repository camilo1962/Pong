using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayButton : MonoBehaviour
{
    public Text winnerText;
    public Image winnerImagen1;
    public Image winnerImagen2;

    void Start()
    {
        // Mostrar el nombre del ganador en el texto
        winnerText.text = "Gana " + ScoreController.winnerName;

        if (ScoreController.winnerName == "Camilo")
        {
            winnerImagen1.gameObject.SetActive(true);
            winnerImagen2.gameObject.SetActive(false); // Asegúrate de que solo una imagen esté activa
        }
        else if (ScoreController.winnerName == "IA Mar") // Cambié el segundo 'if' por 'else if' para que solo se active uno
        {
            winnerImagen1.gameObject.SetActive(false); // Asegúrate de que solo una imagen esté activa
            winnerImagen2.gameObject.SetActive(true);
        }
    }

    public void PlayGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void Salir()
    {
        Application.Quit();
    }
}
