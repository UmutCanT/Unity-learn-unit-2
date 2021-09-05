using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    Countdown countdown;
    public GameObject dogPrefab;
    public float fireInterval = 3f;
    bool allowFire = true;

    void Start()
    {
        countdown = gameObject.AddComponent<Countdown>();
        countdown.TotalTime = fireInterval;
    }

    // Update is called once per frame
    void Update()
    {
        if (countdown.IsFinished)
        {
            allowFire = true;
        }
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.Space) && allowFire)
        {
            allowFire = false;
            countdown.StartCd();
            Instantiate(dogPrefab, transform.position, dogPrefab.transform.rotation);
        }
    }
}
