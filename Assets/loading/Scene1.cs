using UnityEngine;
using System.Collections;

public class Scene1 : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnGUI () {
		if(GUI.Button(new Rect((Screen.width - 200) / 2, (Screen.height - 200) / 2, 200, 200), "Загрузить сцену 2")) {
			Application.LoadLevel(1);
		}
	}
}
