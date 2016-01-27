using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    void OnEnable()
    {
        Invoke("Destroy", 2f);
    }

    void Destroy()
    {
        gameObject.SetActive(false);
    }

    void OnDisable()
    {


        CancelInvoke();
    }

// Update is called once per frame
    void Update () {
        if (enabled)
        gameObject.transform.Translate(0, 0.2f, 0);
	}
}
