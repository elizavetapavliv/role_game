using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion2", menuName = "Items/Potion2", order = 1)]
public class ABottleD : ItemScript, IUseable {

	public void Use(){
		Remove ();
		PlayerScript.player.Mana += 10;
	}
}