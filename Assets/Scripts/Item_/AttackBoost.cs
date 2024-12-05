using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackBoost : GetItem
{
    float atkMultiplier = 2f;
    public override void ApplyItem(Player player)
    {
        player.GetItem(atkMultiplier);
    }
}
