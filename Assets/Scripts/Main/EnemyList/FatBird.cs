using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBird : Enemy
{
    private void Start() //มี Start ที่ลูกของแม่ไม่แสดงละ แม่เสียสละให้ลูก
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Awake() //มี Start ที่ลูกของแม่ไม่แสดงละ แม่เสียสละให้ลูก
    {

        Init(50);
        DamageHit = 5;
        healthBar.SetMaxHealth(100);

    }
    public override void Behaviour() 
    {
        if (currentHealth <= 30)
        {
            currentHealth = +10;
        }

    }
}
