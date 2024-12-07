using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private int health; //ตั้งชื่อตามprob มันเป็นสูตร ชื่อแบบเดียวกันเป๊ะแต่ตัวหน้าตัวเล็ก [SerializeField]=ขึ้นให้ดูได้
    public HealthBar healthBar;
    public int currentHealth;
    public int Health
    {
        get
        {
            return health;
        }
        set
        {
            health = value;
        }
    }
   
    public Animator anim; //+ คือ public
    public Rigidbody2D rb;

    public bool IsDead()
    {
        if (health <= 0)
        {
            Destroy(this.gameObject);
            return true;
        }
        else return false;
    }

    public void TakeDamage(int damage)
    {
        Health -= damage;
        healthBar.UpdateHealthBar(Health); //SetMaxHealth ไว้เซ็ตตอนเริ่ม อันนี้คือโดนดาเมจต้องอัพ
        Debug.Log($"{this.name} took {damage} damage; Remaining Health: {this.Health}");
        IsDead();
    }



    public virtual void Init(int newHealth)
    {
        Health = newHealth;
        healthBar.SetMaxHealth(newHealth);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
}
