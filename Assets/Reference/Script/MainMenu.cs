using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class MainMenu : MonoBehaviour {

	public Canvas highScore_Menu;
	public Canvas setting_Menu;
	public Canvas ads_Menu;
	public Canvas feedBack_Menu;
	public Canvas about_Menu;

	public Text energy_Text;
	public Text energy2_Text;
	public Text level_Text;

	public Text score1_Text;
	public Slider level_Slider;
	public Button play_Button;
	public Button level;
	public Toggle[] game_mod_selecter;
	public Toggle[] theme_selecter;



	public List<Sprite> level_icon;

	// Use this for initialization
	void Start () {

		PlayerPrefs.SetInt ("feedbackPrefs", 0);

		highScore_Menu.enabled = false;
		setting_Menu.enabled = false;
		ads_Menu.enabled = false;
		feedBack_Menu.enabled = false;
		about_Menu.enabled = false;

		int random_number = Random.Range (0, 5);
		print ("/" + random_number);
		if (random_number == 3)
			ads_Menu.enabled = true;
		if (random_number == 4) {
			if (PlayerPrefs.GetInt ("feedbackPrefs") == 0) 
				feedBack_Menu.enabled = true;
			else
				feedBack_Menu.enabled = false;
		}

		//PlayerPrefs.SetInt ("expPrefs", 0);
		PlayerPrefs.SetInt ("energyPrefs", 20);

		score1_Text.text = "SCORE : "+PlayerPrefs.GetInt("scorePrefs");
		level_Text.text = "" + (int)(PlayerPrefs.GetInt ("expPrefs") / 10000);
		level_Slider.value = (float)((PlayerPrefs.GetInt ("expPrefs") % 10000) / 10000.0f);
		print ("xxx" + (PlayerPrefs.GetInt ("expPrefs") ));
		level.image.sprite = level_icon [(int)(PlayerPrefs.GetInt ("expPrefs") / 10000)];
			

		energy_Text.text = "Energy: " + PlayerPrefs.GetInt ("energyPrefs");


	}
	
	// Update is called once per frame
	void Update () {

		level_Slider.value = (float)((PlayerPrefs.GetInt ("expPrefs") % 10000) / 10000.0f);
		energy_Text.text = "Energy: " + PlayerPrefs.GetInt ("energyPrefs");
		energy2_Text.text = "Energy: " + PlayerPrefs.GetInt ("energyPrefs");

		for (int j=0; j<=1; j++)
			if (PlayerPrefs.GetInt ("gameModePrefs") == j)
				game_mod_selecter [j].isOn = true;
			else 
				game_mod_selecter [j].isOn = false;

		for (int i = 0; i< theme_selecter.Length; i++) {
			if (PlayerPrefs.GetInt ("themesPrefs") == i)
				theme_selecter[i].isOn = true;
			else
				theme_selecter[i].isOn = false;
		}

	}

	public void LetsGO()
	{
		for (int j=0; j<=1; j++)
			if (PlayerPrefs.GetInt ("gameModePrefs") == j)
				game_mod_selecter [j].isOn = true;
		else 
			game_mod_selecter [j].isOn = false;

		for (int i = 0; i< theme_selecter.Length; i++) {
			if (PlayerPrefs.GetInt ("themesPrefs") == i)
				theme_selecter[i].isOn = true;
			else
				theme_selecter[i].isOn = false;
		}
		setting_Menu.enabled = true;
	}

	public void CloseSettingMenu ()
	{
		setting_Menu.enabled = false;
	}

	public void Play()
	{
		if (PlayerPrefs.GetInt ("energyPrefs") > 0) {
			PlayerPrefs.SetInt ("energyPrefs", PlayerPrefs.GetInt ("energyPrefs") - 1);
			Application.LoadLevel ("Untitled");
		} else
			ads_Menu.enabled = true;

	}

	public void ShowHighScoreMenu()
	{
		highScore_Menu.enabled = true;
	}

	public void CloseHighScoreMenu()
	{
		highScore_Menu.enabled = false;
	}

	public void CloseADSMenu()
	{
		ads_Menu.enabled = false;
	}

	public void GoFeedBack()
	{
		PlayerPrefs.SetInt ("feedbackPrefs", 1);
	}
	public void CloseFeedBack()
	{
		feedBack_Menu.enabled = false;
	}
	public void ShowAboutMenu()
	{
		about_Menu.enabled = true;
	}
	public void CloseAboutMenu()
	{
		about_Menu.enabled = false;
	}
	///

	public void ColorBaseMod()
	{
		PlayerPrefs.SetInt ("gameModePrefs", 0);

		for (int j = 0 ; j< theme_selecter.Length ; j++)
			theme_selecter[j].enabled = false;
		print ("" + PlayerPrefs.GetInt ("themesPrefs")+" , "+PlayerPrefs.GetInt ("gameModePrefs"));
	}

	public void EmojiBaseMod()
	{
		PlayerPrefs.SetInt ("gameModePrefs", 1);

		for (int j = 0 ; j< theme_selecter.Length ; j++)
			theme_selecter[j].enabled = true;
		print ("" + PlayerPrefs.GetInt ("themesPrefs")+" , "+PlayerPrefs.GetInt ("gameModePrefs"));
	}
	/// 

	public void Theme00Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 0);
	}
	public void Theme01Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 1);
	}
	public void Theme02Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 2);
	}
	public void Theme03Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 3);
	}
	public void Theme04Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 4);
	}
	public void Theme05Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 5);
	}
	public void Theme06Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 6);
	}
	public void Theme07Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 7);
	}
	public void Theme08Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 8);
	}
	public void Theme09Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 9);
	}
	public void Theme10Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 10);
	}
	public void Theme11Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 11);
	}
	public void Theme12Selecter()
	{
		PlayerPrefs.SetInt ("themesPrefs", 12);
	}
}
