using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.RuleTile.TilingRuleOutput;

public class Leaf : Weapon
{
    [SerializeField] private float speed;
void Start()
{
    Damage = 30;
    speed = 4f * GetShootDirection(); //����� Transform ����ᴧ How

}
public override void Move()
{
    float newX = transform.position.x + speed * Time.fixedDeltaTime;
    float newY = transform.position.y;
    Vector2 newPosition = new Vector2(newX, newY);
    transform.position = newPosition;
    //Debug.Log($"{this.name} moves with constant speed using Transform");
}
public override void OnHitWith(Character character)
{
    if (character is Enemy)
        character.TakeDamage(this.Damage); //����� this ���� ���մա���
}

void FixedUpdate()
{
    Move();
}
}
