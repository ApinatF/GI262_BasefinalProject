using System.Collections;
using System.Collections.Generic;
using Searching;
using UnityEngine;

public class OOPconfusedFruit : Identity
{
    public override void Hit()
    {
        mapGenerator.player.inventory.AddItem("ConfusedFruit");
        mapGenerator.confusedFruits[positionX, positionY] = null;
        mapGenerator.mapdata[positionX, positionY] = mapGenerator.empty;
        Destroy(gameObject);
    }
}
