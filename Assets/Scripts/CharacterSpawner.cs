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
            Instantiate(players[(0)], Vector2.zero, Quaternion.identity);
        }

        if (PlayerPrefs.GetInt("selectedCharacter") == 1)
        {
            Instantiate(players[(1)], Vector2.zero, Quaternion.identity);
        }

        if (PlayerPrefs.GetInt("selectedCharacter") == 2)
        {
            Instantiate(players[(2)], Vector2.zero, Quaternion.identity);
        }

        if (PlayerPrefs.GetInt("selectedCharacter") == 3)
        {
            Instantiate(players[(3)], Vector2.zero, Quaternion.identity);
        }
    }
}
