using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    [SerializeField] private Vector2 velocity; 
    [SerializeField] private Transform[] movePoints; 
    private void Start() //มี Start ที่ลูกของแม่ไม่แสดงละ แม่เสียสละให้ลูก
    {
        rb = GetComponent<Rigidbody2D>(); 
        Init(10);
        DamageHit = 10;
        Debug.Log(Health);

    }

    private void FixedUpdate() //ไว้สำหรับเคลื่อนที่สวยๆ
    {
        Behaviour();
    }

    public override void Behaviour() //ต้องมีเพราะ Enemy อยากได้ไม่มีระเบิด ตรง abstract เป็น override แทน
    {
        //rb.MovePosition(movePoints[0].position); //ถ้ามีแค่นี้จะวาป
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); //มีแค่นี้จะเดินไม่หยุด
        if (rb.position.x < movePoints[0].position.x && velocity.x < 0) //ถ้าไม่มีหลัง && จะเดินด้านเดียว
        {
            Flip();
        }
        else if (rb.position.x >= movePoints[1].position.x && velocity.x > 0)
        {
            Flip();
        }

    }

    void Flip()
    {
        velocity.x *= -1;

        Vector2 charScale = transform.localScale;
        charScale.x *= -1;
        transform.localScale = charScale;

    }
}
