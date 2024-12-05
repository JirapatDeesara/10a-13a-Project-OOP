using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;


    public class Player : Character
    {
        int health = 100;
        int cat = 0;
        /*public int Health => health; //read only property
        public int currentHealth;
        public HealthBar healthBar;*/
 
        float strength = 10.0f;
        public float Strength => strength;

        float speed = 5.0f;
        public float Speed => speed;

        float originalSpeed;
        float speedBoostDuration = 0.0f;  // How long the boost lasts
        float speedBoostTimer = 0.0f; // to track how much time has passed since the speed boost was activated.
        bool isSpeedBoostActive = false; // tracks whether the speed boost is currently active or not.




        [SerializeField] TextMeshProUGUI healthTxt, strengthTxt, speedTxt;
    private object catDiscoverTxt;

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

        healthBar.UpdateHealthBar(currentHealth);
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

        public void GetItem(int healthIncrease)
        {
            health += healthIncrease;
            Debug.Log($"Health increased by {healthIncrease}. New health: {health}");
            UpdateHealthText();
        }
    /*public void GetItem(int foundCat)
    {
        cat += foundCat;
        Debug.Log($"Found {foundCat}. New Discover: {cat}");
        UpdateCatDiscoverText();
    }*/

    public void GetItem(float atkMultiplier)
        {
            strength *= atkMultiplier;
            UpdateStrengthText();
            Debug.Log($"Strength  increased by {atkMultiplier * 100}%. New Strength: {strength}");
        }
        public void GetItem(float speedMultiplier, float duration)
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
            healthTxt.text = $"Health: {Health}";
        }

        void UpdateStrengthText()
        {
            strengthTxt.text = $"Strength: {Strength}";
        }

        void UpdateSpeedText()
        {
            speedTxt.text = $"Speed: {Speed}";
        }
    /*void UpdateCatDiscoverText()
    {
        catDiscoverTxt.text = $"Speed: {Speed}";
    }*/
    //���
    public Player player;

    [field: SerializeField] //��ҡ����Unity ��Ẻ���Ѻ ����� public ����¹������� [SerializeField] ��
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }


    [field: SerializeField] //[SerializeField] ������Ѻ private ��ҹ��
    Transform bulletSpawnPoint;
    public Transform BulletSpawnPoint { get { return bulletSpawnPoint; } set { bulletSpawnPoint = value; } } // ��ͺ�͵��Ẻ�����

    [field: SerializeField]
    public float ReloadTime { get; set; } // ��ͺ�͵��Ẻ��� ����� �ѹ����ͧ [field: SerializeField] 
    [field: SerializeField]
    public float WaitTime { get; set; }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)  //��������������� ��Ҵ�� Unity ��GetMouseButtonDown �֧�������������
        {
            GameObject obj = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
            Banana banana = obj.GetComponent<Banana>();
            banana.Init(10, this);
            WaitTime = 0;

        }
    }




}

