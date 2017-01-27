using UnityEngine;

public class Teleport : MonoBehaviour {

	public bool teleported = false;
	public Teleport target;
	
	void OnTriggerEnter (Collider other)
	{
		if (other.CompareTag("Player"))
		{
			if (!teleported)
			{
				target.teleported = true;
				other.gameObject.transform.position = target.gameObject.transform.position;
			}
		}
	}
	
	void OnTriggerExit (Collider other)
	{
		if(other.CompareTag("Player"))
		{
			teleported = false;
		}
	}
}
