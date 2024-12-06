using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruit : Weapon
{
    private Rigidbody2D rb2d;
    private Vector2 force;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Damage = 10;
        Move();
    }
    public override void Move()
    {
        rb2d.AddForce(force); //�����ҧ
    }
    public override void OnHitWith(Character character) //�Թ���Ѻ...
    {
        if (character is Player) //������� Player ��� ����ʤ�Ի Player �������
        { character.TakeDamage(this.Damage); }
    }

}
