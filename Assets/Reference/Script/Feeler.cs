using UnityEngine;
using System.Collections;

public class Feeler : MonoBehaviour {

	public Gem owner;

	void OnTriggerEnter(Collider c)
	{
		if (c.tag == "Gem") 
		{
	//		Gem g=c.GetComponent`s<Gem>() as Gem;
			owner.AddNeighbor (c.GetComponent<Gem>());
		}
	}
	void OnTriggerExit(Collider c)
	{
		if (c.tag == "Gem") 
		{
			owner.RemoveNeighbor (c.GetComponent<Gem>());

		//	owner.Neighbors=GameObject.Find("Board").GetComponent<Board>().updateNeighborList(owner.Neighbors);
			/*
			for(int p=0; p< owner.Neighbors.Count;p++)
			{
				if(owner.Neighbors[p]==null)
				{
					owner.Neighbors[p]=owner.Neighbors[p+1];
				}
			}
			*/
		}
	}


}
