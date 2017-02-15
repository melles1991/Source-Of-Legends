#pragma strict

var relativeCamera : Transform;
var distance : float;

//private var particleSystem : ParticleSystem;

private var play : boolean;
 
function Start () {
	//particleSystem = GetComponent(ParticleSystem);
}

function Update () {
	if(relativeCamera == null){
		relativeCamera = GameObject.FindGameObjectWithTag("MainCamera").transform ;
	}
	var currentDistance : float = Vector3.Distance(transform.position, relativeCamera.position);
	if(currentDistance < distance && !play){
		particleSystem.Play();
		play = true;
	}
	else{
		particleSystem.Stop();
		play = false;
	}
}