using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LineControllerSetup : MonoBehaviour
{
  public Transform[] starPoints;
  [SerializeField] private LineController line;
  
  private void Update()
  {
    line.SetUpLine(starPoints);
  }
}
