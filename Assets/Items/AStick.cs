using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Stick", menuName = "Items/Stick", order = 1)]
public class AStick : ItemScript, IUseable {
[SerializeField]
public int health;
    private GameObject[] enemies;
    private GameObject min_enemy;
    private float dif = 1000f;
    public void Use(){
		Remove ();
      enemies = GameObject.FindGameObjectsWithTag("Enemy");
        GameObject player = GameObject.FindWithTag("Player");

        foreach (GameObject g in enemies)
        {
            float d = g.transform.position.x - player.transform.position.x;
            if ( d< dif && d>=0)
            {
                min_enemy = g;
                dif = d;
            }
        }
        EnemyScript e = min_enemy.GetComponent<EnemyScript>();
        e.health -= health;
	}
}
