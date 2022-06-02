using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BadTime : MonoBehaviour
{

    [SerializeField] private TextMeshProUGUI text;
    private string death = "deaths";
    private int deathCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        if(PlayerPrefs.HasKey(death))
        {
            deathCount = PlayerPrefs.GetInt(death);
            text.text = "You have died " + deathCount.ToString() + " many times";
        }
      
    }

    // Update is called once per frame
    private void OnApplicationQuit()
    {
        deathCount++;
        PlayerPrefs.SetInt(death, deathCount); 
    }

}
