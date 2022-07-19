using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoScore : MonoBehaviour
{

    public Score score = Score.High;



}

[System.Serializable]
 public enum Score
{
    High = 100,
    Medium = 50,
    Low = 5

}
