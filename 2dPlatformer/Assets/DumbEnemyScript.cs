using UnityEngine;
using System.Collections;

public class DumbEnemyScript : MonoBehaviour {

    [SerializeField] Transform Player;
    [SerializeField] float MaxChaseRange;
    [SerializeField] float MaxMoveSpeed;
    [SerializeField] float JumpPower;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Mathf.Abs(Player.position.x - gameObject.transform.position.x) <= MaxChaseRange)
        {
            Debug.Log("In range");
            if (Player.position.x - gameObject.transform.position.x > 0)
            {
                gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(MaxMoveSpeed, 0));
            }
            else if (Player.position.x - gameObject.transform.position.x < 0)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-MaxMoveSpeed, 0));
            }
        }
	}
}
