using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameManager : MonoBehaviour
{


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.S)) {
            StartGame();
        }
    }

    private void StartGame() {
        SpawnManager.Instance.StartScript();
    }
}
