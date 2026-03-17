using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public enum PokemonStats
{
    HP,
    PhyAttack,
    MagAttack,
    PhysDefense,
    MagDefense,
    Luck
}


[Serializable]
public class Valuecontainer
{
    public int value;
    public PokemonStats stats;

    public Valuecontainer(int value, PokemonStats stats)
    {
        this.value = value;
        this.stats = stats;
    }
}

[Serializable]
public class ValueBlock
{
    private const int V = 6;
    public List<Valuecontainer> values;

    public void InitPokemon()
    {
        values = new List<Valuecontainer>();

        for(int i = 0; i < V; i++)
        {
            values.Add(new Valuecontainer(0, (PokemonStats)i));
        }
    }
}

[CreateAssetMenu(menuName = "Data/Pokemon")]

public class PokemonData : ScriptableObject
{
    public string pokemonName;
    public ValueBlock stats;

    [ContextMenu("Init")]

    public void Init()
    {
        stats = new ValueBlock();
        stats.InitPokemon();
    }
}
