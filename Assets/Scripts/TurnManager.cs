using System;
using UnityEngine;

public class TurnManager : MonoBehaviour
{
    public static Action<int> TurnChangeEvent;
    public static Action resetGame;
    public int currenTurnId;
    public static int turnsCount;

    void Start()
    {
        Toss();
    }
    private void Toss()
    {
        turnsCount = 0;
        GameManager.gameState = GameManager.GameState.Running;
        int id = UnityEngine.Random.Range(0, 2);
        currenTurnId = id;
        TurnChangeEvent?.Invoke(currenTurnId);
    }

    private void OnEnable()
    {
        Player.turnCompleteEvent += ChangeTurn;
    }
    private void OnDisable()
    {
        Player.turnCompleteEvent -= ChangeTurn;
    }
    private void ChangeTurn()
    {
        if (GameManager.gameState != GameManager.GameState.Running)
            return;

        if (currenTurnId == 0)
        {
            currenTurnId = 1;
        }
        else
        {
            currenTurnId = 0;
        }
        TurnChangeEvent?.Invoke(currenTurnId);
    }

    public void ResetGame()
    {
        TurnManager.resetGame?.Invoke();
        turnsCount = 0;
        Toss();
    }


}
