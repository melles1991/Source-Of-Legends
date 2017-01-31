using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class startMenu : MonoBehaviour 
{
	public void new_game()
	{
		SceneManager.LoadScene (1);
	}

	public void exit_game()
	{
		Application.Quit ();
	
	}


}
