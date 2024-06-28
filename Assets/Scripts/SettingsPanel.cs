using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SettingsPanel : MonoBehaviour
{
    [SerializeField] Toggle circleToggle,soundToggle,musicToggle,vibrationToggle,notificationToggle;
    [SerializeField] Button saveBtn,rateUs;
    private string playStoreUrl = "https://play.google.com/store/apps/details?id=com.TicTac.TicTacToe";

    public static bool musicFlag,soundFlag,vibrationFlag,notificationFlag;
    void Start()
    {
        OnClickCrossBtn();
        saveBtn.onClick.AddListener(OnClickSaveBtn);

        rateUs.onClick.AddListener(OnClickRateUsBtn);

        UpdateSettings();
    }

    private void OnClickSaveBtn()
    {
        if (circleToggle.isOn)
            OnClickCircleBtn();
        else
            OnClickCrossBtn();
    }
    private void OnClickCrossBtn()
    {

        GameSettings.mainPlayerImageType = GameSettings.InputImageType.Cross;
        GameSettings.otherPlayerImageType = GameSettings.InputImageType.Circle;
    }
    private void OnClickCircleBtn()
    {

        GameSettings.mainPlayerImageType = GameSettings.InputImageType.Circle;
        GameSettings.otherPlayerImageType = GameSettings.InputImageType.Cross;
    }

    private void OnClickRateUsBtn()
    {
        Application.OpenURL(playStoreUrl);
    }

    private void UpdateSettings()
    {
        soundFlag = soundToggle.isOn;
        musicToggle.onValueChanged.AddListener((value) => {
            musicFlag = value;
        });
        soundToggle.onValueChanged.AddListener((value) => {
            soundFlag = value;
        });
        vibrationToggle.onValueChanged.AddListener((value) => {
            vibrationFlag = value;
        });
        notificationToggle.onValueChanged.AddListener((value) => {
            notificationFlag = value;
        });
    }
}
