
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Searching
{
    public class OOPItemBuff : Identity
    {
        public int buffmove = 1;
        public override void Hit()
        {
            mapGenerator.player.BuffMovement(buffmove);
            Debug.Log("You got " + Name + " Buff : Move +" + buffmove);
            mapGenerator.mapdata[positionX, positionY] = mapGenerator.empty;
            Destroy(gameObject);
        }
    }
}
