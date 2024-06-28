using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CustomizeToggle : MonoBehaviour
{
  [SerializeField] RectTransform rectTransform;
  [SerializeField] Image disableToggleImage;
  Image toggleImage;
  [SerializeField] Sprite onSprite, offSprite;
  TMP_Text toggleText;
  public int offset;
  Toggle toggle;

  private void Start()
  {
    toggle = GetComponent<Toggle>();
    toggleText = rectTransform.GetComponentInChildren<TMP_Text>();
    toggle.onValueChanged.AddListener(ToggleValueChangedListener);
    toggleImage = rectTransform.GetComponentInChildren<Image>();
  }

  private void ToggleValueChangedListener(bool b)
  {
    if (b)
    {
      rectTransform.localPosition = new Vector2(offset, rectTransform.localPosition.y);
      toggleText.text = "ON";
      toggleImage.sprite = onSprite;
    }
    else
    {
      toggleText.text = "OFF";
      rectTransform.localPosition = new Vector2(-offset, rectTransform.localPosition.y);
      toggleImage.sprite = offSprite;
    }
    disableToggleImage.enabled = !b;
  }
}
