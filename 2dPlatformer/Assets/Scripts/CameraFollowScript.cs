using UnityEngine;
using System.Collections;

public class CameraFollowScript : MonoBehaviour 
{
    [SerializeField] float OffsetX;
    [SerializeField] float OffsetY;
    [SerializeField] GameObject BackingCanvas;
    [SerializeField] float Damping;

	public Transform player;
    Vector3 lastpos;
	void Update () 
	{
		transform.position = Vector3.Lerp(new Vector3(player.position.x + OffsetX, player.position.y + OffsetY, -10),lastpos,Damping);
        float parallax = gameObject.transform.position.x / 1.1f;
        BackingCanvas.transform.position = new Vector3(parallax,-1.99f,0);
        lastpos = new Vector3(player.position.x + OffsetX, player.position.y + OffsetY, -10);
    }
}
