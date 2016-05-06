using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class DisplayHighscores : MonoBehaviour {
//	List <string> names = new List<string>();

	public Text[] highscoreFields;
	public Text[] numberFields;
	public Text[] nameFields;

	public Text numberText;
	public Text error_Text;
	public Text scoreText;
	string namePlayer;

	public Text input_Name;
	string[] username;
	Highscores highscoresManager;
	public Highscore[] list;
	void Start() {
		namePlayer = PlayerPrefs.GetString ("usernamePrefs");
		for (int i = 0; i < highscoreFields.Length; i ++) {
			numberFields[i].text = i+1 + ". ";
		}

				
		highscoresManager = GetComponent<Highscores>();
		StartCoroutine("RefreshHighscores");

		FormatHighscores (PlayerPrefs.GetString("list"));
	}

	public void InputName()
	{
		namePlayer = input_Name.text;
		for (int i =0; i < list.Length; i ++) 
		{
			if ( namePlayer == list[i].username)
			{
				error_Text.text = "This name currently used , choose another";
				//error_Text.material.color = Color.red;
			}
			else
			{
				error_Text.text = "IsCorrect";
				//error_Text.material.color = Color.green;

			}
		}


	}


	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		list = new Highscore[entries.Length];
		
		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			list[i] = new Highscore(username,score);
		}
	}

	public void OnHighscoresDownloaded(Highscore[] highscoreList) {


		for (int i =0; i < highscoreList.Length; i ++) {
			//list.( highscoreList[i].username , i);

			numberFields[i].text = i+1 + ". ";
			if (i < highscoreList.Length) {
				nameFields[i].text = highscoreList[i].username ;
				highscoreFields[i].text= "" + highscoreList[i].score;
			}
			if ( namePlayer == highscoreList[i].username)
			{

				scoreText.text = ""+PlayerPrefs.GetInt("bestSCOREPrefs");
			}
		}

	}


	
	IEnumerator RefreshHighscores() {
		while (true) {
			highscoresManager.DownloadHighscores();
			yield return new WaitForSeconds(3);
		}
	}
}
