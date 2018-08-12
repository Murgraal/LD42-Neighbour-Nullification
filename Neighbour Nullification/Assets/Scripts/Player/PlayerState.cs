using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    public Player player;
    public float AddStatsTimer,AddStatsTreshold;

    private void Start()
    {
        player = GetComponent<Player>();
    }

    void AddStats()
    {
        player.Stats.Thirst += player.Stats.ThirstAdd;
        player.Stats.Bladder += player.Stats.BladderAdd;
        player.Stats.Hunger += player.Stats.HungerAdd;
        player.Stats.Tiredness += player.Stats.TirednessAdd;
    }
    void Update ()
    {
       AddStatsTimer -= Time.deltaTime;
        if (AddStatsTimer <= 0)
        {
            AddStats();
            AddStatsTimer = AddStatsTreshold;
            player.Stats.UpdateStats();
            player.playerUI.UpdateSliders();
        }

	}
}
