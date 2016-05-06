using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
//using UnityEditor;

public class Board : MonoBehaviour 
{

	int score;

	public List<Gem> gems=new List<Gem>();
	public List<Gem> MatchList=new List<Gem>();
	public List<Gem> moveList = new List<Gem>();
//	public Gem[][] boardMatrix;
	public GameObject[] gemPrefab;
	public int GridWidth;
	public int GridHeight;
	//public Gem[][] gemArray;

	public int[] colorArray;
	bool[] colorFull = {false,false,false,false,false};
	bool repick=true;
	int i=0;
	int counterGem=0;
	bool touchHappenVar=false;
	const float scalePosition = 0.65f;
	bool shiftToLestFlag=false;
	bool ShiftToDownFlag=true;
	//int ScorePoint=5;

	public GameObject explotion;

	public Text score_Text;
	public Text over_score_Text;
	public Text energy_Text;
	public Canvas game_Menu;
	public Canvas gameOver_Menu;

	// Use this for initialization
	void Start () {

		game_Menu.enabled = false;
		gameOver_Menu.enabled = false;
		PlayerPrefs.SetInt ("scorePrefs", 0);
		energy_Text.text = "ENERGY : " + PlayerPrefs.GetInt("energyPrefs");
	//	for ( int n =0 ; n<5;n++)
	//		colorFull[n]= false;
	//	gemArray=new Gem[GridWidth][];

		float positionY=-3.3f;
//		boardMatrix = new Gem[GridWidth][];
		for (int y=0; y< GridHeight; y++)
		{
			float positionX = -2.25f;
//			boardMatrix[y] = new Gem[GridHeight];
			for (int x=0; x<GridWidth; x++) 
			{
				if (counterGem<241)
				{
					repick=true;
					int p = randomNumber();
					counterGem++;
			//		Debug.Log(p);
			//		Debug.Log("gem created",counterGem);
			//		Gem g=Instantiate(gemPrefab[p], new Vector3(positionX,positionY,0), Quaternion.identity)as Gem;
					GameObject g=Instantiate(gemPrefab[p], new Vector3(positionX,positionY,0), Quaternion.identity)as GameObject;
				//	g.transform.parent=gameObject.transform;
				//	Gem temp=g.GetComponent<Gem>();
					g.GetComponent<Gem>().assignGem(positionX,positionY);
//					g.assignGem(positionX,positionY);
//					boardMatrix[x][y]=g;
					gems.Add(g.GetComponent<Gem>());

	//				gems.Add(g);
					positionX+=scalePosition;
				}
			}
			positionY+=scalePosition;

		}
	}


	public void GoHome()
	{
		print("exp"+PlayerPrefs.GetInt ("expPrefs"));
		PlayerPrefs.SetInt ("expPrefs", PlayerPrefs.GetInt ("expPrefs") + PlayerPrefs.GetInt ("scorePrefs"));
		Application.LoadLevel("Menu");
	}

	public void PlayAgain()
	{
		print("exp"+PlayerPrefs.GetInt ("expPrefs"));
		PlayerPrefs.SetInt ("expPrefs", PlayerPrefs.GetInt ("expPrefs") + PlayerPrefs.GetInt ("scorePrefs"));
		int random = Random.Range (0, 6);
		if (PlayerPrefs.GetInt ("energyPrefs") > 0) {
			PlayerPrefs.SetInt ("energyPrefs", PlayerPrefs.GetInt ("energyPrefs")-1);
			Application.LoadLevel (Application.loadedLevel);
		} else
			game_Menu.enabled = true;
		if (random == 3)
			game_Menu.enabled = true;
	}


	public int randomNumber()
	{
		
		while (repick)
		{
			i = Random.Range (0, 5);
			repick=isRepeated(i);
		}
		switch(i)
		{
		case 0:
			colorArray[0]++;
			if(colorArray[0]==48)
				colorFull[0]=true;
			//		repick=false;
			break;
		case 1:
			
			colorArray[1]++;
			if(colorArray[1]==48)
				colorFull[1]=true;
			//			repick=false;
			break;
		case 2:
			colorArray[2]++;
			if(colorArray[2]==48)
				colorFull[2]=true;
			//			repick=false;
			break;
		case 3:
			colorArray[3]++;
			if(colorArray[3]==48)
				colorFull[3]=true;
			//			repick=false;
			break;
		case 4:
			colorArray[4]++;
			if(colorArray[4]==48)
				colorFull[4]=true;
			//			repick=false;
			break;
		}
		
		
		return i;
	}
	
	public bool isRepeated(int num)
	{
		if (colorFull [num] == true)
			return true;
		else 
			return false;
	}

	public void createMatchList(Gem g)
	{
		MatchList=new List<Gem>();
		MatchList.Add (g);
//		Debug.Log (g.name);
		if (MatchList.Count>0)
		{

			for (int t=0; t<MatchList.Count; t++)
			{
			//	Debug.Log("matchlist [t].name");
			//	Debug.Log(MatchList[t].name);
			//	MatchList[t].Neighbors=updateNeighborList(MatchList[t].Neighbors);
				for (int i=0; i<MatchList[t].Neighbors.Count; i++) 
				{
					if(MatchList[t].Neighbors[i]==null)
					{
						////
					}
					else
					{

						if (MatchList [t].name == MatchList [t].Neighbors [i].name) 
						{
					//	Debug.Log(MatchList[t].name);
							/*
						Debug.Log(MatchList[t].Neighbors[i].name);
						Debug.Log(MatchList[t].Neighbors[i].xPos);
						Debug.Log(MatchList[t].Neighbors[i].xPos);


						Debug.Log("steal working2");
						*/
							if (MatchList [t].Neighbors [i].isInList == false)
							{
							Gem temp=MatchList[t].Neighbors[i];
							MatchList.Add (temp);
							MatchList [t].Neighbors [i].isInList = true;

								/*
							Debug.Log ("number i: ");
							Debug.Log(i);
							Debug.Log("/////////////////////");
							Debug.Log ("number t: ");
							Debug.Log(t);
	     			        Debug.Log("/////////////////////");
	     			        */

							}

						}
					}

				}

			}
//			Debug.Log ("list number");
//			Debug.Log (MatchList.Count);
			moveList=MatchList;
			destroyObjList();

		//	touchHappenVar=true;
		}



	}
	IEnumerator DelayExplotion()
	{
		float delay = 0.5f;
		yield return new WaitForSeconds (delay);
	}
	public void destroyObjList()
	{
		if (MatchList.Count > 1) {
			//PlayerPrefs.SetInt("scorePrefs" , PlayerPrefs.GetInt("scorePrefs") + MatchList.Count * 3);
			score += MatchList.Count * 2;
			score_Text.text = "SCORE : "+score;
			for (int t=MatchList.Count-1; t>-1; t--) 
			{
				MatchList[t].gameObject.transform.GetChild(0).GetComponent<Animation>().Play();
				StartCoroutine(DelayExplotion());

				Instantiate(explotion , MatchList[t].gameObject.transform.position ,MatchList[t].gameObject.transform.rotation );
				Destroy (MatchList [t].gameObject , 1.0f);
//				gems.Remove(MatchList[t].gameObject));
				/*
				Debug.Log ("t number:");
				Debug.Log (t);
				*/
				MatchList.Remove (MatchList [t]);
//				MatchList.RemoveAll();
			}
		} else {
			MatchList [0].isInList = false;
			MatchList.Remove (MatchList [0]);
//			MatchList.RemoveAll();
		}
		/*
		Debug.Log ("list number");
		Debug.Log (MatchList.Count);
		*/
//		MatchList.RemoveAll(gameObject);
		MatchList.Clear ();
		for (int y=0; y< gems.Count; y++) 
		{
			if(gems[y])
			{
				gems[y].isInList=false;
			}

		}
	}
	// Update is called once per frame




	void Update () {

		bool b=IsgameOver();
		if(b==true)
		{
			gameOver_Menu.enabled = true;

			print("exp"+PlayerPrefs.GetInt ("expPrefs"));
			over_score_Text.text = "Score : " + score;

			if (score > PlayerPrefs.GetInt("scorePrefs"))
				PlayerPrefs.SetInt("scorePrefs" , score);

		}
		if(touchHappenVar)
		{
	//		StartCoroutine(Whatever() );
			if(ShiftToDownFlag)
			{
				updateArray ();
			//updateArray ();
			}

			//touchHappenVar=false;
		}
		if (shiftToLestFlag == true) 
		{
			shiftToLeft();
		}

	}
	public bool IsgameOver(){

		bool GameOverFlag = true;
		for (int t=0; t< gems.Count; t++)
		{
			if (gems [t] == null) 
			{
				//
			}
			else
			{
				for (int i=0; i<gems[t].Neighbors.Count; i++) 
				{
					if(gems[t].Neighbors[i]==null)
					{
						//PlayerPrefs.SetInt ("expPrefs", PlayerPrefs.GetInt ("expPrefs") + PlayerPrefs.GetInt ("scorePrefs"));
					}
					else
					{
						
						if (gems [t].name == gems [t].Neighbors [i].name) 
						{
							//	Debug.Log(MatchList[t].name);
						//	Debug.Log(gems[t].Neighbors[i].name);
							
					//		Debug.Log("steal working2");

							//	Gem temp=gems[t].Neighbors[i];
							//	gems.Add (temp);
							//	MatchList [t].Neighbors [i].isInList = true;
								
						//		Debug.Log("/////////////////////");
						//		Debug.Log ("finish game ");
						//		Debug.Log("/////////////////////");
								GameOverFlag= false;
								break;



							
						}
					}
					
				}

			}

		}




		return GameOverFlag;

	}
	public void	updateArray()
	{
//		Debug.Log ("update list1");
	
		for (int r=0 ; r<8 ; r++) 
		{
	//		Debug.Log("for loop r");
	//		Debug.Log(r);

			int jj=0;

			for(jj=r; jj<gems.Count ; jj=jj+8)
			{
				bool colneedSort=true;
		//		Debug.Log("for loop jj");
		//		Debug.Log(jj);
				int t=0;
				int k=0;
				if (gems[jj])
				{
					//
				}
				else
				{
					shiftToLestFlag=false;
					t=jj;
					while(colneedSort)
					{
						k++;
						t+=8;
						if(t>=gems.Count)
						{
							colneedSort=false;
						//	break;
					//		Debug.Log("if");
						}
						else 
						{
					//		Debug.Log("t is");
					//		Debug.Log(t);
							if(gems[t])
							{
							colneedSort=false;
				//			Debug.Log("else if");
							}
						}

					}
					if(t<240)
					{
						if(gems[t])
						{
							gems[jj]=gems[t];
							float temp=gems[jj].transform.position.y;
			//				Debug.Log(temp);
							temp-=scalePosition*k;
			//				Debug.Log(temp);
							gems[jj].transform.position=new Vector3(gems[jj].transform.position.x,temp,gems[jj].transform.position.z);
							gems[t]=null;
		//					Debug.Log("swap happen");

						}
					}


				}
				colneedSort=false;
			}
			//shift to left code here
			shiftToLestFlag=true;

		}
	//	touchHappenVar = false;
	}
	public void touchHappen(bool test)
	{
		//StartCoroutine(Whatever() );
		if (test == true) {
			touchHappenVar=true;
		} else {
		//	touchHappenVar=false;
		}
	}
	IEnumerator Whatever()
	{
		float timeToWait = 5;
		yield return new WaitForSeconds(timeToWait);
	}

	public void shiftToLeft()
	{
		if (shiftToLestFlag == true) {


			for (int ii=0; ii < 8; ii++) {
				if (gems [ii]) {

				} else {
					//do shift here
					ShiftToDownFlag = false;
					int f=0;
					for (int j=ii+1; j<8; j++) {
						f++;
						if (gems [j]) {
							gems [ii] = gems [j];
							float temp = gems [j].transform.position.x;
											Debug.Log(temp);
							temp -= scalePosition * f;
											Debug.Log(temp);
							gems [ii].transform.position = new Vector3 (temp, gems [ii].transform.position.y, gems [ii].transform.position.z);
							gems [j] = null;
							for (int jz=j+8; jz<gems.Count; jz=jz+8) {
								
								if (gems [jz]) {
									int ttt = jz - 1;
									gems [ttt] = gems [jz];
									float tempx = gems [jz].transform.position.x;
									//				Debug.Log(temp);
									tempx -= scalePosition * f;
									//				Debug.Log(temp);
									gems [ttt].transform.position = new Vector3 (temp, gems [ttt].transform.position.y, gems [ttt].transform.position.z);
									gems [jz] = null;
									
								}
								
							}
							break;
							/*

							*/

					
				
						}
					}
					

				}
			}
			ShiftToDownFlag = true;

		}

	}
}
 