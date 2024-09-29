using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SectionTrigger : MonoBehaviour
{
    public GameObject RoadObject;

    // This is the correct method for 2D trigger detection
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))  // Ensure the car has the "Player" tag
        {
            // Instantiate the new road section
            Instantiate(RoadObject, transform.position + new Vector3(0, 15, 0), Quaternion.identity);
        }
    }
}
