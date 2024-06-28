using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnIndicator : MonoBehaviour
{
    [SerializeField] GameObject[] indicators;

    private void OnEnable()
    {
        TurnManager.TurnChangeEvent += TurnListener;
        Player.turnCompleteEvent += TurnCompleteListener;
    }


    private void OnDisable()
    {
        TurnManager.TurnChangeEvent -= TurnListener;
        Player.turnCompleteEvent -= TurnCompleteListener;
    }
    int previousIndex;
    private void TurnListener(int index)
    {
        previousIndex = index;
        indicators[index].SetActive(true);
    }
    private void TurnCompleteListener()
    {
        indicators[previousIndex].SetActive(false);

    }
}
