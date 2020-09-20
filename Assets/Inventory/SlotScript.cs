using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SlotScript : MonoBehaviour, IPointerClickHandler, IClickable {

	[SerializeField]
	private Image icon;
	public bool isEmpty {
		get { return items.Count == 0; }
	}

	public ItemScript MyItem{
		get {
			if (!isEmpty) {
				return items.Peek ();
			} 
			return null;
		}
	}

	public Image MyIcon{
		get {
			return icon;
		}
		set {
			icon = value;
		}
	}

	public int MyCount {
		get {
			return items.Count;
		}
	}

	public Stack<ItemScript> items = new Stack<ItemScript> ();

	public bool AddItem(ItemScript item){
		items.Push (item);
		icon.sprite = item.MyIcon;
		icon.color = Color.white;
		item.MySlot = this;
		return true;
	}

	public void RemoveItem(ItemScript item){
		if (!isEmpty) {
			items.Pop();
			UIManager.MyInstance.UpdateStackSize(this);
		}
	}

	public void OnPointerClick (PointerEventData eventData){
		if (eventData.button == PointerEventData.InputButton.Left) {
			UseItem();
		}
	}

	public void UseItem(){
		if (MyItem is IUseable) {
			(MyItem as IUseable).Use();
		}
	}
}
