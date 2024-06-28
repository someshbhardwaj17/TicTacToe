using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WinManager : MonoBehaviour
{
    [SerializeField] PlaneTweener2 winPanel;
    [SerializeField] TMP_Text winMessage, headingText;

    private void OnEnable()
    {
        Player.winEvent += WinListerner;
        Player.drawEvent += DrawListerner;
    }

    private void WinListerner(Player obj)
    {
        Debug.Log("win listener");
        headingText.text = "Congratulations !";
        if (GameSettings.gameType == GameSettings.GameType.SinglePlayer)
        {
            if (obj.playerType == Player.PlayerType.Bot)
            {
                headingText.text = "Game Result ";
                winMessage.text = string.Format(" You Loss ");
            }
            else
                winMessage.text = string.Format(" You win ");
        }
        else
            winMessage.text = string.Format("Hurrah ! {0} wins. ", obj.name);

        winPanel.OpenPanel();
    }

    private void OnDisable()
    {
        Player.winEvent -= WinListerner;
        Player.drawEvent -= DrawListerner;
    }
    private void DrawListerner(Player obj)
    {
        Debug.Log("turn count : " + TurnManager.turnsCount);
        headingText.text = "Draw !";
        winMessage.text = string.Format(" Game Draw! ");

        winPanel.OpenPanel();
    }

}
