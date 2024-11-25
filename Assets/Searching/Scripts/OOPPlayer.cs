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
        //public SkillBook skillBook;
        


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
                Move(Vector2.up );
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
        

        protected override void CheckDead()
        {
            base.CheckDead();
            if (energy <= 0)
            {
                Debug.Log("Player is Dead");
            }
        }
        //   Useskills

        public void UseFireStorm()
        {
            if (inventory.numberOfItem("FireStorm") > 0 || SkillBook.instance.fireStorm.isUnlocked ) //inventory.numberOfItem("FireStorm") > 0 ||
            {
                inventory.UseItem("FireStorm");
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
                            enemy.TakeFireDamage(10);
                            hitEnemyPositions.Add(new Vector2Int(enemy.positionX, enemy.positionY));
                        }
                    }
                }
                
                mapGenerator.TriggerFireStorm(hitEnemyPositions.ToArray());
            }
            else
            {
                Debug.Log("No FireStorm in inventory");
            }
        }

        public void UseWaterFallDance()
        {
            if (inventory.numberOfItem("WaterFallDance") > 0 )
            {
                inventory.UseItem("WaterFallDance");
                OOPEnemy[] enemies = SortEnemiesByRemainningEnergy2();
                List<Vector2Int> hitEnemyPositions = new List<Vector2Int>();
                
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
                            enemy.TakeWaterDamage(10);
                            hitEnemyPositions.Add(new Vector2Int(enemy.positionX, enemy.positionY));
                        }
                    }
                }
                
                mapGenerator.TriggerWaterFallDance(hitEnemyPositions.ToArray());
            }
            else
            {
                Debug.Log("No WaterFallDance in inventory");
            }
        }

        public void UseEarthQuake()
        {
            if (inventory.numberOfItem("EarthQuake") > 0)
            {
                inventory.UseItem("EarthQuake");
                OOPEnemy[] enemies = SortEnemiesByRemainningEnergy2();
                List<Vector2Int> hitEnemyPositions = new List<Vector2Int>();
                
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
                            enemy.TakeDamage(10);
                            hitEnemyPositions.Add(new Vector2Int(enemy.positionX, enemy.positionY));
                        }
                    }
                }
                
                mapGenerator.TriggerEarthQuakeEffect(hitEnemyPositions.ToArray());
            }
            else
            {
                Debug.Log("No EarthQuake in inventory");
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
        
        

    }

}