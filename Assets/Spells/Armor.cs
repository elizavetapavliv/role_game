using UnityEngine;

public class Armor : MonoBehaviour {

	public object pl= PlayerScript.player;
	public int time=1;

	public void ChangeArmor(){
		PlayerScript.player.Mana -= 50;
		if ((pl as MagicCharacter).Mana >= 50 * time) {
			(pl as MagicCharacter).IsProtected = true;
			(pl as MagicCharacter).Mana -= time * 50;
		}
	}
}
