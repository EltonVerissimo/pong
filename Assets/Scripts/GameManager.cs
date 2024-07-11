using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform playerPaddle;
    public Transform enemyPadle;
    public BallController ballController;
    public int playerScore = 0;
    public int enemyScore = 0;

    public int WinPoints;

    public TextMeshProUGUI textPointsPlayer;
    public TextMeshProUGUI textPointsEnemy;

    public TextMeshProUGUI playerName;
    public TextMeshProUGUI enemyName;

    public GameObject screenEndGame;
    public TextMeshProUGUI textEndGame;

    // Start is called before the first frame update
    void Start()
    {
        ResetGame();

        playerName.text = SaveController.Instance.GetName(true);
        enemyName.text = SaveController.Instance.GetName(false);

        playerName.color = SaveController.Instance.GetColor(true);
        enemyName.color = SaveController.Instance.GetColor(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            ResetGame();
        }
    }

    public void ResetGame()
    {
        playerPaddle.position = new Vector3(7f, 0f, 0f);
        enemyPadle.position = new Vector3(-7f, 0f, 0f);
        ballController.ResetBall();

        playerScore = 0;
        enemyScore = 0;

        textPointsEnemy.text = enemyScore.ToString();
        textPointsPlayer.text = enemyScore.ToString();

        screenEndGame.SetActive(false);
    }

    public void ScorePlayer()
    {
        playerScore++;
        textPointsPlayer.text = playerScore.ToString();
        CheckWin();
    }

    public void ScoreEnemy()
    {
        enemyScore++;
        textPointsEnemy.text = enemyScore.ToString();
        CheckWin();
    }

    public void CheckWin()
    {
        if(enemyScore >= WinPoints || playerScore >= WinPoints)
        {
            EndGame();
        }
    }

    public void EndGame()
    {
        textEndGame.text = "Jogador " + SaveController.Instance.GetName(playerScore > enemyScore) + " venceu!";
        screenEndGame.SetActive(true);
        Invoke("LoadMenu", 2f);

        string winner = SaveController.Instance.GetName(playerScore > enemyScore);
        SaveController.Instance.SaveWinner(winner);
    }

    private void LoadMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
