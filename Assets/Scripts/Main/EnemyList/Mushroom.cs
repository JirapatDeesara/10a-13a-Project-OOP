using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : Enemy
{
    [SerializeField] private Vector2 velocity; 
    [SerializeField] private Transform[] movePoints; 
    private void Start() //�� Start ����١�ͧ�������ʴ��� ��������������١
    {
        rb = GetComponent<Rigidbody2D>(); 
       
    }
    private void Awake() //�� Start ����١�ͧ�������ʴ��� ��������������١
    {
        
        Init(10);
        DamageHit = 10;
        healthBar.SetMaxHealth(100);

    }

    private void FixedUpdate() //�������Ѻ����͹�������
    {
        Behaviour();
    }

    public override void Behaviour() //��ͧ������ Enemy ��ҡ����������Դ �ç abstract �� override ᷹
    {
        
        rb.MovePosition(rb.position + velocity * Time.fixedDeltaTime); //��������Թ�����ش
        if (rb.position.x < movePoints[0].position.x && velocity.x < 0) //����������ѧ && ���Թ��ҹ����
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
