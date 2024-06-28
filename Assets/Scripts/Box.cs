using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class Box : MonoBehaviour
{
  [SerializeField] Button button;
  [SerializeField] public int boxId;
  [SerializeField] Image image;
  [SerializeField] SpriteData spriteData;
  public bool isSelected;
  public static Action<Box> onBoxClickEvent;
  private Color initialColor;
  void Start()
  {
    button.onClick.AddListener(OnClickBoxBtn);
    image.enabled = false;
  }

  public void OnClickBoxBtn()
  {
    if (isSelected)
      return;
    onBoxClickEvent?.Invoke(this);
  }
  public  void PlayTurn(int playerId , int imageId)
  {
    isSelected = true;
    image.enabled = true;
    image.sprite = spriteData.spriteList[imageId];
  }
  public void Reset()
  {
    image.enabled = false;
    isSelected = false;
  }
  private void OnEnable()
  {
    TurnManager.resetGame += Reset;
  }
  private void OnDisable()
  {
    TurnManager.resetGame -= Reset;
  }
}
