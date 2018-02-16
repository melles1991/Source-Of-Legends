using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneLoading : MonoBehaviour
{
	[Header ("Загружамая сцена")]
	public int sceneID;
	[Header ("Остальные обьекты")]
    public Scrollbar scrollbar;
	public Text progressText;

	void Start ()
	{
		StartCoroutine(AsyncLoad());
	}

	IEnumerator AsyncLoad()
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneID);
		while (!operation.isDone)
		{
			float progress = operation.progress / 0.9f;
            scrollbar.size = progress;
			progressText.text = string.Format("{0:0}", progress * 100);
			yield return null;
		}

	}
}