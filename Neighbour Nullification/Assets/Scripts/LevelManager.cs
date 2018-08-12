using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public GameObject EndUI,Level,IngameUI,HowtoUI1,Howtoui2;
    public Text WhoWonText,Description;
    public Player Player1,Player2;
    public bool declareEnd;

    public void ToggleElements(GameObject obj)
    {
        if (obj.activeSelf)
            obj.SetActive(false);
        else
            obj.SetActive(true);
    }
    public void Update()
    {
        if (EndUI.activeSelf == false)
        {
            if (WhoWon.player1win)
            {
                EndStuff(Player2, 2);
            }
            if (WhoWon.player2win)
            {
                EndStuff(Player1, 1);
            }
        }
    }

    public void ResetGame(int Index)
    {
        if (Index == 0)
        {
            SceneManager.LoadScene(0);
            Level.SetActive(false);
            IngameUI.SetActive(false);
            EndUI.SetActive(false);
            HowtoUI1.SetActive(true);
            Howtoui2.SetActive(false);
            WhoWon.player1win = false;
            WhoWon.player2win = false;
        }
        else
            Application.Quit();
    }

    public void ResetStats(Player player)
    {
        for (int i = 0; i < player.Stats.list.Count; i++)
        {
            player.Stats.list[i] = 0;
        }
    }
    void EndStuff(Player player, int pnum)
    {
        WhoWonText.text = "Player 1 Won";
        if (player.Stats.Bladder >= 100)
            Description.text = "Player " + pnum + " died from urine poisoning";
        else if (player.Stats.Thirst >= 100)
            Description.text = "Player " + pnum + " died  from thirst and never recoved";
        else if (player.Stats.Hunger >= 100)
            Description.text = "Player " + pnum + " died  from a malfunction in the food chain";
        else if (player.Stats.Tiredness >= 100)
            Description.text = "Player " + pnum + " died from severe insomnia";
        ToggleElements(EndUI);
        ToggleElements(IngameUI);
        ToggleElements(Level);
    }
}
