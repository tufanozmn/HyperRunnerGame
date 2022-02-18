using System.Net.Mime;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GamePlay : MonoBehaviour
{
    public static GamePlay gamePlay;

    public bool isGameStarted;
    public GameObject startPanel;
    public GameObject restartPanel;
    public GameObject nextLevelPanel;

    public PlayerMove playerMove;

    public Text elmasTxt;
    public Text gecicielmas;

    void Awake()
    {
        gamePlay=this;
    }
    public void Start()
    {
         PlayerPrefs.SetInt("geciciElmas", 0);
    }
    public void RestartGame()
    {
        restartPanel.SetActive(true);
    }

    public void Restart(){
        SceneManager.LoadScene("MenuScene");
    }

    public void StartGame(){
        playerMove.StartRunning();
        startPanel.SetActive(false);

    }

    public void NextLevel()
    {
        PlayerPrefs.SetInt("Level",LevelController.currentLevel+1);
        elmasTxt.text = "Elmas: " + PlayerPrefs.GetInt("Elmas: ").ToString();
        gecicielmas.text = "Elmas\n" + PlayerPrefs.GetInt("geciciElmas").ToString() + "\n KAZANDIN";

        nextLevelPanel.SetActive(true);
    }

    public void Next(){
        SceneManager.LoadScene("GameScene");
    }

    

    

}
