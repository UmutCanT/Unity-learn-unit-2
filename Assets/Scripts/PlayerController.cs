using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    GameObject projectilePrefab;

    [SerializeField]
    Text healthText;

    HealthSystem healthSystem;

    float horizontalInput, verticalInput;
    float moveSpeed = 20f;
    float xRange = 24f;
    float zRange = 12f;

    int playerHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem
        {
            MaxHealth = playerHealth,
            CurrentHealth = playerHealth
        };

        healthText.GetComponent<Text>();
        LifeUpdate();   
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate(projectilePrefab, transform.position, Quaternion.identity);
            //or we can use projectilePrefab.transform.rotation for the rotation part because both are same for this instance
        }

        CheckBoundary();

        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * moveSpeed);
        transform.Translate(Vector3.forward * verticalInput * Time.deltaTime * moveSpeed);
    }

    public void DamagePlayer(int damageAmount)
    {
        healthSystem.Damage(damageAmount);
    }

    public void LifeUpdate()
    {
        healthText.text = "Player Health: " + healthSystem.CurrentHealth;
    }

    void CheckBoundary()
    {
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }

        if (transform.position.z < -zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, -zRange);
        }

        if (transform.position.z > zRange)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y, zRange);
        }
    }
}
