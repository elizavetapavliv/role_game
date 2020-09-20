using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddHealth : MonoBehaviour, IMagic {
    public void ChangeAddHealth(){
		PlayerScript.player.Mana -= 5;
		PlayerScript.player.Health += 10;
	}

	public int n_mana = 2;
    public bool n_move = false;
	public bool n_speak = true;
	

	public void MakeMagic(object pl, int st){
		if ((pl as MagicCharacter).State != States.dead && (pl as MagicCharacter).Able_to_talk) {
			if ((pl as MagicCharacter).Mana >= st * n_mana) {
				(pl as MagicCharacter).Health += st;
				(pl as MagicCharacter).Mana -= st * n_mana;
			}
		}

	}
}
	