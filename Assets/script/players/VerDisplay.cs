/// <summary>
/// Player bar display.
/// Выводит на экран бары игрока
/// Вешать на игрока
/// </summary>
using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class VerDisplay : MonoBehaviour {
	public Text textVer;

    void Start()
	{
		textVer.text = "0.0.1 build 10";

	}

}