using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;
using TMPro;

public class MenuManager : MonoBehaviour
{
    public Button StartButton;  
    public Button ExitButton;
    public Button BackButton;
    public InputField inputField; 
    public TextMeshProUGUI TopScoreText;

    void Start()
    {
        TopScoreText.text = "Top 1 : " + DataManager.Instance.topPlayerName + " : " + DataManager.Instance.topScore;
    }

      public void BackMenu()
    {
        SceneManager.LoadScene(0);
    }
  
    public void StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void ExitGame()
    {
        Application.Quit();
        
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    public void CaptureText()
    {
        DataManager.Instance.playerName = inputField.text;
       // Debug.Log("Texto digitado: " + DataManager.Instance.playerName);
    }

  
    
}