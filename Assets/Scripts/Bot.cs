using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bot : MonoBehaviour
{

  [SerializeField] Player mainPlayer;
  [SerializeField] Player botPlayer;
  public List<Box> notSelectedList = new List<Box>();
  [SerializeField] GameObject blocker;
  private void Start()
  {
    mainPlayer.imageId = (int)GameSettings.mainPlayerImageType;
    botPlayer.imageId = (int)GameSettings.otherPlayerImageType;

    if (GameSettings.gameType == GameSettings.GameType.Multiplayer)
      Destroy(this);
  }
  Coroutine coroutine;
  private void TurnChangeListerner(int id)
  {
    if (mainPlayer.playerId == id)
      blocker.SetActive(false);
    else
      blocker.SetActive(true);

    if (mainPlayer.playerId == id)
      return;
    if (coroutine != null)
      StopCoroutine(coroutine);

    coroutine = StartCoroutine(WaitBeforePlayTurn());
  }
  WaitForSeconds delay = new WaitForSeconds(1);
  IEnumerator WaitBeforePlayTurn()
  {
    yield return delay;
    PlayTurn();
  }
  private void PlayTurn()
  {
    UpdateNotSelectedList();
    if (notSelectedList.Count == 0)
      return;
    UpdateRecordList(botPlayer.turnsRecordList);

    if (!PlayBotNextMove()) // checking what was the next mokve for bot to make tic tac toe
    {
      UpdateRecordList(mainPlayer.turnsRecordList);
      if (!PlayBotNextMove()) // checking if player next move can make tic tac toe
        notSelectedList[UnityEngine.Random.Range(0, notSelectedList.Count - 1)].OnClickBoxBtn(); // else move random
    }
  }
  private bool PlayBotNextMove()
  {
    if (playerRecordList.Count > (int)GameSettings.gameLevel - 2)
    {
      for (int i = 0; i < notSelectedList.Count; i++)
      {
        if (CheckThisIsWinNumber(notSelectedList[i].boxId))
        {
          notSelectedList[i].OnClickBoxBtn();
          return true;
        }
      }
    }
    return false;
  }

  int count, combinationCount;

  public List<int> playerRecordList = new();
  private bool CheckThisIsWinNumber(int number)
  {
    playerRecordList.Add(number);
    count = 0;
    combinationCount = 0;
    for (int i = 0; i < Combination.winCombinationList.Count; i++)
    {
      if (count == (int)GameSettings.gameLevel)
      {
        if (combinationCount < (int)GameSettings.gameLevel)
        {
          count = 0;
          combinationCount = 0;
        }

      }
      count++;
      for (int j = 0; j < playerRecordList.Count; j++)
      {
        if (Combination.winCombinationList[i] == playerRecordList[j])
        {
          combinationCount++;
        }

        if (combinationCount == (int)GameSettings.gameLevel)
        {
          return true;
        }
      }
    }
    playerRecordList.RemoveAt(playerRecordList.Count - 1);
    return false;
  }

  private void UpdateRecordList(List<Box> recordList)
  {
    playerRecordList.Clear();
    for (int i = 0; i < recordList.Count; i++)
    {
      playerRecordList.Add(recordList[i].boxId);
    }
  }
  private void UpdateNotSelectedList()
  {
    notSelectedList.Clear();
    for (int i = 0; i < LevelManager.totoalBoxes.Length; i++)
    {
      if (!LevelManager.totoalBoxes[i].isSelected)
        notSelectedList.Add(LevelManager.totoalBoxes[i]);
    }
  }
  private void OnEnable()
  {
    TurnManager.TurnChangeEvent += TurnChangeListerner;
  }
  private void OnDisable()
  {
    TurnManager.TurnChangeEvent -= TurnChangeListerner;
  }


}
