using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDistroyOnLoad : MonoBehaviour
{
  private void Start()
  {
    DontDestroyOnLoad(gameObject);
  }

}
