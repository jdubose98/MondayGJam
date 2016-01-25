using UnityEngine;
using System.Collections;

public class SpeedRacer : MonoBehaviour 
{

	public Controller controller;
		
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.tag == "Player") 
		{
			controller.moveSpeed = controller.moveSpeed * 2;

			Debug.Log(controller.moveSpeed);

			Destroy(this.gameObject);
		}
	}
}
