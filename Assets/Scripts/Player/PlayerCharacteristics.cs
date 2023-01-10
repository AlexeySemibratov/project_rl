using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerCharacteristics : MonoBehaviour
{
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public int HealthRegeneration { get; set; }
    public int MeleeDamage { get; set; }
    public int MeleeDamageModifier { get; set; }
    public int RangedDamageModifier { get; set; }
    public int MagicDamageModifier { get; set; }
    public int CriticalHitChance { get; set; }
    public int CriticalDamageMultiplier { get; set; }
    public int Speed { get; set; }
    public int Luck { get; set; }
    public int SciencePointsPerTurn { get; set; }
    public int NumberOfSciencePoints { get; set; }
    public int UsefulMaterialsPerTurn { get; set; }
    public int NumberOfUsefulMaterials { get; set; }
    public int[] UniqueAbility { get; set; }

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

        MaxHealth = data.MaxHealth;
        CurrentHealth = data.CurrentHealth;
        HealthRegeneration = data.HealthRegeneration;
        MeleeDamage = data.MeleeDamage;
        MeleeDamageModifier = data.MeleeDamageModifier;
        RangedDamageModifier = data.RangedDamageModifier;
        MagicDamageModifier = data.MagicDamageModifier;
        CriticalHitChance = data.CriticalHitChance;
        CriticalDamageMultiplier = data.CriticalDamageMultiplier;
        Speed = data.Speed;
        Luck = data.Luck;
        SciencePointsPerTurn = data.SciencePointsPerTurn;
        NumberOfSciencePoints = data.NumberOfSciencePoints;
        UsefulMaterialsPerTurn = data.UsefulMaterialsPerTurn;
        NumberOfUsefulMaterials = data.NumberOfUsefulMaterials;
        UniqueAbility = data.UniqueAbility;
    }

    public void SaveData()
    {
        data.MaxHealth = MaxHealth;
        data.CurrentHealth = CurrentHealth;
        data.HealthRegeneration = HealthRegeneration;
        data.MeleeDamage = MeleeDamage;
        data.MeleeDamageModifier = MeleeDamageModifier;
        data.RangedDamageModifier = RangedDamageModifier;
        data.MagicDamageModifier = MagicDamageModifier;
        data.CriticalHitChance = CriticalHitChance;
        data.CriticalDamageMultiplier = CriticalDamageMultiplier;
        data.Speed = Speed;
        data.Luck = Luck;
        data.SciencePointsPerTurn = SciencePointsPerTurn;
        data.NumberOfSciencePoints = NumberOfSciencePoints;
        data.UsefulMaterialsPerTurn = UsefulMaterialsPerTurn;
        data.NumberOfUsefulMaterials = NumberOfUsefulMaterials;
        data.UniqueAbility = UniqueAbility;

        File.WriteAllText(_savePath + "/SavedCharacteristics.json", JsonUtility.ToJson(data));
    }
}
