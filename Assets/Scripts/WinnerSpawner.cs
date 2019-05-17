using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinnerSpawner : MonoBehaviour
{
    public GameObject[] winner;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("winnerType") == 0)
        {
            Instantiate(winner[(0)], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }

        if (PlayerPrefs.GetInt("winnerType") == 1)
        {
            Instantiate(winner[(1)], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }

        if (PlayerPrefs.GetInt("winnerType") == 2)
        {
            Instantiate(winner[(2)], new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z), Quaternion.identity);
        }
    }
}
