using System;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
public enum Effect { Scale, Move, Color }
public class PlaneTweener : MonoBehaviour
{
   public float openDuration = 0.5f, closeDuration = 0.5f;

   public LeanTweenType openTween, closeTween;


   internal bool canstart = true;

   public PlaneTweener background;

   public GameObject bg;
   public Button closeButton,closeButton2;
   public Effect effect;

   public float scaleUP = 1;
   public float scaleDown = 0;

   [SerializeField]
   float startDelay = 0;
   [SerializeField]
   float endDelay = 0.3f;

   public UnityEvent OpenStartEvent, OpenEndEvent;
   public UnityEvent CloseStartEvent, CloseEndEvent;

   public virtual void Reset()
   {
      openDuration = .5f;
      closeDuration = .5f;

      openTween = LeanTweenType.easeOutBack;
      closeTween = LeanTweenType.easeInBack;
   }
   void SetBackground(bool value)
   {
      if (bg != null)
         bg.SetActive(value);
   }

   public virtual void OpenPanel()
   {
      try
      {
         if (!canstart)
            return;
         if (background != null)
            background.OpenPanel();

         canstart = false;

         SetBackground(true);
         gameObject.SetActive(true);
         switch (effect)
         {
            case Effect.Color:

               LeanTween.color(gameObject.GetComponent<RectTransform>(), Color.clear, 0);
               LeanTween.color(gameObject.GetComponent<RectTransform>(), Color.white, openDuration).setDelay(startDelay).setOnComplete(ClosePanel).setOnStart(() => { OpenStartEvent?.Invoke(); });
               break;

            case Effect.Move:
               break;

            case Effect.Scale:
               transform.localScale = Vector3.zero;
               LeanTween.scale(gameObject, Vector3.one * scaleUP, openDuration).setDelay(startDelay).setEase(openTween).setOnComplete(ClosePanel).setOnStart(() => { OpenStartEvent?.Invoke(); });
               break;

         }
      }
      catch (Exception e)
      {
         
      }
   }

   public virtual void ClosePanel()
   {
      try
      {
         if (canstart)
            return;

         if (background != null)
            background.ClosePanel();

         switch (effect)
         {
            case Effect.Color:
               LeanTween.color(gameObject, Color.clear, closeDuration).setDelay(endDelay).setEase(closeTween).setOnComplete(Close);
               break;
            case Effect.Move:
               break;
            case Effect.Scale:
               transform.localScale = Vector3.one * scaleUP;
               LeanTween.scale(gameObject, Vector3.one * scaleDown, closeDuration).setDelay(endDelay).setEase(closeTween).setOnComplete(Close);
               break;
         }
      }
      catch (Exception e)
      {
        
      }
   }

   public virtual void Close()
   {
      canstart = true;
      SetBackground(false);
      gameObject.SetActive(false);
      CloseEndEvent?.Invoke();
   }

}
