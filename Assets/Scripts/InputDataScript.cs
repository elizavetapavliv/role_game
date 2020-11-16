using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InputDataScript : MonoBehaviour
{
    public Dropdown dropdown;
    public InputField u_name;
    public Text name_error;
    public InputField age;
    public Text age_error;
    public static string user_name;
    public static int user_age;
    public static Genders gender;
    public void Update()
    {
        if (u_name.text != "")
        {
            name_error.text = "";
        }

        int ageVal;
        if (age.text != "" && Int32.TryParse(age.text, out ageVal) && ageVal > 0) 
        {
            age_error.text = "";
        }
        if(age.text != "" && Int32.TryParse(age.text, out ageVal) && ageVal <= 0)
            age_error.text = "Enter positive number for age!";
    }
    public void SetGet()
    {
        int ageVal = 0;
        bool parsed = Int32.TryParse(age.text, out ageVal);

        if (u_name.text == "" || age.text == "" || !parsed)
        {

            if (u_name.text == "")
            {
                name_error.text = "Enter your name!";
            }
            if (age.text == "" || !parsed)
            {
                age_error.text = "Enter your age!";
            }
        }
        else
        {
            user_name = u_name.text;

            if (age.text != "" && parsed && ageVal < 0)
            {
                age_error.text = "Enter positive number for age!";
                return;
            }
            user_age = ageVal;
            if (dropdown.value == 0)
            {
                gender = Genders.male;
            }
            else
            {
                gender = Genders.female;
            }
            SceneManager.LoadScene(1);
        }
    }
}
