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
    GameObject[] player1;
    GameObject[] player2;
    GameObject[] player3;
    GameObject[] player4;


    private int roundNumber;
    private WaitForSeconds startWait;
    private WaitForSeconds endWait;
    private PlayerControl daySurvivors;
    private PlayerControl fullSurvivors;

    private void Start()
    {
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);
        player1= GameObject.FindGameObjectsWithTag("Player1");
        player2 = GameObject.FindGameObjectsWithTag("Player2");
        player3 = GameObject.FindGameObjectsWithTag("Player3");
        player4 = GameObject.FindGameObjectsWithTag("Player4");
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
      //  ResetAllPlayers();
       // DisablePlayerControl();
        roundNumber++;
        messagePlayerN.text = "1";
        messageRound.text = "DAY" + roundNumber;


        yield return startWait;
    }
    private IEnumerator RoundPlaying()
    {
      //  EnablePlayerControl();
        messageRound.text = string.Empty;
       // while ()
        //{
           yield return null;
      //  }
    }
    private IEnumerator RoundEnding()
    {
     //   DisablePlayerControl();
      //  daySurvivors = null;
       // daySurvivors = GetRoundWinner();
       // if (daySurvivors != null)
        //    daySurvivors.survived++;
        //fullSurvivors = GetGameWinner();
       // string message = EndMessage();
       // messageRound.text = message;
        yield return endWait;
    }
    private void EnablePlayerControl()
    {
       
    }
    private void DisablePlayerControl()
    {

    }

    private void ResetAllPlayers()
    {
        
    }
    private void GetRoundWinner()
    {
       
    }
    private void GetGameWinner()
    {
      
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
        if(player1.Length == 6)
        {
            messagePlayerN.text = "2";
            player2[6].SetActive(true);
            player1[6].SetActive(false);
          
        }
        else if (player2 != null)
        {
            messagePlayerN.text = "3";
            player2[6].SetActive(false);
            player3[6].SetActive(true);
        }

    }
}

