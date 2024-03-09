using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu : MonoBehaviour
{
    public DiscordController controller;

    public GameObject playerprefab;
    GameObject player;
    public Transform StartPlayer;
    public GameObject bossprefab;
    GameObject boss;
    public Transform StartBoss;


    public void PlayGame()
    {
        if(player != null){
            Destroy(player);
            player = null;
        }
        player = Instantiate(playerprefab, StartPlayer);

        if(boss != null)
        {
            Destroy(boss);
            boss = null;
        }
        boss = Instantiate(bossprefab, StartBoss);
    }

    public void ExitGame()
    {   
        controller.DiscordDispose();
        Application.Quit();
    }
}
