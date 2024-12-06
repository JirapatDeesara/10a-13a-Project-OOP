using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FatBird : Enemy
{
    private void Start() //�� Start ����١�ͧ�������ʴ��� ��������������١
    {
        rb = GetComponent<Rigidbody2D>();

    }
    private void Awake() //�� Start ����١�ͧ�������ʴ��� ��������������١
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
