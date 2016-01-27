using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

    [SerializeField] float XMoveRate;
    [SerializeField] float MaxLeftExtent;
    [SerializeField] float MaxRightExtent;
    [SerializeField] float RefireRate;
    [SerializeField] GameObject BulletPrefab;
    [SerializeField] Transform target;
    float firedTime;

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetAxisRaw("Horizontal") != 0){
            if ((Input.GetAxisRaw("Horizontal") < 0) && gameObject.transform.position.x > MaxLeftExtent )
                gameObject.transform.Translate(0, XMoveRate, 0);
            if ((Input.GetAxisRaw("Horizontal") > 0) && gameObject.transform.position.x < MaxRightExtent)
                gameObject.transform.Translate(0, -XMoveRate, 0);
        }

        if (Input.GetKey(KeyCode.Space))
        {
            if (Time.time - firedTime > RefireRate)
            {
                firedTime = Time.time;
                Fire();
            }
        }
	}

    void Fire()
    {
        GameObject obj = NewObjectpoolerScript.current.GetPooledObject();
        if (obj == null)
            return;
        obj.transform.position = target.position;
        obj.transform.rotation = target.rotation;
        obj.SetActive(true);
        gameObject.GetComponent<AudioSource>().Play();

    }
}
