using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostCat : GetItem
{
    int foundcat;
    private void Start()
    {
        foundcat =+ 1;
    }
    public override void ApplyItem(Player player)
    {
        player.GetItem(foundcat);
    }
}
