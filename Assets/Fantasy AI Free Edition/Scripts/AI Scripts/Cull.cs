using UnityEngine;
using System.Collections;


public class Cull : MonoBehaviour {
	public bool CullAtStart;
	public Renderer rend;
	
	// Use this for initialization
	void Start () {
		rend = GetComponent<Renderer>();
	if(CullAtStart)rend.enabled=false;
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
