using UnityEngine;
using System.Collections;

public class DumbEnemyScript : MonoBehaviour {

    [SerializeField] Transform Player;
    [SerializeField] float MaxChaseRange;
    [SerializeField] float MaxMoveSpeed;
    [SerializeField] float MovePower;
    [SerializeField] float JumpPower;

    float speed;
    float afternow;
    Vector3 lastPosition;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

        if (Mathf.Abs(Player.position.x - gameObject.transform.position.x) <= MaxChaseRange)
        {
            if (Player.position.x - gameObject.transform.position.x > 0)
            {
                if (speed < MaxMoveSpeed)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(MovePower, 0));
                }
            }
            else if (Player.position.x - gameObject.transform.position.x < 0)
            {
                if (speed < MaxMoveSpeed)
                {
                    gameObject.GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(-MovePower, 0));
                }
            }
            else if (Player.position.y - gameObject.transform.position.y > 0)
            {
                //Debug.Log("Player above");
                if (Time.time >= afternow)
                {
                    Debug.Log("Jumping");
                    gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(0, JumpPower));
                    afternow = Time.time + 2;
                    Debug.Log(afternow);
                }
            }
        }
	}

    void FixedUpdate()
    {
        speed = (transform.position - lastPosition).magnitude;
        lastPosition = transform.position;
    }

    void OnCollisionEnter(Collision hitObject)
    {
        Debug.Log("HIT");
        if (hitObject.gameObject.tag == "Player")
        {
            Debug.Log("I hit the palyer");
            Application.LoadLevel(0);
        }
    }
}
