using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class PlayerCharacteristics : MonoBehaviour
{
    public int MaxHealth { get; private set; }
    public int CurrentHealth { get; private set; }
    public int HealthRegeneration { get; private set; }
    public int MeleeDamage { get; private set; }
    public int MeleeDamageModifier { get; private set; }
    public int RangedDamageModifier { get; private set; }
    public int MagicDamageModifier { get; private set; }
    public int CriticalHitChance { get; private set; }
    public int CriticalDamageMultiplier { get; private set; }
    public int Speed { get; private set; }
    public int Luck { get; private set; }
    public int SciencePointsPerTurn { get; private set; }
    public int NumberOfSciencePoints { get; private set; }
    public int UsefulMaterialsPerTurn { get; private set; }
    public int NumberOfUsefulMaterials { get; private set; }
    public int[] UniqueAbility { get; private set; }

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
