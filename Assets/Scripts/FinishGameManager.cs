using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishGameManager : MonoBehaviour
{
    public static FinishGameManager Instance;
    [SerializeField] private GameObject gameOverPanel;
    [SerializeField] private GameObject counterPanel;

    [SerializeField] private TextMeshProUGUI traveledText;

    private void Awake() {
        Instance = this;
    }



    public void FinishGame() {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
        counterPanel.SetActive(false);
        
        float finalTravelDistance = MilesManager.Instance.finalDistance();
        traveledText.text = "You survived " + finalTravelDistance + " miles";


    }

    public void RestartGame() {
        Time.timeScale = 1;
        gameOverPanel.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
