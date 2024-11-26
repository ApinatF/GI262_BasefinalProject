using System.Collections;
using System.Collections.Generic;
using Searching;
using UnityEngine;

public class OOPEarthQuake : Identity
{
    public override void Hit()
    {
        mapGenerator.player.inventory.AddItem("EarthQuake");
        mapGenerator.earthQuakes[positionX, positionY] = null;
        mapGenerator.mapdata[positionX, positionY] = mapGenerator.empty;
        Destroy(gameObject);
    }
}
