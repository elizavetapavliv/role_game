using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BagScript : MonoBehaviour {

	[SerializeField]
	private GameObject slotPrefab;

	private CanvasGroup canvasGroup;
	public List<SlotScript> slots = new List<SlotScript> ();

	public bool isOpen{
		get { return canvasGroup.alpha > 0; }
	}
		
	private void Awake(){
		canvasGroup = GetComponent<CanvasGroup> ();
	}
	public void AddSlots (int slotCount){
		for (int i = 0; i < slotCount; i++) {
			SlotScript slot = Instantiate (slotPrefab, transform).GetComponent<SlotScript>();
			slots.Add (slot);
		}
	}

	public void OpenClose(){
		canvasGroup.alpha = canvasGroup.alpha > 0 ? 0 : 1;
		canvasGroup.blocksRaycasts = canvasGroup.blocksRaycasts == false ? true : false;
	}

	public bool AddItem(ItemScript item){
		foreach (SlotScript slot in slots) {
			if (slot.isEmpty) {
				slot.AddItem (item);
				return true;
			}
		}
		return false;
	}
}
