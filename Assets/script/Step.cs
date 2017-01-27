using System;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;
using Random = UnityEngine.Random;

public class Step : MonoBehaviour {
	public Animation animation;
	public CharacterController controller;
    private float speed = 6.0F;
	public float speedStep = 6.0f;
	public float speedShift = 9.0f;
    public float gravity = 20.0F;
	public float speedRotate = 4;
    private Vector3 moveDirection = Vector3.zero;
	
	// Анимации
	public AnimationClip a_Idle;

	
	public AnimationClip a_Walk;

	
	public AnimationClip a_Run;

	
	private string s_anim;
	

	void Start() {

		controller = GetComponent<CharacterController>();

		
		GetComponent<Animation> ()[a_Idle.name].wrapMode = WrapMode.Loop;
		GetComponent<Animation> ()[a_Walk.name].wrapMode = WrapMode.Loop;
		GetComponent<Animation> ()[a_Run.name].wrapMode = WrapMode.Loop;
		
		s_anim = a_Idle.name;
		
	}
	
    void Update() {
		animation = GetComponent<Animation> ();	
        if (controller.isGrounded) {
            moveDirection = new Vector3(0, 0, Input.GetAxis("Vertical"));
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
			
			if (Input.GetKey(KeyCode.LeftShift))
				speed = speedShift;
			else speed = speedStep;
			
			// Анимация ходьбы
			if(Input.GetAxis("Vertical") > 0) {
				if(speed == speedShift) {
					s_anim = a_Run.name;

				} else {
					s_anim = a_Walk.name;

				}
			} else 
			if(Input.GetAxis("Vertical") < 0) {
				if(speed == speedShift) {
					s_anim = a_Run.name;

				} else {
					s_anim = a_Walk.name;

				}
			} else
			if(Input.GetAxis("Vertical") == 0) 
				s_anim = a_Idle.name;
			
			// Поворот 
			transform.Rotate(Vector3.down * speedRotate * Input.GetAxis("Horizontal") * -1, Space.World);
        }
		
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
    }
}