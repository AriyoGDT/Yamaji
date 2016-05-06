using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BackGroundManager : MonoBehaviour {
	public List<Sprite> background;
	public List<Sprite> random_background;
	int randNumber;
	// Use this for initialization
	void Start () {

		if (PlayerPrefs.GetInt ("gameModePrefs") == 1) {
			for (int i= 0; i<background.Count; i++)
				if (PlayerPrefs.GetInt ("themesPrefs") == i)
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = background [i];
		}
		else if (PlayerPrefs.GetInt ("gameModePrefs") == 0) { // colorBase Mode
			randNumber = Random.Range (0, random_background.Count);
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = background[randNumber];
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
