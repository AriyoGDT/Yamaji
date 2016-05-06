using UnityEngine;
using System.Collections;

public class Feeler1 : MonoBehaviour {

	public Gem owner;
	

	void OnTriggerExit(Collider c)
	{
		if (c.tag == "Gem") 
		{
			GameObject.Find ("Board").GetComponent<Board> ().shiftToLeft();
		//	Debug.Log("left exit");
		}
	}
}
