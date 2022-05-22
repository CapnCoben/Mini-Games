using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System;

public class HealthBar : MonoBehaviour
{
    public TMPro.TMP_InputField Name;
    public TMPro.TMP_InputField Age;
    public TMPro.TMP_InputField City;
    public TMPro.TMP_InputField Weight;
    
    private void Start()
    {
        if (!PlayerPrefs.HasKey("Name"))
        {
            return;
        }
        else
        {
            Name.text = PlayerPrefs.GetString("Name");
        }

        if (!PlayerPrefs.HasKey("Age"))
        {
            return;
        }
        else
        {
            Age.text = PlayerPrefs.GetString("Age");
        }

        if (!PlayerPrefs.HasKey("City"))
        {
            return;
        }
        else
        {
            City.text = PlayerPrefs.GetString("City");
        }

        if (!PlayerPrefs.HasKey("Weight"))
        {
            return;
        }
        else
        {
            Weight.text = PlayerPrefs.GetString("Weight");
        }

    }

    private void OnApplicationQuit()
    {
        UserInput();
    }

    private void UserInput()
    {

        PlayerPrefs.SetString("Name", Name.text);
        PlayerPrefs.SetString("Age" + "Years Old", Age.text.Contains("0, 1, 2, 3, 4, 5, 6, 7, 8, 9").ToString());
        PlayerPrefs.SetString("City", City.text);
        PlayerPrefs.SetString("Weight" + "Pounds", Weight.text.Contains("0, 1, 2, 3, 4, 5, 6, 7, 8, 9").ToString());


    }
}
