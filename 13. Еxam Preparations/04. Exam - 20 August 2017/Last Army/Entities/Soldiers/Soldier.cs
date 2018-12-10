﻿using System;
using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    private const int MaxEndurance = 100;
    private const int SoldierRegenerateValue = 10;

    private double endurance;

    protected Soldier(string name, int age, double experience, double endurance)
    {
        this.Name = name;
        this.Age = age;
        this.Experience = experience;
        this.Endurance = endurance;
        this.Weapons = this.InitlizeWeapons();
    }

    protected abstract IReadOnlyList<string> WeaponsAllowed { get; }

    public string Name { get; }

    public int Age { get; }

    public double Experience { get; private set; }

    public virtual double OverallSkill => this.Experience + this.Age;

    public double Endurance
    {
        get { return endurance; }
        protected set
        {
            this.endurance = Math.Min(value, MaxEndurance);
        }
    }

    public IDictionary<string, IAmmunition> Weapons { get; }

    private IDictionary<string, IAmmunition> InitlizeWeapons()
    {
        Dictionary<string, IAmmunition> weapons = new Dictionary<string, IAmmunition>();
        foreach (string weapon in this.WeaponsAllowed)
        {
            weapons.Add(weapon, null);
        }

        return weapons;
    }

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel <= 0) == 0;
    }

    public void CompleteMission(IMission mission)
    {
        this.Endurance -= mission.EnduranceRequired;
        this.Experience += mission.EnduranceRequired;

        this.AmmunitionRevision(mission.WearLevelDecrement);
    }

    public virtual void Regenerate() => this.Endurance += this.Age + SoldierRegenerateValue;

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);
}