using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    

    [Header("BasicStats")]
    public float speed;
    [Header("DeathTriggerAttributes")]
    public float Bladder,BladderAdd;
    public float Thirst,ThirstAdd;
    public float Hunger,HungerAdd;
    public float Tiredness,TirednessAdd;

    public List<float> list;

    public void UpdateStats()
    {
        list.Clear();
        list.Add(Bladder);
        list.Add(Thirst);
        list.Add(Hunger);
        list.Add(Tiredness);
    }
    private void Start()
    {
        UpdateStats();
    }
}
