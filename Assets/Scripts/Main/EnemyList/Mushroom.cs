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
        Init(10);
        DamageHit = 10;
        Debug.Log(Health);

    }

    private void FixedUpdate() //�������Ѻ����͹�������
    {
        Behaviour();
    }

    public override void Behaviour() //��ͧ������ Enemy ��ҡ����������Դ �ç abstract �� override ᷹
    {
        //rb.MovePosition(movePoints[0].position); //�����������һ
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
