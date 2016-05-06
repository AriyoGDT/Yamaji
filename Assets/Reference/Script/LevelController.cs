using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelController : MonoBehaviour {
	public List<Sprite> level_Icon;

	// Use this for initialization
	void Start () {
		this.gameObject.GetComponent<SpriteRenderer> ().sprite = level_Icon [(int)(PlayerPrefs.GetInt ("expPrefs") / 10000)];
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
