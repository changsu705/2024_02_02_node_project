using JetBrains.Annotations;
using System;
using System.Collections.Generic;


[Serializable]

public class PlayerModel
{
    public string PlayerName;
    //public int id;
    //public string name;
    public int metal;
    public int crystal;
    public int deuteriurm;
    public List<PlanetModel> Planets;

    public PlayerModel(string name)
    {
        this.PlayerName = name;
        this.metal = 500;
        this.crystal = 300;
        this.deuteriurm = 100;
    }
    public void CollectResources()
    {
        metal += 10;
        crystal += 5;
        deuteriurm += 2;
    }
}
public class PlanetModel
{
    public int id;
    public string name;
    public int metal;
    public int crystal;
    public int deuteriurm;

    public PlanetModel(int id, string name)
    {
        this.id = id;
        this.name = name;
        this.metal = 500;
        this.crystal = 300;
        this.deuteriurm = 100;
    }
}