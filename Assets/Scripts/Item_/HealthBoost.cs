using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBoost : GetItem

{

    int foundCat;
    private void Start()
    {
        foundCat =+ 1;
    }
    public override void ApplyItem(Player player)
    {
        player.GetItem(foundCat);
    }
}
