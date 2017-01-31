using UnityEngine;
using System.Collections;

public class startMenu : MonoBehaviour 
{
	public void new_game()
	{
		Application.LoadLevel (1);
	}

	public void exit_game()
	{
		Application.Quit ();
	
	}


}
