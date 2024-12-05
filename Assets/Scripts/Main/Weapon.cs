using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    [SerializeField] private int damage;
    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }
    public IShootable shooter;

    public abstract void OnHitWith(Character character); // ������§��abstract

    public abstract void Move(); // ������§��abstract
    public void Init(int newDamage, IShootable newOwner)
    {
        Damage = newDamage;
        shooter = newOwner;
    }

    private void OnTriggerEnter2D(Collider2D other) //���ظ��ⴹ
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(this.gameObject, 5f); // ���...f ���˹�ǧ���ҷ����

    }

    public int GetShootDirection() //����������ѹ˹��价ҧ�˹
    {
        float shootDir = shooter.BulletSpawnPoint.position.x - shooter.BulletSpawnPoint.parent.position.x;
        if (shootDir > 0)
        { return 1; }//�ԧ��ҹ���
        else return -1; //�ԧ��ҹ����
    }




}