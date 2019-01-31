using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour {

 
    public float speed;
    public Rigidbody rb;
    public bool isFirst;
    public bool gameOver;

    public GameObject particle;
 
    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

	// Use this for initialization
	void Start () {
        isFirst = true;
        gameOver = false;
	}
	
	// Update is called once per frame
	void Update () {
        
        if( !Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            Camera.main.GetComponent<CameraFollow>().gameOver = true;
            UIManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            if (isFirst)
            {
                UIManager.instance.GameStart();
                speed = 9f;
                rb.velocity = new Vector3(speed, 0, 0);
                isFirst = false;
            }
            SwitchDirection();
            UIManager.instance.scores++;
        }
		
	}

    void SwitchDirection()
    {
        if(rb.velocity.z > 0)
        {
            rb.velocity = new Vector3(speed, 0, 0);
        }else if(rb.velocity.x > 0)
        {
            rb.velocity = new Vector3(0, 0, speed);
        }
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.gameObject.tag == "Diamond")
        {
           
           GameObject part = Instantiate(particle, coll.gameObject.transform.position, Quaternion.identity) as GameObject ;
            Destroy(coll.gameObject);
            Destroy(part, 1f);
            
        }
    }
}
