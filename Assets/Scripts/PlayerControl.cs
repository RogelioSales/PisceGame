
using UnityEngine;

using System;

[Serializable]
public class PlayerControl
{
    public Color playerColor;
    public Transform spawnPoint;
    

    [HideInInspector]public int playerNumber;
    [HideInInspector]public GameObject pInstance;
    [HideInInspector]public string coloredPlayerText;
    [HideInInspector]public int survived;

    private Player player;  

    public void SetUp()
    {
        player = pInstance.GetComponent<Player>();
        coloredPlayerText = 
            "<color=#" + ColorUtility.ToHtmlStringRGB(playerColor) + ">PLAYER " + playerNumber + "</color>";
        player.playerNumber = playerNumber;

        SpriteRenderer[] renderers = pInstance.GetComponentsInChildren<SpriteRenderer>();
        for (int i = 0; i < renderers.Length; i++)
        {
            renderers[i].color = playerColor;
        }
    }

    public void DisableControl()
    {
       
    }
    public void EnableControl()
    {
       
    }
    public void Reset()
    {
    }
}
