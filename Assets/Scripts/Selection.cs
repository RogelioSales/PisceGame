using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour
{
    private GameObject[] tribeSelection;
    private int selectIndex = 0;
    private Color altColor;
   

    private void Start()
    {
        tribeSelection = new GameObject[transform.childCount];

        for(int i = 0; i < transform.childCount; i++)
        {
            tribeSelection[i] = transform.GetChild(i).gameObject;
        }
        foreach(GameObject go in tribeSelection)
        {
            go.SetActive(false);
        }
        tribeSelection[selectIndex].SetActive(true);
    }
    public void Select(int index)
    {
        if (index == selectIndex)
        {
            return;
        }
        if (index < 0 || index >= tribeSelection.Length)
        {
            return;
        }
        tribeSelection[selectIndex].SetActive(false);
        selectIndex = index;
        tribeSelection[selectIndex].SetActive(true);
      
    }

    public void PlayerButton(int playerNumber)
    {
       if(playerNumber == 0)
        {
            tribeSelection[selectIndex].SetActive(true);
            altColor = Color.red;

            return;
        }
       else if(playerNumber == 1)
        {
            tribeSelection[selectIndex].SetActive(true);
            altColor = Color.blue;
        }
       else if (playerNumber == 2)
        {
            tribeSelection[selectIndex].SetActive(true);
            altColor = Color.green;
        }
        else if (playerNumber == 3)
        {
            tribeSelection[selectIndex].SetActive(true);
            altColor = Color.yellow;
        }
        else
        {
            return;
        }
    }
    public void PlayButton(int sceneIndex)
    {
        DontDestroyOnLoad(this.gameObject);
        SceneManager.LoadScene(sceneIndex);
    }
}
