using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformSpawner : MonoBehaviour {

    public GameObject platform;
    public GameObject diamond;

    Vector3 lastPos;
    float size;
    int decision;
    bool gameOver;

	// Use this for initialization
	void Start () {
        lastPos = platform.transform.position;
        size = platform.transform.localScale.x;

      
        for(int i=0; i<20; i++)
        {
            Spawn();
        }

        InvokeRepeating("Spawn", 2, 0.2f);

    }
	
	// Update is called once per frame
	void Update () {
        

        
		
	}

    void SpawnX()
    {
        Vector3 pos = lastPos;
        pos.x += size;

        Instantiate(platform, pos, Quaternion.identity);

        lastPos = pos;

        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y+1, pos.z), diamond.transform.rotation);
        }
        
    }

    void SpawnZ()
    {
        Vector3 pos = lastPos;
        pos.z += size;

        Instantiate(platform, pos, Quaternion.identity);

        lastPos = pos;
        int rand = Random.Range(0, 4);
        if (rand < 1)
        {
            Instantiate(diamond, new Vector3(pos.x, pos.y + 1, pos.z), diamond.transform.rotation);
        }
    }

    void Spawn()
    {
        decision = Random.Range(0, 7);
        if (decision <3)
        {
            SpawnX();
        }else if (decision >3)
        {
            SpawnZ();
        }
    }

  
}
