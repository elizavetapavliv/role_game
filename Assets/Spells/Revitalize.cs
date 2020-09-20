using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Revitalize : MonoBehaviour {

	public object pl= PlayerScript.player;
	public void ChangeRevitalize(){
        PlayerScript.player.Mana -= 150;
		if ((pl as MagicCharacter).Able_to_talk && (pl as MagicCharacter).Mana >= 150) {
			if ((pl as MagicCharacter).State == States.dead) {
				(pl as MagicCharacter).State = States.weak;
				(pl as MagicCharacter).Health = 1;
				(pl as MagicCharacter).Mana -= 150;
			}
		}
    }
} 