using UnityEngine;

public class DieOff : MonoBehaviour, IMagic {
    public void ChangeDieOff(){
        PlayerScript.player.Mana -= 85;
	}

	public int n_mana = 85;
	public bool n_move = false;
	public bool n_speak = true;

	public void MakeMagic(object pl, int st){
		if ((pl as MagicCharacter).State != States.dead && (pl as MagicCharacter).Able_to_talk && (pl as MagicCharacter).Mana >= n_mana) {
			if ((pl as MagicCharacter).State == States.paralyzed) {
				(pl as MagicCharacter).State = States.normal;
			} else {
				(pl as MagicCharacter).State = States.weak;
			}
			(pl as MagicCharacter).Mana -= n_mana;
			(pl as MagicCharacter).Health = 1;
		}
	}
}
  