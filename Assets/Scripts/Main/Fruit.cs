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
        rb2d.AddForce(force); //ไม่ขว้าง
    }
    public override void OnHitWith(Character character) //หินชนกับ...
    {
        if (character is Player) //เช็คว่าใช่ Player ไหม จะมีสคริป Player เกาะอยู่
        { character.TakeDamage(this.Damage); }
    }

}
