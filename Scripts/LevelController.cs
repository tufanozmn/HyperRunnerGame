using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour
{
    public List<GameObject> levels;
    public static int currentLevel;

    void Awake()
    {
        currentLevel = PlayerPrefs.GetInt("Level",0);
        Instantiate(levels[currentLevel % levels.Count], transform.position, Quaternion.identity);
    }
}
