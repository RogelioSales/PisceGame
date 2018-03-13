using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public class Numbers
    {
        public int totalFishInLake;
        public int fishInPond;
        public int fishTaken;
        public int fishEaten;

        public Numbers(int tFIL, int fIP, int fT, int fE)
        {
            totalFishInLake = tFIL;
            fishInPond = fIP;
            fishTaken = fT;
            fishEaten = fE;
        }
    }
    public Numbers myNumbers = new Numbers(50,0,0,0);

    public int numOfRounds = 6;
    public float startDelay = 3f;
    public float endDelay = 3f;
    public Text messageRound;
    public Text messagePlayerN;
    public GameObject tribePrefab;
    public PlayerControl[] players;
    [HideInInspector]public bool numPlayersAlive = false;

    private int roundNumber;
    private WaitForSeconds startWait;
    private WaitForSeconds endWait;
    private PlayerControl daySurvivors;
    private PlayerControl fullSurvivors;

    private void Start()
    {
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);
        SpawnAllPlayer();
        StartCoroutine(GameLoop());
    }

    private void SpawnAllPlayer()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].pInstance =
         Instantiate(tribePrefab, players[i].spawnPoint.position, players[i].spawnPoint.rotation) as GameObject;
            players[i].playerNumber = i + 1;
            players[i].SetUp();
        }
    }

    private IEnumerator GameLoop()
    {
        yield return StartCoroutine(RoundStarting());
        yield return StartCoroutine(RoundPlaying());
        yield return StartCoroutine(RoundEnding());

        if (fullSurvivors != null)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            StartCoroutine(GameLoop());
        }
    }
    private IEnumerator RoundStarting()
    {
        ResetAllPlayers();
        DisablePlayerControl();
        roundNumber++;
        messagePlayerN.text = "1";
        messageRound.text = "DAY" + roundNumber;

        yield return startWait;
    }
    private IEnumerator RoundPlaying()
    {
        EnablePlayerControl();
        messageRound.text = string.Empty;
        while (numPlayersAlive == false)
        {
            yield return null;
        }
    }
    private IEnumerator RoundEnding()
    {
        DisablePlayerControl();
        daySurvivors = null;
        daySurvivors = GetRoundWinner();
        if (daySurvivors != null)
            daySurvivors.survived++;
        fullSurvivors = GetGameWinner();
        string message = EndMessage();
        messageRound.text = message;
        yield return endWait;
    }
    private void EnablePlayerControl()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].EnableControl();
        }
    }

    private void DisablePlayerControl()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].DisableControl();
        }
    }

    private void ResetAllPlayers()
    {
        for (int i = 0; i < players.Length; i++)
        {
            players[i].Reset();
        }
    }
    private PlayerControl GetRoundWinner()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].pInstance.activeSelf)
                return players[i];
        }
        return null;
    }
    private PlayerControl GetGameWinner()
    {
        for (int i = 0; i < players.Length; i++)
        {
            if (players[i].survived == numOfRounds)
                return players[i];
        }
        return null;
    }
    private string EndMessage()
    {
        string message = "DRAW!";

        if (daySurvivors != null)
            message = daySurvivors.coloredPlayerText + " Survives the Day";

        message += "\n\n\n\n";

        for (int i = 0; i < players.Length; i++)
        {
            message += players[i].coloredPlayerText + ": " + players[i].survived + " Survives\n";
        }

        if (fullSurvivors != null)
            message = fullSurvivors.coloredPlayerText + " Fully Survived";
        return message;
    }

    public void EndButton()
    {     
        int numOfPlayersLeft = 0;
        for (int i = 0; i < players.Length; i++)
        {
            Debug.Log("Working");
            Debug.Log(numOfPlayersLeft);
            if (players[i  ].playerNumber == 1)
            {
                numOfPlayersLeft++;
                players[i].playerNumber++;
                messagePlayerN.text = "2";
                Debug.Log("Works");
            }
            else if(players[i].playerNumber == 2)
            {
                numOfPlayersLeft++;
                players[i].playerNumber++;
                messagePlayerN.text = "3";
            }
            else if(players[i].playerNumber == 3)
            {
                numOfPlayersLeft++;
                players[i].playerNumber++;
                messagePlayerN.text = "4";
            }
            else if(players[i].playerNumber == 4)
            {
                numOfPlayersLeft++;
                players[i].playerNumber = 1;
                messagePlayerN.text = "1";
            }               
        }
        if(numOfPlayersLeft == 4)
        {
            numPlayersAlive = true;
        }
        
    }
}

