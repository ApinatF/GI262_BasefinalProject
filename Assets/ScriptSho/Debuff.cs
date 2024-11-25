using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace Searching
{
    public class Debuff : Identity
{
    public int debuff = 20;
    public override void Hit()
    {
            mapGenerator.player.DeBuff(debuff);
            Debug.Log("You got " + Name + " : " + debuff);
        mapGenerator.mapdata[positionX, positionY] = mapGenerator.empty;
        Destroy(gameObject);
    }
  }
}
