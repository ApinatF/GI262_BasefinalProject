using System.Collections;
using System.Collections.Generic;
using Searching;
using UnityEngine;

public class OOPWaterFallDance : Identity
{
    public override void Hit()
    {
        mapGenerator.player.inventory.AddItem("WaterFallDance");
        mapGenerator.waterFallDances[positionX, positionY] = null;
        mapGenerator.mapdata[positionX, positionY] = mapGenerator.empty;
        Destroy(gameObject);
    }
}
