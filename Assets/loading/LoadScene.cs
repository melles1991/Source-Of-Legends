using UnityEngine;
using System.Collections;

public class LoadScene : MonoBehaviour {
	private int pRounded;
	public GUIStyle Main;
	public GUIStyle BackGround;
	
	
	void Start () {
		StartCoroutine("launchLevel");
	}
	
	IEnumerator launchLevel(){
		AsyncOperation async = Application.LoadLevelAsync(2);
			
		while(async.isDone == false) {
			float p = async.progress * 100f;
            pRounded = Mathf.RoundToInt(p);
            string perc = pRounded.ToString();
				
            Debug.Log ("Прогресс загрузки: " + perc + " %.");   
				
            yield return true;
		}
	}
	
	void OnGUI () {
		GUI.Box(new Rect(0, 0, Screen.width, Screen.height), "", Main);
		GUI.Box(new Rect((Screen.width - 1000) / 2, Screen.height - 40, 10*pRounded, 30), "", BackGround);
	}
}
