using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Event", menuName = "ScriptableObjects/Event", order = 0)]
public class EventData : ScriptableObject
{
  public Action action;

  public void InvokeAction()
  {
    action?.Invoke();
  }
}
