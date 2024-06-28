using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.Camera;

public class DrawResultLine : MonoBehaviour
{
    [SerializeField] LineRenderer lineRenderer;
    [SerializeField] Vector3 startPos, endpos;

    private void SetLine(Vector3 startPos, Vector3 endPos)
    {
        lineRenderer.SetPosition(0, startPos);
        lineRenderer.SetPosition(1, endPos);
    }

    private void OnEnable()
    {
        Player.winEvent += WInListerner;
        TurnManager.resetGame += Reset;
    }
    private void OnDisable()
    {
        Player.winEvent -= WInListerner;
        TurnManager.resetGame -= Reset;
    }
    private void WInListerner(Player obj)
    {
        int count = obj.winBoxList.Count;
        startPos = (obj.winBoxList[0].transform.position);
        startPos.z = -10;

        endpos = (obj.winBoxList[count - 1].transform.position);
        endpos.z = -10;

        SetLine(startPos, endpos);
    }

    private void Reset()
    {
        SetLine(Vector3.zero, Vector3.zero);
    }



}
