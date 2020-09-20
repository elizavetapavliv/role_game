using UnityEngine;

public class Heal : MonoBehaviour{

	public object pl=PlayerScript.player;
	public void ChangeHeal(){
		PlayerScript.player.Mana -= 20;

		if ((pl as MagicCharacter).State != States.dead && (pl as MagicCharacter).Able_to_talk && (pl as MagicCharacter).Mana >= 20) {
			if ((pl as MagicCharacter).State == States.ill) {
				(pl as MagicCharacter).State = States.normal;
			} else {
				(pl as MagicCharacter).State = States.weak;
			}
		}
	}
}
 