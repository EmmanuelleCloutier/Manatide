using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

public class UIManagerV2 : MonoBehaviour
{
    
//basic UI
	public void GoToMainMenu()
	{
		SceneManager.LoadScene("LVL_MainMenu");
    }

 	public void GoToInformation()
    {
        SceneManager.LoadScene("LVL_Information");
    }

	public void GoToSettings()
    {
        SceneManager.LoadScene("LVL_Settings");
    }

	public void GoToCredits()
    {
        SceneManager.LoadScene("LVL_Credits");
    }

//pour chaque niveau 
	public void GoToLangune()
    {
        SceneManager.LoadScene("LVL_Langune");
    }

	public void GoToEpave()
    {
        SceneManager.LoadScene("LVL_Epave");
    }

	public void GoToKelp()
    {
        SceneManager.LoadScene("LVL_Kelp");
    }


//quit game 
	 public void QuitGame()
    {
        Application.Quit();
    }
   
}
