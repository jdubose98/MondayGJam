using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Player2D))]
public class Controller : MonoBehaviour 
{
	public float jumpHeight = 4;
	public float timeToJumpApex = .4f;
	public float moveSpeed = 6f;
	float acclerationTimeAirborne = .2f;
	float acclerationTimeGrounded = .1f;
	
	
	public float gravity;
	float jumpVelocity;
	
	float velocityXSmoothing;
	
	Vector3 velocity;
	
	
	
	Player2D controller;
	
	void Start () 
	{
		controller = GetComponent<Player2D> ();
		
		gravity = -(2 * jumpHeight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
		print ("Gravity:" + gravity + " Jump Velocity" + jumpVelocity);
	}
	
	void Update()
	{
		if (controller.collisions.above || controller.collisions.below) 
		{
			velocity.y = 0;
		}
		
		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		
		if (Input.GetKeyDown (KeyCode.W) && controller.collisions.below) 
		{
			velocity.y = jumpVelocity;
		}
		
		float targetVelocityX = input.x * moveSpeed;
		velocity.x = Mathf.SmoothDamp (velocity.x, targetVelocityX, ref velocityXSmoothing, (controller.collisions.below)?acclerationTimeGrounded:acclerationTimeAirborne);
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}
