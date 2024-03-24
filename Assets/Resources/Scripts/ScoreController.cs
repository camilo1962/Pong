using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using System;

public class ScoreController : MonoBehaviour 
{
    public static string winnerName; // Variable estática para almacenar el nombre del ganador
    private int scorePlayer1 = 0;
	private int scorePlayer2 = 0;

	public GameObject scoreTextPlayer1;
	public GameObject scoreTextPlayer2;

	public int goalToWin;
	public TMP_InputField goalInputField;

    private TMP_InputField GetGoalInputField()
    {
        return goalInputField;
    }

    public void Start()
    {
        // Agrega un listener al InputField para que llame al método UpdateGoalToWin cada vez que cambie el valor
        goalInputField.onValueChanged.AddListener(delegate {
            UpdateGoalToWin(goalInputField);
        });

        // Inicializa goalToWin con el valor ingresado por defecto
        UpdateGoalToWin(goalInputField);
    }


    // Método para actualizar goalToWin basado en el valor ingresado en el InputField
    public void UpdateGoalToWin(TMP_InputField inputField)
    {
        if (int.TryParse(inputField.text, out int result))
        {
            goalToWin = result;
        }
        else
        {
            Debug.LogError("InputField value is not a valid integer!");
        }
    }

    public void Update ()

	{
        // Verifica si alguno de los jugadores ha alcanzado la cantidad de goles necesarios para ganar
        if (scorePlayer1 >= goalToWin || scorePlayer2 >= goalToWin)
        {
            // Establece el ganador y carga la escena GameOver
            if (scorePlayer1 >= goalToWin)
                winnerName = "Camilo";
            else
                winnerName = "IA Mar";
            SceneManager.LoadScene("GameOver");
        }
        //if (this.scorePlayer1 >= this.goalToWin)
        //{
        //    ScoreController.winnerName = "Camilo";
        //    SceneManager.LoadScene("GameOver");
        //}
        //if (this.scorePlayer2 >= this.goalToWin)
        //{
        //    ScoreController.winnerName = "IA Mar";
        //    SceneManager.LoadScene("GameOver");
        //}
    }


	private void FixedUpdate()
	{
		Text uiScorePlayer1 = this.scoreTextPlayer1.GetComponent<Text>();
		uiScorePlayer1.text = this.scorePlayer1.ToString();

		Text uiScorePlayer2 = this.scoreTextPlayer2.GetComponent<Text>();
		uiScorePlayer2.text = this.scorePlayer2.ToString();
	}


	// Method to increase Player 1's score
	public void GoalPlayer1()
	{
		this.scorePlayer1++;
	}


	// Method to increase Player 2's score
	public void GoalPlayer2()
	{
		this.scorePlayer2++;
	}
}
