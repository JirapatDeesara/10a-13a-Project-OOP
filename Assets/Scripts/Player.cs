using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;


    public class Player : Character , IShootable
    {
        public Player player;

        protected int health = 0; // ตั้งเป็น protected เพื่อให้เข้าถึงได้ในคลาสลูก
        public int Health => health;

         protected int cat = 0; // ตั้งเป็น protected เพื่อให้เข้าถึงได้ในคลาสลูก
         public int Cat => cat;
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




    [SerializeField] TextMeshProUGUI healthTxt, strengthTxt, speedTxt, catDiscoverTxt;
    //private object catDiscoverTxt;

    void Start()
        {
        Init(200);
        ReloadTime = 1.0f;
        WaitTime = 0f;
        //currentHealth = health;
        //healthBar.SetMaxHealth(health);
        originalSpeed = speed;
        //UpdateHealthText();
        UpdateSpeedText();
        UpdateStrengthText();
        UpdateCatDiscoverText();
        }

        void Update()
        {
        Shoot();
        UpdateSpeedBoostTimer();
        //UpdateHealthText();
        /*Checking HP Bar damage by pressing Spacebar
            if (Input.GetKeyDown(KeyCode.Space))
            {
            TakeDamage(20);
            }
        */
    }

    // Method for taking Damage to Update HP UI
    /*public void TakeDamage(int damage)
    { 
        currentHealth -= damage;
        healthBar.UpdateHealthBar(currentHealth);
    }// End TakeDamage*/
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

    public void GetItem(int foundCat)
    {
        cat += foundCat;
        Debug.Log($"Found {foundCat}. New Discover: {cat}");
        Debug.Log($"Cat found {cat} out of 6");
        UpdateCatDiscoverText();
    }
    /*public void GetItem(int healthIncrease)
        {
            health += healthIncrease;
            Debug.Log($"Found cat {healthIncrease}. New health: {health}");
            UpdateHealthText();
        } */
    

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

    /*
        void UpdateHealthText()
        {
            healthTxt.text = $"Health: {Health}";
        } 
       */

        void UpdateStrengthText()
        {
            strengthTxt.text = $"Strength: {Strength}";
        }

        void UpdateSpeedText()
        {
            speedTxt.text = $"Speed: {Speed}";
    }
    void UpdateCatDiscoverText()
    {
        if (cat < 6)
        { catDiscoverTxt.text = $"Cat found {cat}/6"; }

        if (cat >= 6)
        {
            catDiscoverTxt.text = $"YOU WIN!!!!";
            Debug.Log($"You found all {cat}");
            Debug.Log("You win!!!!");
        }

    }

    //เว้น


    [field: SerializeField] //อยากโชว์ในUnity ใช้แบบนี้กับ ตัวแปร public แต่เขียนเต็มยศแค่ [SerializeField] ได้
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }


    [field: SerializeField] //[SerializeField] นิยมใช้กับ private เท่านั้น
    Transform bulletSpawnPoint;
    public Transform BulletSpawnPoint { get { return bulletSpawnPoint; } set { bulletSpawnPoint = value; } } // พรอบพอตี้แบบเต็มยศ

    [field: SerializeField]
    public float ReloadTime { get; set; } // พรอบพอตี้แบบย่อ ออโต้้ อันนี้ต้อง [field: SerializeField] 
    [field: SerializeField]
    public float WaitTime { get; set; }

    public void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && WaitTime >= ReloadTime)  //ไม่รู้ปุ่มชื่อไร ไปหาดูใน Unity ใช้GetMouseButtonDown ถึงจะใช้รหัสเมาส์
        {
            GameObject obj = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity);
            Leaf leaf = obj.GetComponent<Leaf>();
            leaf.Init(10, this);
            WaitTime = 0;
        }
    }
    
    private void FixedUpdate()
    {
        WaitTime += Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Enemy enemy = collision.gameObject.GetComponent<Enemy>(); 
        if (enemy != null)
        {
            OnHitWith(enemy);
            Debug.Log($"{this.name} hit with {enemy.name} dealing {enemy.DamageHit} Damage.");
        }
    }

    public void OnHitWith(Enemy enemy)
    {
        TakeDamage(enemy.DamageHit);
    }
}
