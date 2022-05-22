using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using RPG_Weapon;


[CreateAssetMenu(fileName = "New Weapon Config", menuName = "Config/Weapon")]
    public class Weapon : ScriptableObject
    {
        [Range(10, 100)] public int damage;
        public DamageType damageType;
    public int weight;

   
    }
     public enum Weapons
        {
            Cleaver = DamageType.Bludgeon, 
            Broadsword = DamageType.Slasher,
            Rapier = DamageType.Piercer
        }





