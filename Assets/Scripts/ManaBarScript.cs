using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManaBarScript : MonoBehaviour
{
	private Image mana_bar;
	private float max_mana;
	public static float mana;
    public void Start()
    { 
		mana_bar = GetComponent<Image>();
        max_mana = PlayerScript.player.Max_mana;
        mana = max_mana;
    }
	public void Update()
	{
        mana = PlayerScript.player.Mana;
        mana_bar.fillAmount = mana / max_mana;
	}
}