using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollowPlayer1 : MonoBehaviour
{
    private GameObject player;
    public float xMin;
    public float xMax;
    public float yMax;
    public float yMin;

    // Start is called before the first frame update
    void Start()
    {
        GameObject.FindGameObjectWithTag("MainCamera").transform.position = new Vector3(-32, 21, -35);

        if (GameObject.FindGameObjectWithTag("Player1") != null)
        {
            player = GameObject.FindGameObjectWithTag("Player1");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player1") != null)
        {
            gameObject.transform.position = new Vector3(player.transform.position.x, player.transform.position.y, gameObject.transform.position.z);
        }
    }
}
