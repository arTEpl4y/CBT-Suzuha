using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Discord;

public class DiscordController : MonoBehaviour
{
    public Discord.Discord discord;

    void Start()
    {
        discord = new Discord.Discord(1009085490202419342, (System.UInt64)Discord.CreateFlags.Default);
        var activityManager = discord.GetActivityManager();
        var activity = new Discord.Activity
        {
            Details = "MOFU MOFU",
            State = "Fluffing...",
            Assets = {
                LargeImage = "cbtsuzuha_logo"
            }
        };
        activityManager.UpdateActivity(activity, (res) =>
        {
            if (res == Discord.Result.Ok)
                Debug.Log("Discord status set OK");
            else
                Debug.LogError("Discord status set ERROR");
        });
    }
    void Update()
    {
        if (discord != null)
            discord.RunCallbacks();
    }

    public void DiscordDispose()
    {
        discord?.Dispose();
        discord = null;
    }
}
