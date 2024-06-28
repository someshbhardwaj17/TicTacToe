using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "ScriptableObjects/Data/AudioData", fileName = "AudioData", order = 0)]
public class AudioData : ScriptableObject
{
  public List<AudioClip> audioDataList;
}
