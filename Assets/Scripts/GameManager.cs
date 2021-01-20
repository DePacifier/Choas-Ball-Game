using System;
using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public GoalScript blue, green, red, orange;
    public GameObject gameBalls;
    public GameObject chaosBalls;
    private GameObject InstantiatedChaosObjects;
    private GameObject InstantiatedGameBallObjects;
    private bool isGameOver = false;
    private bool gameStarted = false;
    private float startTime;
    private float finishTime;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        isGameOver = blue.isSolved && green.isSolved && red.isSolved && orange.isSolved;
        if (isGameOver)
        {
            gameStarted = false;
            Destroy(InstantiatedChaosObjects);
            Destroy(InstantiatedGameBallObjects);
        }
        
        if (!gameStarted || isGameOver)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                startGame();
                gameStarted = true;
            }
        }
        
    }

    private void OnGUI()
    {
        if (isGameOver)
        {
            Rect rect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 45, 200, 90);
            GUI.Box(rect, "Game Over");
            Rect rect2 = new Rect(Screen.width / 2 - 30, Screen.height / 2 - 30, 60, 60);
            GUI.Label(rect2, "Good Job");
            Rect rect3 = new Rect(Screen.width / 2 - 100, 15, 200, 30);
            GUI.Box(rect3, $"Finish Time: {finishTime:F2}");
            Rect rect4 = new Rect(Screen.width / 2 - 95, Screen.height / 2 - 17, 200, 30);
            GUI.Label(rect4, "Press Enter to Restart Game");
        }else if (!gameStarted)
        {
            Rect rect = new Rect(Screen.width / 2 - 100, Screen.height / 2 - 15, 200, 30);
            GUI.Box(rect, "Press Enter to start Game");
        }

        if (gameStarted)
        {
            Rect rect = new Rect(Screen.width / 2 - 100, 15, 200, 30);
            finishTime = Time.time - startTime;
            GUI.Box(rect, $"Time: {finishTime:F2}");
        }
    }

    private void startGame()
    {
        startTime = Time.time;
        InstantiatedChaosObjects = Instantiate(chaosBalls, Vector3.zero, Quaternion.identity);
        InstantiatedGameBallObjects = Instantiate(gameBalls, Vector3.zero, Quaternion.identity);
        blue.RestartGoals();
        green.RestartGoals();
        red.RestartGoals();
        orange.RestartGoals();
    }
}
