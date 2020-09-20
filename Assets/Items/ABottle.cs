using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthPotion", menuName = "Items/Potion", order = 1)]
public class ABottle : ItemScript, IUseable {
	
	public void Use(){
		Remove ();
		PlayerScript.player.Health += 10;
	}
}
