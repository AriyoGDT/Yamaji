using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Highscores : MonoBehaviour {

	const string privateCode = "iBm5ubp6v0OtRRVr63ZJYwt1grHTPTY0Wl4o6PyZRwjw";
	const string publicCode = "5570db3e6e51c023fcd771e0";
	const string webURL = "http://dreamlo.com/lb/";
	DisplayHighscores highscoreDisplay;
	public Highscore[] highscoresList;

	void Awake() {
		highscoreDisplay = GetComponent<DisplayHighscores>();
		AddNewHighscore(PlayerPrefs.GetString("usernamePrefs"), PlayerPrefs.GetInt("bestSCOREPrefs"));


		DownloadHighscores();
	}

	public void AddNewHighscore(string username, int score) {
		StartCoroutine(UploadNewHighscore(username,score));
	}

	IEnumerator UploadNewHighscore(string username, int score) {
		WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
		yield return www;

		if (string.IsNullOrEmpty(www.error))
			print ("Upload Successful");
		else {
			print ("Error uploading: " + www.error);
		}
	}

	public void DownloadHighscores() {
		StartCoroutine("DownloadHighscoresFromDatabase");
	}

	IEnumerator DownloadHighscoresFromDatabase() {
		WWW www = new WWW(webURL + publicCode + "/pipe/");
		yield return www;
		
		if (string.IsNullOrEmpty (www.error)) {
						FormatHighscores (www.text);
			PlayerPrefs.SetString("list" , www.text);
			highscoreDisplay.OnHighscoresDownloaded(highscoresList);

				}
		else {
			print ("Error Downloading: " + www.error);
		}
	}

	void FormatHighscores(string textStream) {
		string[] entries = textStream.Split(new char[] {'\n'}, System.StringSplitOptions.RemoveEmptyEntries);
		highscoresList = new Highscore[entries.Length];

		for (int i = 0; i <entries.Length; i ++) {
			string[] entryInfo = entries[i].Split(new char[] {'|'});
			string username = entryInfo[0];
			int score = int.Parse(entryInfo[1]);
			highscoresList[i] = new Highscore(username,score);

			print (highscoresList[i].username + ": " + highscoresList[i].score);
		}
	}
	public void BackToHome()
	{
		Application.LoadLevel("MainMenu");
	}

}



public struct Highscore {
	public string username;
	public int score;

	public Highscore(string _username, int _score) {
		username = _username;
		score = _score;
	}

}
