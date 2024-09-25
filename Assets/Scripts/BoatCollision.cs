using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatCollision : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.CompareTag("Entity")) {
            Debug.Log("You Crashed!");
            Destroy(collision.gameObject);
            FinishGameManager.Instance.FinishGame();
        }
    }
}
