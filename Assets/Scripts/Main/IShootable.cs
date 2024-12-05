using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IShootable // interface ตัวพิมพ์เล้ก ไม่สืบทอดใครทั้งนั้น และต้องเป็น public
{
    GameObject Bullet { get; set; } //[SerializeField] ใช้กับ private เท่านั้น
    Transform BulletSpawnPoint { get; set; } //ตัวแปรใน interface เป็น public อยู่แล้วไม่ต้องใส่ก็ได้ ตัวแปรต้องเหมือนกัน public ตัวหน้าพิมพ์ใหญ่

    public float ReloadTime { get; set; }
    public float WaitTime { get; set; }

    void Shoot();

}
