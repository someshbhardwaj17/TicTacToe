using System;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] Image imgae, bgImage;
    public int playerId;
    [SerializeField] TMP_Text nameText;
    public List<Box> turnsRecordList = new();
    public List<Box> winBoxList = new();  // used draw line 
    public enum PlayerType { Normal, Bot };
    public PlayerType playerType;
    public static Action<Player> winEvent;
    public static Action<Player> drawEvent;
    public static Action turnCompleteEvent;

    public int imageId;

    [SerializeField] Color32 normalColor, myTurnIndicationColor;
    [SerializeField] GameObject winObj;
    private void Start()
    {
        if (playerType == PlayerType.Bot)
        {
            nameText.text = "Computer";
        }
    }
    int currentTurnId;
    private void TurnListener(int turnId)
    {
        currentTurnId = turnId;
        if (playerId == turnId)
            bgImage.color = myTurnIndicationColor;
        else
            bgImage.color = normalColor;

    }
    private void OnBoxClick(Box box)
    {
        if (box.isSelected)
            return;
        if (GameManager.gameState == GameManager.GameState.Completed)
            return;
        if (playerId != currentTurnId)
            return;
        box.PlayTurn(playerId, imageId);
        turnsRecordList.Add(box);
        TurnManager.turnsCount++;
        if (CheckWin())
        {
            winEvent?.Invoke(this);
            winObj.SetActive(true);
            GameManager.gameState = GameManager.GameState.Completed;
        }
        else
        {
            if (TurnManager.turnsCount == (int)GameSettings.gameLevel * (int)GameSettings.gameLevel)
                drawEvent?.Invoke(this);
        }
        turnCompleteEvent?.Invoke();
    }

    int count;
    [SerializeField] int combinationCount;

    private bool CheckWin()
    {
        if (turnsRecordList.Count < (int)GameSettings.gameLevel)
            return false;

        count = 0;
        combinationCount = 0;
        winBoxList.Clear();
        for (int i = 0; i < Combination.winCombinationList.Count; i++)
        {
            if (count == (int)GameSettings.gameLevel)
            {
                if (combinationCount < (int)GameSettings.gameLevel)
                {
                    count = 0;
                    combinationCount = 0;
                    winBoxList.Clear();
                }

            }
            count++;
            for (int j = 0; j < turnsRecordList.Count; j++)
            {
                if (Combination.winCombinationList[i] == turnsRecordList[j].boxId)
                {
                    winBoxList.Add(turnsRecordList[j]);
                    combinationCount++;
                }

                if (combinationCount == (int)GameSettings.gameLevel)
                {
                    return true;
                }
            }
        }
        return false;
    }

    private void OnEnable()
    {
        TurnManager.TurnChangeEvent += TurnListener;
        Box.onBoxClickEvent += OnBoxClick;
        TurnManager.resetGame += Reset;
    }

    private void OnDisable()
    {
        TurnManager.TurnChangeEvent -= TurnListener;
        Box.onBoxClickEvent -= OnBoxClick;
        TurnManager.resetGame -= Reset;
    }
    public void Reset()
    {
        turnsRecordList.Clear();
        imgae.color = Color.white;
        winObj.SetActive(false);
    }
}
