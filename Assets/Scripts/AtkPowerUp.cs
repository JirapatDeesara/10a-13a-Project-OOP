using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AtkPowerUp : PowerUp
{
    float atkMultiplier = 2f;
    public override void ApplyPowerUp(Player player)
    {
       player.PowerUp(atkMultiplier);
    }

}// End AtkPowerUp
