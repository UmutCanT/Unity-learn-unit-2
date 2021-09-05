using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerController>().DamagePlayer(1);
            other.GetComponent<PlayerController>().LifeUpdate();
            Destroy(gameObject);
        }
        if (other.gameObject.CompareTag("Animal"))
        {
            other.GetComponent<AnimalHunger>().AnimalHungerController(1);
            Destroy(gameObject);           
        }
    }
}
