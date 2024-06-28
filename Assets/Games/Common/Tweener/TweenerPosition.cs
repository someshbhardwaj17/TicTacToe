using UnityEngine;
using UnityEngine.Events;

public enum TweenType
{
    Top2Bottom, Bottom2Top, Left2Right, Right2Left, NotificationTop,
    NotificationBottom, LeftSlide, RightSlide, MessagePopup
}
public class TweenerPosition : MonoBehaviour
{
    [SerializeField]
    TweenType openTweenType, closeTweenType;

    [SerializeField]
    float openTime, closeTime;
    [SerializeField]
    LeanTweenType openTween;
    [SerializeField]
    LeanTweenType closeTween;

    [SerializeField]
    RectTransform rectTransform;

    [SerializeField]
    float delay;

    Vector3 pos;

    [SerializeField]
    bool auto;

    bool isOpen;


    public UnityEvent startOpenEvent, startCloseEvent;
    public UnityEvent endOpenEvent, endCloseEvent;

    [SerializeField]
    Vector2 startPos, endPos;

    private void Reset()
    {
        rectTransform = GetComponent<RectTransform>();
    }
    private void Start()
    {

    }

    public void OpenPanel()
    {
        if (isOpen)
            return;
        if (!gameObject.activeSelf)
            gameObject.SetActive(true);
        pos = Vector3.zero;
        isOpen = true;
        switch (openTweenType)
        {
            case TweenType.Top2Bottom:
                pos.y = (Screen.height + rectTransform.sizeDelta.y) / 2;
                rectTransform.localPosition = pos;
                LeanTween.moveLocalY(gameObject, 0, openTime).setEase(openTween).setOnComplete(() =>
                {
                    LeanTween.delayedCall(delay, () =>
                     {
                         if (auto)
                             ClosePanel();
                     });

                });
                break;
            case TweenType.Bottom2Top:
                pos.y = -(Screen.height + rectTransform.sizeDelta.y) / 2;
                rectTransform.localPosition = pos;
                LeanTween.moveLocalY(gameObject, 0, openTime).setEase(openTween).setOnComplete(() =>
                {
                    LeanTween.delayedCall(delay, () =>
                    {
                        if (auto)
                            ClosePanel();
                    });
                });
                break;
            case TweenType.Left2Right:
                pos.x = -(Screen.width + rectTransform.sizeDelta.x) / 2;
                rectTransform.localPosition = pos;
                LeanTween.moveLocalX(gameObject, 0, openTime).setEase(openTween).setOnComplete(() =>
                {
                    LeanTween.delayedCall(delay, () =>
                    {
                        if (auto)
                            ClosePanel();
                    });
                });
                break;
            case TweenType.Right2Left:
                pos.x = (Screen.width + rectTransform.sizeDelta.x) / 2;
                rectTransform.localPosition = pos;
                LeanTween.moveLocalX(gameObject, 0, openTime).setEase(openTween).setOnComplete(() =>
                {
                    LeanTween.delayedCall(delay, () =>
                    {
                        if (auto)
                            ClosePanel();
                    });
                });
                break;
            case TweenType.NotificationTop:
                pos.x = 0;
                pos.y = (Screen.height + rectTransform.sizeDelta.y) / 2;
                rectTransform.localPosition = pos;
                var tweento = (Screen.height - rectTransform.sizeDelta.y) / 2;
                LeanTween.moveLocalY(gameObject, tweento, openTime).setEase(openTween).setOnComplete(() =>
                {
                    LeanTween.delayedCall(delay, () =>
                    {
                        if (auto)
                            ClosePanel();
                    });
                });

                break;
            case TweenType.NotificationBottom:
                pos.x = 0;
                pos.y = -(Screen.height + rectTransform.sizeDelta.y) / 2;
                rectTransform.localPosition = pos;
                float tween = -(Screen.height - rectTransform.sizeDelta.y) / 2;
                LeanTween.moveLocalY(gameObject, tween, openTime).setEase(openTween).setOnComplete(() =>
                {
                    LeanTween.delayedCall(delay, () =>
                    {
                        if (auto)
                            ClosePanel();
                    });
                });
                break;
            case TweenType.LeftSlide:
                pos.x = -Screen.currentResolution.width / 2 + (rectTransform.sizeDelta.x / 2);
                LeanTween.moveLocalX(gameObject, pos.x, openTime).setEase(openTween).setOnStart(() =>
                {
                    startOpenEvent?.Invoke();
                }).setOnComplete(() =>
                {
                    startCloseEvent?.Invoke();
                    LeanTween.delayedCall(delay, () =>
                    {
                        if (auto)
                            ClosePanel();
                    });
                });


                break;
            case TweenType.RightSlide:
                pos.x = (Screen.width - rectTransform.rect.width) / 2;

                LeanTween.moveLocalX(gameObject, pos.x, closeTime).setEase(closeTween).setOnStart(() =>
                {
                    startOpenEvent?.Invoke();
                }).setOnComplete(() =>
                {
                    startCloseEvent?.Invoke();
                    LeanTween.delayedCall(delay, () =>
                    {
                        if (auto)
                            ClosePanel();
                    });
                });
                break;

            case TweenType.MessagePopup:
                LeanTween.moveLocalY(gameObject, startPos.y, 0);

                LeanTween.moveLocalY(gameObject, endPos.y, openTime).setEase(openTween).setOnComplete(() =>
               {
                   LeanTween.delayedCall(delay, () =>
                   {
                       if (auto)
                           ClosePanel();
                   });
               });
                break;

            default:
                break;
        }
    }

    public void ClosePanel()
    {
        pos = Vector3.zero;
        if (!isOpen)
            return;

        isOpen = false;
        switch (closeTweenType)
        {
            case TweenType.Top2Bottom:

                pos.y = (Screen.height + rectTransform.sizeDelta.y) / 2;
                LeanTween.moveLocalY(gameObject, pos.y, closeTime).setEase(closeTween).setOnComplete(() => { gameObject.SetActive(false); });
                break;
            case TweenType.Bottom2Top:

                pos.y = -(Screen.height + rectTransform.sizeDelta.y) / 2;
                LeanTween.moveLocalY(gameObject, pos.y, closeTime).setEase(closeTween).setOnComplete(() => { gameObject.SetActive(false); });
                break;
            case TweenType.Left2Right:

                pos.x = -(Screen.width + rectTransform.sizeDelta.x) / 2;
                LeanTween.moveLocalX(gameObject, pos.x, closeTime).setEase(closeTween).setOnComplete(() => { gameObject.SetActive(false); });
                break;
            case TweenType.Right2Left:

                pos.x = (Screen.width + rectTransform.sizeDelta.x) / 2;
                LeanTween.moveLocalX(gameObject, pos.x, closeTime).setEase(closeTween).setOnComplete(() => { gameObject.SetActive(false); });
                break;
            case TweenType.NotificationTop:
                pos.y = (Screen.height + rectTransform.sizeDelta.y) / 2;
                LeanTween.moveLocalY(gameObject, pos.y, closeTime).setEase(closeTween).setOnComplete(() => { gameObject.SetActive(false); });
                break;
            case TweenType.NotificationBottom:
                pos.y = -(Screen.height + rectTransform.sizeDelta.y) / 2;
                LeanTween.moveLocalY(gameObject, pos.y, closeTime).setEase(closeTween).setOnComplete(() => { gameObject.SetActive(false); });
                break;

            case TweenType.LeftSlide:
                pos.x = (-Screen.width - rectTransform.rect.width) / 2;

                LeanTween.moveLocalX(gameObject, pos.x, closeTime).setEase(openTween).setOnStart(() =>
                {
                    endOpenEvent?.Invoke();
                }).setOnComplete(() =>
                {
                    endCloseEvent?.Invoke();
                });
                break;

            case TweenType.RightSlide:
                pos.x = (Screen.width + rectTransform.rect.width) / 2;

                LeanTween.moveLocalX(gameObject, pos.x, closeTime).setEase(openTween).setOnStart(() =>
                {
                    endOpenEvent?.Invoke();
                }).setOnComplete(() =>
                {
                    endCloseEvent?.Invoke();
                });
                break;
            case TweenType.MessagePopup:
                LeanTween.moveLocalY(gameObject, endPos.y, closeTime).setEase(closeTween).setOnComplete(() =>
                {
                    gameObject.SetActive(false);
                });
                break;

            default:
                break;
        }

    }

}
