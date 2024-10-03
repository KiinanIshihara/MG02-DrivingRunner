using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoadManager : MonoBehaviour
{
    public static RoadManager Instance;
    [SerializeField] public float speed = 5f;  // Speed at which the road moves

    void Awake() {
        Instance = this;
    }

    void Update()
    {
        // Move the road down every frame
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // If the road goes off-screen (out of view), destroy it
        if (transform.position.y < -20f)  // Adjust this value based on your screen size
        {
            Destroy(gameObject);  // This will remove the old road sections
        }
    }

    public float GetSpeed() {
        return speed;
    }
}
