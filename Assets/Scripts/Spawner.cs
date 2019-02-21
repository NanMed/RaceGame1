using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    public float waitingForNextSpawn = 10000;
    public float theCountdown = 10000;

    // the range of X
    [Header("X Spawn Range")]
    public float xMin;
    public float xMax;

    // the range of y
    [Header("Y Spawn Range")]
    public float yMin;
    public float yMax;


    void Start()
    {
    }

    public void Update()
    {
        // timer to spawn the next goodie Object
        theCountdown -= Time.deltaTime;
        if (theCountdown <= 0)
        {
            SpawnOil();
            theCountdown = waitingForNextSpawn;
        }
    }

    void SpawnOil()
    {
        //Defines the min and max ranges for x and y

        Vector2 pos = new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax));


        GameObject oil;

        // Creates the random object at the random 2D position.
        Instantiate(oil, new Vector2(Random.Range(xMin, xMax), Random.Range(yMin, yMax)),0);
    }
}
