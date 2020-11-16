using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBarScript : MonoBehaviour
{
    private Image health_bar;
    private float max_health;
    public static float health;
    public void Start()
    {
        health_bar = GetComponent<Image>();
        max_health = PlayerScript.player.Max_health;
        health = max_health;
    }
    public void Update()
    {
        health = PlayerScript.player.Health;
        health_bar.fillAmount = health / max_health;
    }
}