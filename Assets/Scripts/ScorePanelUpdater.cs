using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class ScorePanelUpdater : MonoBehaviour
{
    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        GameObject go = GameObject.Find("GameStatus");
        if(go==null){
            Debug.LogError("Failed to find an object name 'GameStatus' ");
            this.enabled = false;
            return;
        }
        GameStatus gs = go.GetComponent<GameStatus>();
        GetComponent<Text>().text = "Score  " + gs.score + "Lives: " + gs.numLives;
    }
}
