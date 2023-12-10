using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Resolution : MonoBehaviour
{void Awake()
  {
    #if UNITY_STANDALONE_WIN
    Screen.SetResolution (Screen.currentResolution.width,Screen.currentResolution.height, true);
    #endif
  }
}