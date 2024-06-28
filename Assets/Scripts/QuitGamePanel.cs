using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class QuitGamePanel : MonoBehaviour
{
    [SerializeField] PlaneTweener2 quitPanel;
    [SerializeField] string message;
    [SerializeField] TMP_Text messageTextField;
    [SerializeField] Button quitBtn;
    [SerializeField] int openScene;

    private void Start()
    {
        quitBtn.onClick.AddListener(OnClickExitBtn);
    }

    private void OnClickExitBtn()
    {
        if (openScene < 0)
            Application.Quit();
        else
            SceneManager.LoadScene(openScene);
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            messageTextField.text = message;
            quitPanel.OpenPanel();
        }
    }
}
