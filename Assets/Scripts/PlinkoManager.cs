using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlinkoManager : MonoBehaviour
{

    private PlinkoScore plinkoScore;

    public GameObject[] rungs;

    public int score;

    public Canvas scoreCanvas;
    // Update is called once per frame

    private void Start()
    {
        score = 0;
    }

    void Update()
    {
        //GetScore();
    }

    public void GetScore(int value)
    {
        foreach (GameObject go in rungs)
        {
            plinkoScore = go.GetComponent<PlinkoScore>();

            score += (int)plinkoScore.score;
        }
    }
}
