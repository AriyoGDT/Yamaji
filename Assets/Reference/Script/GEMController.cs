using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GEMController : MonoBehaviour {

	public List<Sprite> sprite ;
	public List<Sprite> randomSprite;
	int randNumber;

	// Use this for initialization
	void Start () {
		if (PlayerPrefs.GetInt ("gameModePrefs") == 1) {
			for (int i= 0; i<sprite.Count; i++)
				if (PlayerPrefs.GetInt ("themesPrefs") == i)
					this.gameObject.GetComponent<SpriteRenderer> ().sprite = sprite [i];
		}
		else if (PlayerPrefs.GetInt ("gameModePrefs") == 0) { // colorBase Mode
			randNumber = Random.Range (0, 5);
			this.gameObject.GetComponent<SpriteRenderer> ().sprite = randomSprite[randNumber];
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
