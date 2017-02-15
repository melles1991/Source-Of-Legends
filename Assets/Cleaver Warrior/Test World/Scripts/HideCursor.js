#pragma strict

var showCursor : boolean;
var lockCursor : boolean;

var toggleKey : KeyCode;

function Start () {

}

function Update () {
	Screen.showCursor = showCursor;
	Screen.lockCursor = lockCursor;
	if(Input.GetKeyDown(toggleKey)){
		showCursor = !showCursor;
		lockCursor = !lockCursor;
	}
}