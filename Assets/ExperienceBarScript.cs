using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExperienceBarScript : MonoBehaviour
{
    private Image experience_bar;
    public static float experience;

    public void Start()
    {
        experience_bar = GetComponent<Image>();
    }
    public void Update()
    {
        experience = PlayerScript.player.Experience;
        experience_bar.fillAmount = experience * 0.01f;
    }
}