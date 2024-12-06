using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : Character
{
    private int damageHit; //ตั้งชื่อตามprob มันเป็นสูตร ชื่อแบบเดียวกันเป๊ะแต่ตัวหน้าตัวเล็ก ต้องมีตลอด
    public int DamageHit
    {
        get
        {
            return damageHit;
        }
        set
        {
            damageHit = value;
        }
    }

    

    public abstract void Behaviour(); //ทำยังไงให้เป็น Abstact -> แทรกตรงกลาง ลบ {} ใส่; ต่อท้ายเลย

}
