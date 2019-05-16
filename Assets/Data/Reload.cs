using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Data", menuName = "GameRules", order = 1)]
public class Reload : ScriptableObject
{
    public bool Restarted = false;
}
