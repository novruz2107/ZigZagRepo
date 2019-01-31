using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightFollow : MonoBehaviour {

    public GameObject ball;
    public Vector3 offset;
    public float lerpRate;
    public bool gameOver;

    // Use this for initialization
    void Start () {
        offset = new Vector3(5, 5, 5);
        gameOver = false;

    }
	
	// Update is called once per frame
	void Update () {
        if (!gameOver)
        {
            Follow();
        }
	}

    void Follow()
    {
        Vector3 pos = transform.position;
        Vector3 targetPos = ball.transform.position - offset;
        pos = Vector3.Lerp(pos, targetPos, lerpRate * Time.deltaTime);
        transform.position = pos;
    }
}
