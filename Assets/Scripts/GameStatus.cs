using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameStatus : MonoBehaviour
{
    public int numLives = 3;
    public int score = 0;
    // Use this for initialization
    void Start()
    {
        score = PlayerPrefs.GetInt("score", 0);
        numLives = PlayerPrefs.GetInt("lives", 3);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void LoadScene (string sceneName){
        SceneManager.LoadScene(sceneName);
    }
    void OnDestroy(){
        Debug.Log("GameStatus was destroyed");

        PlayerPrefs.SetInt("score", score);
        PlayerPrefs.SetInt("lives", numLives);
    }

    public void AddScore (int s){
        score += s;
    }


}
