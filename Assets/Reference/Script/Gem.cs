using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gem : MonoBehaviour {

	public List<Gem> Neighbors = new List<Gem>();
	public bool isInList=false;
	public float xPos;
	public float yPos;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void assignGem(float x,float y)
	{
		xPos = x;
		yPos = y;
	}

	public void AddNeighbor(Gem g)
	{
		Neighbors.Add (g);
	}
	
	public void RemoveNeighbor(Gem g)
	{
		Neighbors.Remove(g);
	}

	void OnMouseDown()
	{
	//  

		if (this.isInList == false)
		{
		//	GameObject.Find ("Board").GetComponent<Board> ().MatchList.Add (this);
			this.isInList = true;
	//		Debug.Log("in list");
	//		Debug.Log(this.name);
			GameObject.Find ("Board").GetComponent<Board> ().createMatchList (this);
	//		StartCoroutine(Whatever() );
			GameObject.Find ("Board").GetComponent<Board> ().touchHappen(true);
		}
//		Debug.Log("touch happen");


	//	foreach (Gem g in GameObject.Find("Board").GetComponent<Board>().MatchList)
		{


		}
	//	Destroy (this);
		/*
		int m = GameObject.Find ("Board").GetComponents<Board> ().MatchList.count;
		for (int i=0; i<m; i++) 
		{
		}
		*/


	}

	IEnumerator Whatever()
	{
		float timeToWait = 5;
		yield return new WaitForSeconds(timeToWait);
	}

}
