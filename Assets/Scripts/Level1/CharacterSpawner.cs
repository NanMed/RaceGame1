using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterSpawner : MonoBehaviour
{
    public GameObject[] players;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("selectedCharacter") == 0)
        {
            Instantiate(players[(0)], new Vector3(-45f, 21f, -5.4f), new Quaternion(0f, 0f, -18.898f, 360));
        }

        if (PlayerPrefs.GetInt("selectedCharacter") == 1)
        {
            Instantiate(players[(1)], new Vector3(-45f, 21f, -5.4f), new Quaternion(0f, 0f, -18.898f, 360));
        }

        if (PlayerPrefs.GetInt("selectedCharacter") == 2)
        {
            Instantiate(players[(2)], new Vector3(-45f, 21f, -5.4f), new Quaternion(0f, 0f, -18.898f, 360));
        }
    }
}
