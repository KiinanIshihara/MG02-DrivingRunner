using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class StartGameManager : MonoBehaviour
{
    public static StartGameManager Instance;
    [SerializeField] private GameObject startPanel;
    [SerializeField] private GameObject counterPanel;


    void Awake() {
        Instance = this;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        startPanel.SetActive(false);
        counterPanel.SetActive(true);
        SpawnManager.Instance.StartScript();
        MilesManager.Instance.StartScript();
        enabled = false;
    }
}
