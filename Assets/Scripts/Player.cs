using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


    public class Player : MonoBehaviour
    {
        int health = 100;
        public int Health => health; //read only property
        public int currentHealth;
        public HealthBar healthBar;
 
        float strength = 10.0f;
        public float Strength => strength;

        float speed = 5.0f;
        public float Speed => speed;

        float originalSpeed;
        float speedBoostDuration = 0.0f;  // How long the boost lasts
        float speedBoostTimer = 0.0f; // to track how much time has passed since the speed boost was activated.
        bool isSpeedBoostActive = false; // tracks whether the speed boost is currently active or not.

        [SerializeField] TextMeshProUGUI healthTxt, strengthTxt, speedTxt;
        void Start()
        {
           currentHealth = health;
           healthBar.SetMaxHealth(health);
            originalSpeed = speed;
            UpdateHealthText();
            UpdateSpeedText();
            UpdateStrengthText();

        }

        void Update()
        {
            UpdateSpeedBoostTimer();
        /*Checking HP Bar damage by pressing Spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
            TakeDamage(20);
            }
        */
    }

    // Method for taking Damage to Update HP UI
    public void TakeDamage(int damage)
    { 
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
    }// End TakeDamage
        void UpdateSpeedBoostTimer()
        {
            if (isSpeedBoostActive)
            {
                speedBoostTimer += Time.deltaTime;
                Debug.Log("+++Speed Boost...");
                if (speedBoostTimer >= speedBoostDuration)
                {
                    speed = originalSpeed;
                    isSpeedBoostActive = false;
                    Debug.Log("Speed boost ended. Speed reset.");

                }
            }
        }

        public void PowerUp(int healthIncrease)
        {
            health += healthIncrease;
            Debug.Log($"Health increased by {healthIncrease}. New health: {health}");
            UpdateHealthText();
        }

        public void PowerUp(float atkMultiplier)
        {
            strength *= atkMultiplier;
            UpdateStrengthText();
            Debug.Log($"Strength  increased by {atkMultiplier * 100}%. New Strength: {strength}");
        }
        public void PowerUp(float speedMultiplier, float duration)
        {
            if (!isSpeedBoostActive)
            {
                speed *= speedMultiplier;
                isSpeedBoostActive = true;
                speedBoostDuration = duration;
                speedBoostTimer = 0.0f;
                UpdateSpeedText();
                Debug.Log($"Speed boosted by {speedMultiplier * 100}% for {duration} seconds.");
            }
        }

        void UpdateHealthText()
        {
            //healthTxt.text = $"Health: {Health}";
        }

        void UpdateStrengthText()
        {
            strengthTxt.text = $"Strength: {Strength}";
        }

        void UpdateSpeedText()
        {
            speedTxt.text = $"Speed: {Speed}";
        }

    }

