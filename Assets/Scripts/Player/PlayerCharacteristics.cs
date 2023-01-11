using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerCharacteristics : MonoBehaviour
{
    private int _maxHealth;
    private int _currentHealth;
    private int _healthRegeneration;
    private int _meleeDamage;
    private int _meleeDamageModifier;
    private int _rangedDamageModifier;
    private int _magicDamageModifier;
    private int _criticalHitChance;
    private int _criticalDamageMultiplier;
    private int _speed;
    private int _luck;
    private int _sciencePointsPerTurn;
    private int _numberOfSciencePoints;
    private int _usefulMaterialsPerTurn;
    private int _numberOfUsefulMaterials;
    private int[] _uniqueAbility;

    private PlayerData data;
    private string _savePath;

    void Awake()
    {
        _savePath = Application.dataPath + "/Resources/Raw/InputActions/StreamingAssets";
        LoadData();
    }

    public void LoadData()
    {
        string path = _savePath + "/SavedCharacteristics.json";

        if (!File.Exists(path))
        {
            path = _savePath + "/StartCharacteristics.json";
        }

        data = JsonUtility.FromJson<PlayerData>(File.ReadAllText(path));

        _maxHealth = data.MaxHealth;
        _currentHealth = data.CurrentHealth;
        _healthRegeneration = data.HealthRegeneration;
        _meleeDamage = data.MeleeDamage;
        _meleeDamageModifier = data.MeleeDamageModifier;
        _rangedDamageModifier = data.RangedDamageModifier;
        _magicDamageModifier = data.MagicDamageModifier;
        _criticalHitChance = data.CriticalHitChance;
        _criticalDamageMultiplier = data.CriticalDamageMultiplier;
        _speed = data.Speed;
        _luck = data.Luck;
        _sciencePointsPerTurn = data.SciencePointsPerTurn;
        _numberOfSciencePoints = data.NumberOfSciencePoints;
        _usefulMaterialsPerTurn = data.UsefulMaterialsPerTurn;
        _numberOfUsefulMaterials = data.NumberOfUsefulMaterials;
        _uniqueAbility = data.UniqueAbility;
    }

    public void SaveData()
    {
        data.MaxHealth = _maxHealth;
        data.CurrentHealth = _currentHealth;
        data.HealthRegeneration = _healthRegeneration;
        data.MeleeDamage = _meleeDamage;
        data.MeleeDamageModifier = _meleeDamageModifier;
        data.RangedDamageModifier = _rangedDamageModifier;
        data.MagicDamageModifier = _magicDamageModifier;
        data.CriticalHitChance = _criticalHitChance;
        data.CriticalDamageMultiplier = _criticalDamageMultiplier;
        data.Speed = _speed;
        data.Luck = _luck;
        data.SciencePointsPerTurn = _sciencePointsPerTurn;
        data.NumberOfSciencePoints = _numberOfSciencePoints;
        data.UsefulMaterialsPerTurn = _usefulMaterialsPerTurn;
        data.NumberOfUsefulMaterials = _numberOfUsefulMaterials;
        data.UniqueAbility = _uniqueAbility;

        File.WriteAllText(_savePath + "/SavedCharacteristics.json", JsonUtility.ToJson(data));
    }
    
    public int GetMaxHealth()
    {
        return _maxHealth;
    }

    public void SetMaxHealth(int value)
    {
        _maxHealth = value;
    }

    public int GetCurrentHealth()
    {
        return _currentHealth;
    }

    public void SetCurrentHealth(int value)
    {
        _currentHealth += value;
    }
    
    public int GetHealthRegeneration()
    {
        return _healthRegeneration;
    }

    public void SetHealthRegeneration(int value)
    {
        _healthRegeneration = value;
    }
    
    public int GetMeleeDamage()
    {
        return _meleeDamage;
    }

    public void SetMeleeDamage(int value)
    {
        _meleeDamage = value;
    }
    
    public int GetMeleeDamageModifier()
    {
        return _meleeDamageModifier;
    }

    public void SetMeleeDamageModifier(int value)
    {
        _meleeDamageModifier = value;
    }
    
    public int GetRangedDamageModifier()
    {
        return _rangedDamageModifier;
    }

    public void SetRangedDamageModifier(int value)
    {
        _rangedDamageModifier = value;
    }
    
    public int GetMagicDamageModifier()
    {
        return _magicDamageModifier;
    }

    public void SetMagicDamageModifier(int value)
    {
        _magicDamageModifier = value;
    }
    
    public int GetCriticalHitChance()
    {
        return _criticalHitChance;
    }

    public void SetCriticalHitChance(int value)
    {
        _criticalHitChance = value;
    }
    
    public int GetCriticalDamageMultiplier()
    {
        return _criticalDamageMultiplier;
    }

    public void SetCriticalDamageMultiplier(int value)
    {
        _criticalDamageMultiplier = value;
    }
    
    public int GetSpeed()
    {
        return _speed;
    }

    public void SetSpeed(int value)
    {
        _speed = value;
    }

    public int GetLuck()
    {
        return _luck;
    }

    public void SetLuck(int value)
    {
        _luck = value;
    }
    
    public int GetSciencePointsPerTurn()
    {
        return _sciencePointsPerTurn;
    }

    public void SetSciencePointsPerTurn(int value)
    {
        _sciencePointsPerTurn = value;
    }
    
    public int GetNumberOfSciencePoints()
    {
        return _numberOfSciencePoints;
    }

    public void SetNumberOfSciencePoints(int value)
    {
        _numberOfSciencePoints = value;
    }
    
    public int GetUsefulMaterialsPerTurn()
    {
        return _usefulMaterialsPerTurn;
    }

    public void SetUsefulMaterialsPerTurn(int value)
    {
        _usefulMaterialsPerTurn = value;
    }

    public int GetNumberOfUsefulMaterials()
    {
        return _numberOfUsefulMaterials;
    }

    public void SetNumberOfUsefulMaterials(int value)
    {
        _numberOfUsefulMaterials = value;
    }
    
    public int[] GetUniqueAbility()
    {
        return _uniqueAbility;
    }

    public void SetUniqueAbility(int[] value)
    {
        _uniqueAbility = value;
    }
}
