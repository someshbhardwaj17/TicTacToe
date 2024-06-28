using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameClick : MonoBehaviour
{

    [SerializeField] Button playWithComputerBtn, playWithFriendsBtn,playBtn;

    [SerializeField] Toggle esyToggle,mediumToggle,hardToggle;
    void Start()
    {
        playWithComputerBtn.onClick.AddListener(ComputerBtnClick);
        playWithFriendsBtn.onClick.AddListener(OnClickPlayWithFriendsBtn);
        playBtn.onClick.AddListener(OnClickPlayBtn);
    }
    private void SetEasyGameLevel()
    {
        GameSettings.gameLevel = GameSettings.GameLevel.Easy;
    }
    private void SetMediumGameLevel()
    {
        GameSettings.gameLevel = GameSettings.GameLevel.Medium;
    }
    private void SetHardGameLevel()
    {
        GameSettings.gameLevel = GameSettings.GameLevel.Hard;
    }
    private void OnClickPlayWithFriendsBtn()
    {
        GameSettings.gameType = GameSettings.GameType.SinglePlayer;
    }

    private void ComputerBtnClick()
    {
        GameSettings.gameType = GameSettings.GameType.Multiplayer;
    }

    private void OpenGameScene()
    {
        SceneManager.LoadScene(SceneData.gameScene);
    }

    private void OnClickPlayBtn()
    {
        if(esyToggle.isOn)
            SetEasyGameLevel();
        else if(mediumToggle.isOn)
            SetMediumGameLevel();
        else
            SetHardGameLevel();

        OpenGameScene();
    }
}
