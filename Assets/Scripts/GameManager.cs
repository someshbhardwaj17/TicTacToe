using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : Singleton<GameManager>
{
  [SerializeField] Player playerB;
  public enum GameState {Running,Completed };
  public static GameState gameState;
  
  public void Start()
  {
    Input.multiTouchEnabled = false;
    Combination.winCombinationList = GenrateCombinationList((int)GameSettings.gameLevel);
    if (GameSettings.gameType == GameSettings.GameType.SinglePlayer)
      playerB.playerType = Player.PlayerType.Bot;
    else
      playerB.playerType = Player.PlayerType.Normal;
  }
  [SerializeField] List<int> combinationList = new();

  public List<int> GenrateCombinationList(int matrixby)
  {
    combinationList.Clear();
    for (int i = 1; i <= matrixby * matrixby; i++)
    {
      combinationList.Add(i);
    }
    int c = 0;
    for (int i = 1; i <= matrixby; i++)
    {
      combinationList.Add(i);
      c = i;
      for (int j = 1; j < matrixby; j++)
      {
        c += matrixby;
        combinationList.Add(c);
      }
    }
    c = 0;
    for (int i = 1; i <= matrixby; i++)
    {
      for (int j = 1; j <= matrixby; j++)
      {
        c++;
        if (i == j)
        {
          combinationList.Add(c);
        }
      }
    }
    c = 0;
    for (int i = 1; i <= matrixby; i++)
    {
      for (int j = 1; j <= matrixby; j++)
      {
        c++;
        if ((i + j) == matrixby + 1)
        {
          combinationList.Add(c);
        }
      }
    }

    return combinationList;
  }

}
