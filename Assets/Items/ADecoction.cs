using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Decoction", menuName = "Items/Decoction", order = 1)]
public class ADecoction : ItemScript, IUseable {
    
	public void Use(){

		if (PlayerScript.player.State != States.dead) {
			Remove ();
			if (PlayerScript.player.State == States.poisoned) {
                PlayerScript.player.State = States.normal;
			} else {
                PlayerScript.player.State = States.weak;
			}
		}
	}
}
