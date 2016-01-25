using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour 
{
    [SerializeField] float OffsetX;
    [SerializeField] float OffsetY;

	public Transform player;
	void Update () 
	{
		transform.position = new Vector3 (player.position.x + OffsetX, player.position.y + OffsetY, -10);
	}
}
