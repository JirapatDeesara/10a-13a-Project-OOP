using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Acid : Weapon
{
    private Rigidbody2D rb2d;
    private Vector2 force;


    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        Damage = 20;
        force = new Vector2(GetShootDirection() * 5, 15); //��Ǻ͡����ԧ�������͢��
        Move();
    }
    public override void Move()
    {
        rb2d.AddForce(force, ForceMode2D.Impulse); //���ҧ
    }
    public override void OnHitWith(Character character) //�Թ���Ѻ...
    {
        if (character is Player) //������� Player ��� ����ʤ�Ի Player �������
        { character.TakeDamage(this.Damage); }
    }

}
