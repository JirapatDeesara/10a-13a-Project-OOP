using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class Weapon : MonoBehaviour
{
    protected string owner;
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

    public abstract void OnHitWith(Character character); // ตัวเอียงเป็นabstract

    public abstract void Move(); // ตัวเอียงเป็นabstract
    public void Init(int newDamage, IShootable newOwner)
    {
        Damage = newDamage;
        shooter = newOwner;
    }

    private void OnTriggerEnter2D(Collider2D other) //อาวุธตีโดน
    {
        OnHitWith(other.GetComponent<Character>());
        Destroy(this.gameObject, 4f); // ตัว...f คือหน่วงเวลาทำลาย

    }

    public int GetShootDirection() //ให้รู้ว่าหันหน้าไปทางไหน
    {
        float shootDir = shooter.BulletSpawnPoint.position.x - shooter.BulletSpawnPoint.parent.position.x;
        if (shootDir > 0)
        { return 1; }//ยิงด้านขวา
        else return -1; //ยิงด้านซ้าย
    }

}
