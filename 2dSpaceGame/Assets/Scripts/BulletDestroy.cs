using UnityEngine;
using System.Collections;

public class BulletDestroy : MonoBehaviour 
{
	void OnEnable()
	{
		Invoke ("Destroy", 2f);
	}

	void Destroy ()
	{
		gameObject.SetActive (false);
	}

	void OnDisable ()
	{


		CancelInvoke ();
	}

    void OnTriggerEnter2D(Collider2D hit)
    {
        Debug.Log("HIT");
        if (hit.gameObject.tag == "Enemy")
        {
            Destroy(hit.gameObject);
            gameObject.SetActive(false);
        }
    }
}
