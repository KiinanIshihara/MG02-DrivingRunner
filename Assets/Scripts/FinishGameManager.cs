using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishGameManager : MonoBehaviour
{
    public static FinishGameManager Instance;

    private void Awake() {
        Instance = this;
    }



    public void FinishGame() {
        Time.timeScale = 0;

    }
}
