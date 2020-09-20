using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Antidote : MonoBehaviour {

	public object pl = PlayerScript.player;
    public void ChangeAntidote(){
		PlayerScript.player.Mana -= 30;
		if ((pl as MagicCharacter).State != States.dead && (pl as MagicCharacter).Able_to_talk) {
			if ((pl as MagicCharacter).State == States.poisoned) {
				(pl as MagicCharacter).State = States.normal;
			} else {
				(pl as MagicCharacter).State = States.weak;
			}
		}
	}
}
 