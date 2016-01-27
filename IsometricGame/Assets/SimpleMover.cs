using UnityEngine;
using System.Collections;

public class SimpleMover : MonoBehaviour {

    Transform StartTilePosition;
    Transform EndTilePosition;

    // Use this for initialization
    void Start() {
        StartTilePosition = GameObject.FindWithTag("StartTile").transform;
        EndTilePosition = GameObject.FindWithTag("GoalTile").transform;
        gameObject.transform.position = StartTilePosition.position + new Vector3(0,0,0);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Time.time % .1);
        if (Time.time % .1 <= 0.02)
        {
            if (Input.GetAxisRaw("Horizontal") != 0)
            {
                if (Input.GetAxisRaw("Horizontal") > 0)
                {
                    gameObject.transform.Translate(new Vector3(2, 0, 0));
                }
                if (Input.GetAxisRaw("Horizontal") < 0)
                {
                    gameObject.transform.Translate(new Vector3(-2, 0, 0));
                }
                gameObject.GetComponent<AudioSource>().Play();
            }

            if (Input.GetAxisRaw("Vertical") != 0)
            {
                if (Input.GetAxisRaw("Vertical") > 0)
                {
                    gameObject.transform.Translate(new Vector3(0, 0, 2));
                }
                if (Input.GetAxisRaw("Vertical") < 0)
                {
                    gameObject.transform.Translate(new Vector3(0, 0, -2));
                }
                gameObject.GetComponent<AudioSource>().Play();
            }
            
        }
        
        if (gameObject.transform.position == EndTilePosition.position)
        {
            Debug.Log("Edn");
        }
    }
}
