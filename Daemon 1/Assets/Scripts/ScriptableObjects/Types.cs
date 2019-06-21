using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Types
{
    public enum 
  Stats{
    Strength,
    Magic,
    Dexterity,
    Vitality,
    Damage,
    ChanceToHit,
    ArmorClass,
    ResistMagic,
    ResistFire,
    ResistLightning,
    AttackSpeed,
    LifeSteal
  }

  public enum 
  Requeriments{
    Strength,
    Magic,
    Dexterity
  }

  public enum 
  ItemType{
    Weapon,
    Armor,
    Consumable,
    Jewel,
    Gold
  }

  public enum 
  WeaponType{
    Sword,
    Staff,
    Mace,
    Bow,
    Axe
  }

  public enum 
  ArmorType{
    Light,
    Medium,
    Heavy
  }

  public enum 
  JewelType{
    Ring,
    Amulet
  }

  public enum 
  ConsumableType{
    Potion,
    Book,
    Scroll
  }

  public enum 
  Rarity{
    Comun,
    Rare,
    SuperRare,
    UltraRare
  }
}
