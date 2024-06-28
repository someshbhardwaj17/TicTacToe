using System;
using UnityEngine;
public class PlaneTweener2 : PlaneTweener
{

    RectTransform rectTransform;
    public static Action<bool> IsPanelOpen;

    bool isOpen = false;

    int id7, id8, id9, id10, id11, id12;
    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canstart = true;
    }


    public override void Reset()
    {
        base.Reset();
    }

    public override void OpenPanel()
    {
        if (!canstart)
            return;
        if (isOpen)
            return;

        canstart = false;
        isOpen = true;

        if (background != null)
        {
            background.OpenPanel();
        }

        gameObject.SetActive(true);
        SetBackground(true);
        IsPanelOpen?.Invoke(true);
        SetCloseButtonInteractability(false);
        switch (effect)
        {
            case Effect.Color:
                id7 = LeanTween.alpha(rectTransform, 0, 0).id;
                id8 = LeanTween.alpha(rectTransform, 1, openDuration).setEase(openTween).setOnComplete(() => 
                {
                    OpenEndEvent?.Invoke();
                    canstart = true;
                    SetCloseButtonInteractability(true); }).setOnStart(() => { OpenStartEvent?.Invoke(); }).id;

                break;
            case Effect.Move:

                break;
            case Effect.Scale:
                transform.localScale = Vector3.one * scaleDown;
                id9 = LeanTween.scale(gameObject, Vector3.one * scaleUP, openDuration).setEase(openTween).setOnComplete(() => 
                {
                    canstart = true;
                    OpenEndEvent?.Invoke();
                    SetCloseButtonInteractability(true); }).setOnStart(() => { OpenStartEvent?.Invoke(); }).id;
                break;
        }

    }

    public override void ClosePanel()
    {
        if (!isOpen)
            return;
        if (!canstart)
            return;
        canstart = false;
        if (background != null)
            background.ClosePanel();

        SetCloseButtonInteractability(false);
        switch (effect)
        {
            case Effect.Color:
                id10 = LeanTween.alpha(rectTransform, 1, 0).id;
                id11 = LeanTween.alpha(rectTransform, 0, closeDuration).setOnComplete(Close).setEase(openTween).setOnStart(() => { CloseStartEvent?.Invoke(); }).id;

                break;
            case Effect.Move:

                break;
            case Effect.Scale:
                transform.localScale = Vector3.one * scaleUP;
                id12 = LeanTween.scale(gameObject, Vector3.one * scaleDown, closeDuration).setEase(closeTween).setOnComplete(Close).setOnStart(() => { CloseStartEvent?.Invoke(); }).id;
                break;
        }
    }

    void SetBackground(bool value)
    {
        if (bg != null)
            bg.SetActive(value);
    }
    void SetCloseButtonInteractability(bool value)
    {
        if (closeButton != null)
            closeButton.interactable = value;
    }


    public override void Close()
    {
        IsPanelOpen?.Invoke(false);
        canstart = true;
        isOpen = false;
        SetBackground(false);
        gameObject.SetActive(false);
        CloseEndEvent?.Invoke();
    }

    private void OnDestroy()
    {
        if (LeanTween.isTweening(id7))
            LeanTween.cancel(id7);
        if (LeanTween.isTweening(id8))
            LeanTween.cancel(id8);
        if (LeanTween.isTweening(id9))
            LeanTween.cancel(id9);
        if (LeanTween.isTweening(id10))
            LeanTween.cancel(id10);
        if (LeanTween.isTweening(id11))
            LeanTween.cancel(id11);
        if (LeanTween.isTweening(id12))
            LeanTween.cancel(id12);

    }
}
