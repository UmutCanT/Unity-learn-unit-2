using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    float xBounds = 25f;
    float zBounds = 15f;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z > zBounds)
        {
            Destroy(gameObject);
        }
        else if (transform.position.z < -zBounds)
        {
            Destroy(gameObject);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().DamagePlayer(1);
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().LifeUpdate();
        }

        if (transform.position.x > xBounds)
        {
            Destroy(gameObject);
        }
        else if (-transform.position.x > xBounds)
        {
            Destroy(gameObject);
        }
    }
}
