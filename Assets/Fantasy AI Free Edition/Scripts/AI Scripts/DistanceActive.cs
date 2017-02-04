using UnityEngine;
using System.Collections;

public class DistanceActive : MonoBehaviour {
	//NEEDS PLAYERS LOCATION TO DETECT DISTANCE
	public Transform Player;
	//THE DISTANCE FROM PLAYER THE AI WILL BECOME ACTIVE
	public float DistanceToActivateAI;
	private AnimationClip idle;
	public int checkdistevery=10;
	private int chcount;
	public bool PlayIdleAnimationWhenDeactive=true;
	public Rigidbody rb;
	
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	FreeAI AI=(FreeAI)GetComponent("FreeAI");
	
	}
	
	// Update is called once per frame
	void Update () {
		chcount=chcount+1;
		if(chcount>=checkdistevery){
	if(Player){
			//GET DISTANCE
		float dist=Vector3.Distance(transform.position, Player.transform.position);
			//GET AI COMPONENT
			 FreeAI AI=(FreeAI)GetComponent("FreeAI");
			
			
			//WHEN DISTANCE BECOMES LESS THE ACTIVATE DISTANCE
			if(dist<=DistanceToActivateAI){
				
				
			if(AI.enabled){}
				else AI.enabled=true;
				if(rb.isKinematic)rb.isKinematic=false;
			}
			else{
				if(rb.isKinematic){}
				else rb.isKinematic=true;
				
				if(AI.enabled)AI.enabled=false;
				if(PlayIdleAnimationWhenDeactive){
					if(AI.IsDead){}
					else{
					
			
					}
			}
			}
			
		}
			chcount=0;
		}
		
	}
}
