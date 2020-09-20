using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SpellManager : MonoBehaviour {

	[SerializeField]
	private PlayerScript player;
	void Start () {
		
	}
	void Update () {
		ClickTarget ();
	}
	private void ClickTarget(){
		if (Input.GetMouseButtonDown (0) && !EventSystem.current.IsPointerOverGameObject ()) {
			RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero, Mathf.Infinity);
			if (hit.collider != null) {
				if (hit.collider.tag == "Enemy") {
					player.Target = hit.transform;
				}
			} else {
				player.Target = null;
			}
		}
	}
}
	