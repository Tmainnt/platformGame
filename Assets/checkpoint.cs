using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkpoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other) {
        if (other.CompareTag("Player")){
            HealthSystem healthSystem = other.GetComponent<HealthSystem>();

            if (healthSystem != null)
            {
                healthSystem.setCheckpoint(transform.position);
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
