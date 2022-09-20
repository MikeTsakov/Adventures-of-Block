using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DisplayFinalScore : MonoBehaviour
{
    //public PlayerController player;
    public Text finalScore;
    // Start is called before the first frame update
    void Start()
    {
        finalScore.text = "Final Score: " + PlayerController.Score.ToString();
    }

    public void ReturnToMainMenu()
    {
        PlayerController.Score = 0;
        SceneManager.LoadScene("menu");
        PlayerPrefs.SetFloat("Volume", 0.35f);
    }
}
