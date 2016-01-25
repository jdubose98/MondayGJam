using UnityEngine;
using System.Collections;

public class Resetter : MonoBehaviour {

	// Use this for initialization
	void OnCollisionEnter(Collision hitObject)
    {
        Debug.Log("hello?");
        if (hitObject.gameObject.tag == "Player")
        {
            Debug.Log("we found it");
            Application.LoadLevel(0);
        }

        if (hitObject.gameObject.tag == "Enemy")
        {
            Debug.Log("we found freeman");
            Destroy(hitObject.gameObject);
        }
    }
}
