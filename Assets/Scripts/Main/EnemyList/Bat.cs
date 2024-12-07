using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bat : Enemy, IShootable
{

    float attackRange;
    public float AttackRange { get { return attackRange; } set { attackRange = value; } }
    public Player player;

    [field: SerializeField] //อยากโชว์ในUnity ใช้แบบนี้กับ ตัวแปร public แต่เขียนเต็มยศแค่ [SerializeField] ได้
    GameObject bullet;
    public GameObject Bullet { get { return bullet; } set { bullet = value; } }


    [field: SerializeField] //[SerializeField] นิยมใช้กับ private เท่านั้น
    Transform bulletSpawnPoint;
    public Transform BulletSpawnPoint { get { return bulletSpawnPoint; } set { bulletSpawnPoint = value; } } // พรอบพอตี้แบบเต็มยศ

    [field: SerializeField]
    public float ReloadTime { get; set; } // พรอบพอตี้แบบย่อ ออโต้้ อันนี้ต้อง [field: SerializeField] 
    [field: SerializeField]
    public float WaitTime { get; set; }


    private void FixedUpdate() //มี Start ที่ลูกของแม่ไม่แสดงละ แม่เสียสละให้ลูก
    {
        WaitTime += Time.fixedDeltaTime;
        Behaviour();
    }

    public override void Behaviour() //ต้องมีเพราะ Enemy อยากได้ไม่มีระเบิด ตรง abstract เป็น override แทน
    {
        Vector2 direction = player.transform.position - transform.position;
        
        float distance = direction.magnitude;
        {
            Shoot();
        }
    }

    public void Shoot()
    {

        if (WaitTime >= ReloadTime)
        {
            GameObject obj = Instantiate(Bullet, BulletSpawnPoint.position, Quaternion.identity); //อันนี้คือหิน
            Fruit fruit = obj.GetComponent<Fruit>(); // obj ก็อปสคริปของที่ค้างคาว
            fruit.Init(20, this); //this คือตัวค้างคาว
            WaitTime = 0;

        }
    }
    void Awake()
    {
        WaitTime = 0f;
        ReloadTime = 5f;
        AttackRange = 6;
        DamageHit = 30;

    }
    void Start()
    {
        Init(100); //เลือดค้างคาว
        healthBar.SetMaxHealth(100);
        player = GameObject.FindObjectOfType<Player>();

    }
}
