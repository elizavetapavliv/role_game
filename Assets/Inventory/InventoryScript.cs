using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryScript : MonoBehaviour {

	private static InventoryScript instance;
	public static InventoryScript MyInstance{
		get {
			if (instance == null) {
				instance = FindObjectOfType<InventoryScript> ();
			}
			return instance;
		}
	}
	public static List<Bag> bags = new List<Bag>();

	public bool CanAddBag{
		get { return bags.Count < 3; } 
	}

	[SerializeField]
	private BagButton[] bagButton;

	[SerializeField]
	public ItemScript[] items;

	private void Awake(){
		Bag bag = (Bag)Instantiate (items [0]);
		bag.Initialize (11);
		bag.Use ();
	}

	private  void Update(){
		//if (Input.GetKeyDown(KeyCode.L)){
			//Bag bag = (Bag)Instantiate (items [0]);
			//bag.Initialize (11);
			//bag.Use ();
		//}
		//if (Input.GetKeyDown (KeyCode.B)) {
			//Bag bag = (Bag)Instantiate (items [0]);
			//bag.Initialize (11);
			//AddItem (bag);
		//}

		if (Input.GetKeyDown (KeyCode.Alpha1)) {
			ABottle potion = (ABottle)Instantiate (items [1]);
			AddItem (potion);
		}
		if (Input.GetKeyDown (KeyCode.Alpha2)) {
			ABottleD potion = (ABottleD)Instantiate (items [2]);
			AddItem (potion);
		}
		if (Input.GetKeyDown (KeyCode.Alpha3)) {
			ADecoction potion = (ADecoction)Instantiate (items [3]);
			AddItem (potion);
		}
		if (Input.GetKeyDown (KeyCode.Alpha4)) {
			AEye potion = (AEye)Instantiate (items [4]);
			AddItem (potion);
		}
		if (Input.GetKeyDown (KeyCode.Alpha5)) {
			ASaliva potion = (ASaliva)Instantiate (items [5]);
			AddItem (potion);
		}
		if (Input.GetKeyDown (KeyCode.Alpha6)) {
			AStick potion = (AStick)Instantiate (items [6]);
			AddItem (potion);
		}
	}

	public void AddBag(Bag bag){
		foreach (BagButton bagButton in bagButton) {
			if (bagButton.MyBag == null) {
				bagButton.MyBag = bag;
				bags.Add (bag);
				break;
			}
		}
	}

	public static void AddItem(ItemScript item){
		foreach (Bag bag in bags) {
			if (bag.MyBagScript.AddItem (item)) {
				return;
			}
		}
	}

	public void OpenClose(){
		bool closedBag = bags.Find (x => !x.MyBagScript.isOpen); 
		foreach (Bag bag in bags) {
			if (bag.MyBagScript.isOpen != closedBag) {
				bag.MyBagScript.OpenClose ();
			}
		}
	}
}
