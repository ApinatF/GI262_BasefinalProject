using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UIElements;
using UnityEngine.XR;
using static UnityEditor.PlayerSettings;
using static UnityEngine.EventSystems.EventTrigger;

namespace Searching
{
    public class Character : Identity
    { 
        [Header("Character")]
        public float maxHealth;
        public float currentHealth;
        public int energy;
        public int AttackPoint;
        public int extraMove = 0;
        protected bool isAlive;
        protected bool isFreeze;
        


        protected void Awake()
        {
            currentHealth = maxHealth;
        }

        protected void GetRemainEnergy()
        {
            Debug.Log(Name + " : " + energy);
        }

        public virtual void Move(Vector2 direction)
        {
            if (isFreeze == true)
            {
                GetComponent<SpriteRenderer>().color = Color.white;
                isFreeze = false;
                return;
            }

            if (this is OOPPlayer)
            {
                int totalMoves = 1 + extraMove;
            for (int moveCount = 0; moveCount < totalMoves; moveCount++)
            {
                int toX = (int)(positionX + direction.x);
                int toY = (int)(positionY + direction.y);
                
                int fromX = positionX;
                int fromY = positionY;

                if (HasPlacement(toX, toY))
                {
                    if (IsDemonWalls(toX, toY))
                    {
                        mapGenerator.walls[toX, toY].Hit();
                    }
                    else if (IsPotion(toX, toY))
                    {
                        mapGenerator.potions[toX, toY].Hit();
                        positionX = toX;
                        positionY = toY;
                        transform.position = new Vector3(positionX, positionY, 0);
                    }
                    else if (IsPotionBonus(toX, toY))
                    {
                        mapGenerator.potions[toX, toY].Hit();
                        positionX = toX;
                        positionY = toY;
                        transform.position = new Vector3(positionX, positionY, 0);
                    }
                    else if (IsExit(toX, toY))
                    {
                        mapGenerator.Exit.Hit();
                        positionX = toX;
                        positionY = toY;
                        transform.position = new Vector3(positionX, positionY, 0);
                    }
                    else if (IsKey(toX, toY))
                    {
                        mapGenerator.keys[toX, toY].Hit();
                        positionX = toX;
                        positionY = toY;
                        transform.position = new Vector3(positionX, positionY, 0);
                    }
                    else if (IsFireStorm(toX, toY))
                    {
                        mapGenerator.fireStorms[toX, toY].Hit();
                        positionX = toX;
                        positionY = toY;
                        transform.position = new Vector3(positionX, positionY, 0);
                    }
                    else if (IsEarthQuake(toX, toY))
                    {
                        mapGenerator.earthQuakes[toX, toY].Hit();
                        positionX = toX;
                        positionY = toY;
                        transform.position = new Vector3(positionX, positionY, 0);
                    }
                    else if (IsWaterFallDance(toX, toY))
                    {
                        mapGenerator.waterFallDances[toX, toY].Hit();
                        positionX = toX;
                        positionY = toY;
                        transform.position = new Vector3(positionX, positionY, 0);
                    }
                    else if (this is OOPPlayer && IsApplebuff(toX, toY))
                    {
                        mapGenerator.buffs[toX, toY].Hit();
                        positionX = toX;
                        positionY = toY;
                        transform.position = new Vector3(positionX, positionY, 0);
                    }
                    else if (this is OOPPlayer && IsDeApplebuff(toX,toY))
                    {
                            mapGenerator.debuffs[toX, toY].Hit();
                            positionX = toX;
                            positionY = toY;
                            transform.position = new Vector3(positionX, positionY, 0);
                        }
                        else if (IsEnemy(toX, toY))
                    {
                        mapGenerator.enemies[toX, toY].Hit();
                    }
                }
                else
                {
                    positionX = toX;
                    positionY = toY;
                    transform.position = new Vector3(positionX, positionY, 0);
                    //TakeDamage(1); // เดินชนวัตถุที่ไม่สามารถเดินผ่านได้ จะเสียพลังชีวิต
                }

                if (this is OOPPlayer)
                {
                    if (fromX != positionX || fromY != positionY)
                    {
                        mapGenerator.mapdata[fromX, fromY] = mapGenerator.empty;
                        mapGenerator.mapdata[positionX, positionY] = mapGenerator.playerBlock;
                        mapGenerator.MoveEnemies();
                    }
                }
            }
            
                
                
            }
        }
        // hasPlacement คืนค่า true ถ้ามีการวางอะไรไว้บน map ที่ตำแหน่ง x,y
        public bool HasPlacement(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData != mapGenerator.empty;
        }
        public bool IsDemonWalls(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData == mapGenerator.demonWall;
        }
        public bool IsPotion(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData == mapGenerator.potion;
        }
        public bool IsPotionBonus(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData == mapGenerator.potion;
        }
        public bool IsFireStorm(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData == mapGenerator.fireStorm;
        }
        public bool IsEarthQuake(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData == mapGenerator.earthQuake;
        }
        public bool IsWaterFallDance(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData == mapGenerator.waterFallDance;
        }
        public bool IsApplebuff(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData == mapGenerator.Applebuff;
        }
        public bool IsDeApplebuff(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData == mapGenerator.AppleDebuffs;
        }
        public bool IsKey(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData == mapGenerator.key;
        }
        public bool IsEnemy(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData == mapGenerator.enemy;
        }
        public bool IsExit(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            return mapData == mapGenerator.exit;
        }

        /*public bool IsEnemyFacedWall(int x, int y)
        {
            int mapData = mapGenerator.GetMapData(x, y);
            
        }*/

        public virtual void TakeDamage(int Damage) //energy -> currentHeaith
        {
            currentHealth -= Damage;
            Debug.Log(Name + " Take Normal Attack : " + currentHealth);
            CheckDead();
        }
        
        public virtual void TakeEnergy(int _Energy) //energy -> currentHeaith
        {
            energy -= _Energy;
            Debug.Log(Name + " Take Normal Attack : " + energy);
            //CheckDead();
        }
        public virtual void TakeDamage(int Damage, bool freeze)
        {
            energy -= Damage;
            isFreeze = freeze;
            GetComponent<SpriteRenderer>().color = Color.blue;
            Debug.Log(Name + " Current Energy : " + energy);
            Debug.Log("you is Freeze");
            CheckDead();
        }

        public virtual void TakeFireDamage(int FDamage)
        {
                currentHealth -= FDamage;
                Debug.Log(Name + " Take Fire Damage : " + currentHealth);
                CheckDead();
        }
        
        public virtual void TakeEarthDamage(int EDamage)
        {
                currentHealth -= EDamage;
                Debug.Log(Name + " Take Earth Damage : " + currentHealth);
                CheckDead();
        }
        
        public virtual void TakeWaterDamage(int WDamage)
        {
                currentHealth -= WDamage;
                Debug.Log(Name + " Take Water Damage : " + currentHealth);
                CheckDead();
        }

        

        public void Heal(int healPoint)
        {
            // energy += healPoint;
            // Debug.Log("Current Energy : " + energy);
            // เราสามารถเรียกใช้ฟังก์ชัน Heal โดยกำหนดให้ Bonuse = false ได้ เพื่อที่จะให้ logic ในการ heal อยู่ที่ฟังก์ชัน Heal อันเดียวและไม่ต้องเขียนซ้ำ
            Heal(healPoint, false);
        }

        public void Heal(int healPoint, bool Bonuse)
        {
            currentHealth += healPoint * (Bonuse ? 2 : 1);
            Debug.Log("Current Energy : " + currentHealth);
        }
        
        public void BuffMovement(int additionalMoves)
        {
            /*extraMove += additionalMoves;
            Debug.Log("Movement buffed! Extra move: " + extraMove);
            Debug.Log(Name + " received movement buff! Extra move: " + extraMove);*/
            
            if (this is OOPPlayer)
            {
                extraMove += additionalMoves;
                Debug.Log("Movement buffed! Extra move: " + extraMove);
            }
            else
            {
                Debug.Log("BuffMovement called on non-Player character.");
            }
        }

        public void DeBuff(int dePoint)
        {
            currentHealth -= dePoint;
            Debug.Log("Current Energy : " + currentHealth);
        }

        protected virtual void CheckDead()
        {
            if (currentHealth <= 0)
            {
                Destroy(gameObject);
            }
        }
        
        protected void SetHeaith()
        {
            if (currentHealth > maxHealth)
            {
                currentHealth = maxHealth;
            }
        }

        

        
    }
}