using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecialCoin : GetItem
{
    float pointMultiplier = 2f;

    public override void ApplyItem(Player player)
    {
        player.GetItem(pointMultiplier);
    }
}
