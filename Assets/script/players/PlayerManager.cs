// покой 0
// ходьба вперед 1
// бег вперед 2
// прижок 3
// ходьба назад 4
// ходьба вправо 5
// ходьба влево 6
// атака mous1 100


using UnityEngine;
using System.Collections;
using UnityStandardAssets.Characters.FirstPerson;
using UnityStandardAssets.CrossPlatformInput;
using UnityStandardAssets.Utility;


public class PlayerManager : MonoBehaviour {

    Vector3 realPosition = Vector3.zero;
    Quaternion realRotation = Quaternion.identity;
    public Camera _camera;
    public Animator anim;
    public AudioClip m_AtakSound;   
	public AudioSource m_AudioSource;

	void Start(){
		gameObject.name = "player";
		m_AudioSource = GetComponent<AudioSource>();
	}
    void Update() {
            anim.SetInteger("get_anim", 0); //анимация покоя 
		//анимация ходьбы и бега
		if (Input.GetKey (KeyCode.W)) {
			anim.SetInteger ("get_anim", 1);
			if (Input.GetKey (KeyCode.LeftShift)) {
				anim.SetInteger ("get_anim", 2);
			}
		}
		// анимия прижка
		if (Input.GetKey (KeyCode.Space)) {
			anim.SetInteger ("get_anim", 3);
		}

		if (Input.GetKey (KeyCode.S)) {
			anim.SetInteger ("get_anim", 4);
			if (Input.GetKey (KeyCode.Space)) {
				anim.SetInteger ("get_anim", 3);
			}
		}
			
		if (Input.GetKey(KeyCode.A)){
			anim.SetInteger("get_anim", 6);
			if (Input.GetKey(KeyCode.Space)) {
			    anim.SetInteger("get_anim", 3);
			}
		}

		if (Input.GetKey (KeyCode.D)) {
			anim.SetInteger ("get_anim", 5);
			if (Input.GetKey (KeyCode.Space)) {
				anim.SetInteger ("get_anim", 3);
			}
		}

		//анимация атаки
		if (Input.GetKeyDown (KeyCode.Mouse0)){
			anim.SetInteger ("get_anim", 100);
				m_AudioSource.clip = m_AtakSound;
				m_AudioSource.Play ();
		}
	  







    }
			

		

}



