using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
  [SerializeField] GameObject easyLevel, mediumLevel, hardLevel;
  [SerializeField] GridLayout gridLayout;

  public static Box[] totoalBoxes;
  void Start()
  {

    if (GameSettings.gameLevel == GameSettings.GameLevel.Easy)
    {
      easyLevel.gameObject.SetActive(true);
      StoreBoxesInList(easyLevel);
    }
    else if (GameSettings.gameLevel == GameSettings.GameLevel.Medium)
    {
      mediumLevel.gameObject.SetActive(true);
      StoreBoxesInList(mediumLevel);
    }
    else
    {
      hardLevel.gameObject.SetActive(true);
      StoreBoxesInList(hardLevel);
    }

  }


  private void StoreBoxesInList(GameObject go)
  {
    totoalBoxes = go.GetComponentsInChildren<Box>();
  }

}
