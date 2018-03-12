using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Selection : MonoBehaviour
{
    private GameObject[] tribeSelection;
    private int selectIndex = 0;

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
    public void PlayButton(int sceneIndex)
    {
        PlayerPrefs.SetInt("CharacterSelected", selectIndex);
        SceneManager.LoadScene(sceneIndex);
    }
}
