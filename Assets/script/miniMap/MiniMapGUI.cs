using UnityEngine;
using System.Collections;


public class MiniMapGUI : MonoBehaviour 
{
	public RenderTexture miniMapTexture;
	public Texture2D miniMapHope;
	public Material miniMapMaterial;
	float offset =10;

	public Texture2D minus;
	public Texture2D plus;
	float CamSize = 20f;
	float CamSizeMax =37f;
	float CamSizeMin=6f;

	public GameObject _cc;

	void Update ()
	{
		Vector3 pos = _cc.transform.position;
		gameObject.transform.position = new Vector3 (pos.x, 40f, pos.z);
		gameObject.GetComponent<Camera> ().orthographicSize = CamSize;
	
	}

	void OnGUI()
	{
		if (Event.current.type == EventType.Repain) {
			Graphics.DrawTexture (new Rect (Screen.width - 256 - offset, offset, 256, 256), miniMapTexture, miniMapMaterial);
			Graphics.DrawTexture (new Rect (Screen.width - 256 - offset*2,0, 256+offset*2, 256+offset*2), miniMapHope);

		}
		if ((GUI.Button (new Rect (Screen.width - 256 - offset, 0, 50, 50), plus)) && (CamSize >= CamSizeMin)) {
			CamSize -= 3f;
		}
		if ((GUI.Button (new Rect (Screen.width - 50 - offset, 0, 50, 50), minus)) && (CamSize <= CamSizeMax)) {
			CamSize += 3f;
		}
	}

}
