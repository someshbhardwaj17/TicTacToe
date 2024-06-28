using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Data/SpriteData", fileName = "SpriteData",order =0)]
public class SpriteData : ScriptableObject
{
  public List<Sprite> spriteList;
}
