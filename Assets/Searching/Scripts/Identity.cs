using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum ObjectType
{
    Player,
    Enemy,
    Buff,
    Obstacle
}

namespace Searching
{

    public class Identity : MonoBehaviour
    {
        [Header("Identity")]
        public string Name;
        public int positionX;
        public int positionY;

        public OOPMapGenerator mapGenerator;

        public void PrintInfo()
        {
            Debug.Log("tell me your " + Name);
        }

        public virtual void Hit()
        {

        }
    }
}