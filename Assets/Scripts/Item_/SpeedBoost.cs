using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedBoost : GetItem
{
    float speedMultiplier = 2.0f;
    float duration = 5.0f;
    public override void ApplyItem(Player player)
    {
        player.GetItem(speedMultiplier, duration);
    }
}
