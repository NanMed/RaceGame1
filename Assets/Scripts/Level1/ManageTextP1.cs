using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ManageTextP1 : MonoBehaviour
{
    public static ManageTextP1 instance;
    private void Awake()
    {
        instance = this;
    }

    public Text lapText;
    public Text coinText;
    public GameObject win;
    public GameObject lose;
    public GameObject NextLevel;
}
