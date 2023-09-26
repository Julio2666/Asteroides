using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemyspawner : MonoBehaviour
{
    public GameObject asteroidpref;
    public float spawnRate=30f;
    public float spawnRateIncr = 1f;
    public float xlimit;
    public float maxLife=4f;

    private float spawnNext = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > spawnNext) {
            spawnNext = Time.time+60/spawnRate;
            spawnRate += spawnRateIncr;
            float rand=Random.Range(-xlimit, xlimit);
            Vector2 spawnPos=new Vector2(rand,3f);
            GameObject meteor= Instantiate(asteroidpref,spawnPos,Quaternion.identity);
            Destroy(meteor,maxLife);
        }
    }
}
