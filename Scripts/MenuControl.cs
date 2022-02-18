using System.Globalization;
using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuControl : MonoBehaviour
{
    public Text elmas;
    public Text seviye;
    public void Start(){
         elmas.text = "Elmas\n" + PlayerPrefs.GetInt("Elmas: ").ToString();
         seviye.text = "Seviye\n" +  PlayerPrefs.GetInt("Level").ToString();
    }
    public void StartFunc(){
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
