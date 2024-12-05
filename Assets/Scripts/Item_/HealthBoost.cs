using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : GetItem

{
    
    int healthIncrease;
    private void Start()
    {
        healthIncrease = 20;
    }
    public override void ApplyItem(Player player)
    {
        player.GetItem(healthIncrease);
    }
}
