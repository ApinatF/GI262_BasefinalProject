using System;
using System.Collections;
using System.Collections.Generic;
using Tree;
using UnityEngine;
using UnityEngine.UIElements;

namespace Searching
{
    public class OOPPlayer : Character
    {
        public Inventory inventory;
        public GameObject gameOverUI;
        //public SkillBook skillBook;
        public ObjectType type = ObjectType.Player;


        public void Start()
        {
            PrintInfo();
            GetRemainEnergy();

        }

        public void Update()
        {
            SetHeaith();

            if (Input.GetKeyDown(KeyCode.W))
            {
                TakeDamage(1);
                Move(Vector2.up);
            }
            if (Input.GetKeyDown(KeyCode.S))
            {
                TakeDamage(1);
                Move(Vector2.down);
            }
            if (Input.GetKeyDown(KeyCode.A))
            {
                TakeDamage(1);
                Move(Vector2.left);
            }
            if (Input.GetKeyDown(KeyCode.D))
            {
                TakeDamage(1);
                Move(Vector2.right);
            }
            if (Input.GetKeyDown(KeyCode.Space))
            {
                UseFireStorm();
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                UseEarthQuake();
            }
            if (Input.GetKeyDown(KeyCode.R))
            {
                UseWaterFallDance();
            }
        }

        public void Attack(OOPEnemy _enemy)
        {
            _enemy.TakeDamage(AttackPoint);
        }

        public void FireAttack(OOPEnemy _enemy)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                _enemy.TakeFireDamage(AttackPoint);
            }
        }



        //   Useskills

        public void UseFireStorm()
        {
            if (SkillBook.instance.fireStorm.isUnlocked && energy > 0) //inventory.numberOfItem("FireStorm") > 0 ||
            {
                //inventory.UseItem("FireStorm");
                energy -= 2;//-------------
                OOPEnemy[] enemies = SortEnemiesByRemainningEnergy2();
                List<Vector2Int> hitEnemyPositions = new List<Vector2Int>();

                /*int count = 3;
                if (count > enemies.Length)
                {
                    count = enemies.Length;
                }
                for (int i = 0; i < count; i++)
                {
                    enemies[i].TakeDamage(10);
                }*/ //โจมตีตามจำนวน

                int attackRadius = 1;

                int playerX = this.positionX;
                int playerY = this.positionY;

                foreach (Character enemy in enemies)
                {
                    if (enemy != null)
                    {
                        int distanceX = Mathf.Abs(enemy.positionX - playerX);
                        int distanceY = Mathf.Abs(enemy.positionY - playerY);

                        if (distanceX <= attackRadius && distanceY <= attackRadius)
                        {
                            if (SkillBook.instance.fireStormPlus.isUnlocked)
                            {
                                enemy.TakeFireDamage(15);
                            }
                            else
                            {
                                enemy.TakeFireDamage(10);
                            }
                            
                            hitEnemyPositions.Add(new Vector2Int(enemy.positionX, enemy.positionY));
                        }
                    }
                }

                mapGenerator.TriggerFireStorm(hitEnemyPositions.ToArray());
            }
            else
            {
                //Debug.Log("No FireStorm in inventory");
                Debug.Log("Spell Is Not Enough");
            }
        }

        public void UseWaterFallDance()
        {
            if (SkillBook.instance.waterFallDance.isUnlocked && energy > 0)
            {
                //inventory.UseItem("WaterFallDance");
                energy -= 2;
                OOPEnemy[] enemies = SortEnemiesByRemainningEnergy2();
                if (enemies.Length == 0)
                {
                    Debug.Log("No enemies found to attack.");
                    return;
                }

                // ค้นหา Enemy ที่อยู่ใกล้ที่สุด
                Character closestEnemy = null;
                float minDistance = float.MaxValue;

                int playerX = this.positionX;
                int playerY = this.positionY;

                foreach (Character enemy in enemies)
                {
                    if (enemy != null)
                    {
                        float distance = Vector2.Distance(new Vector2(playerX, playerY), new Vector2(enemy.positionX, enemy.positionY));
                        if (distance < minDistance)
                        {
                            minDistance = distance;
                            closestEnemy = enemy;
                        }
                    }
                }

                if (closestEnemy == null)
                {
                    Debug.Log("No valid enemy to attack.");
                    return;
                }

                // กำหนดทิศทางโจมตีไปยังศัตรูที่ใกล้ที่สุด
                int directionX = Mathf.Clamp(closestEnemy.positionX - playerX, -1, 1);
                int directionY = Mathf.Clamp(closestEnemy.positionY - playerY, -1, 1);

                List<Vector2Int> hitEnemyPositions = new List<Vector2Int>();
                int attackRange = 5; // ระยะไกลสุดของการโจมตี

                for (int i = 1; i <= attackRange; i++)
                {
                    int targetX = playerX + directionX * i;
                    int targetY = playerY + directionY * i;

                    // ตรวจสอบว่ามี Enemy อยู่ในตำแหน่งเป้าหมาย
                    foreach (Character enemy in enemies)
                    {
                        if (enemy != null && enemy.positionX == targetX && enemy.positionY == targetY)
                        {
                            if (SkillBook.instance.waterFallDancePlus.isUnlocked)
                            {
                                enemy.TakeFireDamage(15);
                            }
                            else
                            {
                                enemy.TakeFireDamage(10);
                            }
                            hitEnemyPositions.Add(new Vector2Int(targetX, targetY));
                        }
                    }
                }

                mapGenerator.TriggerWaterFallDance(hitEnemyPositions.ToArray());
            }
            else
            {
                //Debug.Log("No WaterFallDance in inventory");
                Debug.Log("Spell Is Not Enough");
            }

        }

        public void UseEarthQuake()
        {
            if (SkillBook.instance.earthQuake.isUnlocked && energy > 0)
            {
                //inventory.UseItem("EarthQuake");
                energy -= 2;

                OOPEnemy[] enemies = SortEnemiesByRemainningEnergy2();
                List<Vector2Int> hitEnemyPositions = new List<Vector2Int>();

                int playerX = this.positionX;
                int playerY = this.positionY;

                // ทิศทางการโจมตี: บน, ล่าง, ซ้าย, ขวา
                Vector2Int[] directions = new Vector2Int[]
                {
                    new Vector2Int(0, 1),  // บน
                    new Vector2Int(0, -1), // ล่าง
                    new Vector2Int(-1, 0), // ซ้าย
                    new Vector2Int(1, 0)   // ขวา
                };

                int attackRange = 2; // ระยะโจมตี 2 ช่องในแต่ละทิศทาง

                foreach (Vector2Int direction in directions)
                {
                    for (int i = 1; i <= attackRange; i++)
                    {
                        int targetX = playerX + direction.x * i;
                        int targetY = playerY + direction.y * i;

                        // ตรวจสอบว่ามีศัตรูในตำแหน่งเป้าหมาย
                        foreach (Character enemy in enemies)
                        {
                            if (enemy != null && enemy.positionX == targetX && enemy.positionY == targetY)
                            {
                                if (SkillBook.instance.earthQuake.isUnlocked)
                                {
                                    enemy.TakeFireDamage(15);
                                }
                                else
                                {
                                    enemy.TakeFireDamage(10);
                                }
                                hitEnemyPositions.Add(new Vector2Int(targetX, targetY));
                            }
                        }
                    }
                }

                mapGenerator.TriggerEarthQuakeEffect(hitEnemyPositions.ToArray());
            }
            else
            {
                //Debug.Log("No EarthQuake in inventory");
                Debug.Log("Spell Is Not Enough");
            }
        }

        public OOPEnemy[] SortEnemiesByRemainningEnergy1()
        {
            // do selection sort of enemy's energy
            var enemies = mapGenerator.GetEnemies();
            for (int i = 0; i < enemies.Length - 1; i++)
            {
                int minIndex = i;
                for (int j = i + 1; j < enemies.Length; j++)
                {
                    if (enemies[j].energy < enemies[minIndex].energy)
                    {
                        minIndex = j;
                    }
                }
                (enemies[i], enemies[minIndex]) = (enemies[minIndex], enemies[i]);
            }
            return enemies;
        }

        public OOPEnemy[] SortEnemiesByRemainningEnergy2()
        {
            var enemies = mapGenerator.GetEnemies();
            Array.Sort(enemies, (a, b) => a.energy.CompareTo(b.energy));
            return enemies;
        }

        protected override void CheckDead()
        {
            if (currentHealth <= 0)
            {
                Debug.Log("Player is Dead");

                
                if (gameOverUI != null)
                {
                    gameOverUI.SetActive(true);
                }
                else
                {
                    Debug.LogError("Game Over UI is not assigned!");
                }

                Destroy(gameObject); 
            }
        }
    }
}


