using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnimalHunger : MonoBehaviour
{
    [SerializeField]
    Slider hungerSlider;

    [SerializeField]
    int maxFedAmount;

    int currentFedAmount = 0;

    HealthSystem healthSystem;


    // Start is called before the first frame update
    void Start()
    {
        healthSystem = new HealthSystem
        {
            MaxHealth = maxFedAmount,
            CurrentHealth = currentFedAmount
        };
        hungerSlider.maxValue = maxFedAmount;
        hungerSlider.value = currentFedAmount;
        hungerSlider.fillRect.gameObject.SetActive(false);        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /// <summary>
    /// Updates the animal fed bar and the score according to animal maxFedAmount
    /// </summary>
    /// <param name="fedAmount"></param>
    public void AnimalHungerController(int fedAmount)
    {
        healthSystem.Heal(fedAmount);
        hungerSlider.fillRect.gameObject.SetActive(true);
        hungerSlider.value = healthSystem.CurrentHealth;
        if(healthSystem.CurrentHealth >= healthSystem.MaxHealth)
        {
            FindObjectOfType<ScoreManager>().ScoreUpdate(maxFedAmount);
            Destroy(gameObject, 0.1f);
        }
    }
}
