using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchCharacterScript : MonoBehaviour
{
    private GameObject[] characters;
    private int index;
    public Text name_of_race = null;
    void Start()
    {
        index = PlayerPrefs.GetInt("Character selected");
        characters = new GameObject[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            characters[i] = transform.GetChild(i).gameObject;
        }
        foreach (GameObject g in characters)
        {
            g.SetActive(false);
        }
        if (characters[index])
        {
            characters[index].SetActive(true);
            Scene s = SceneManager.GetActiveScene();
            if (s.buildIndex == 1)
            {
                name_of_race.text = characters[index].gameObject.name;
            }
        }
    }
    public void SwitchAvatar()
    {
        characters[index].SetActive(false);
        index++;
        if (index == characters.Length)
        {
            index = 0;
        }
        characters[index].SetActive(true);
        Scene s = SceneManager.GetActiveScene();
        if (s.buildIndex == 1)
        {
            name_of_race.text = characters[index].gameObject.name;
        }
    }
    public void StartGame()
    {
        PlayerPrefs.SetInt("Character selected", index);
        SceneManager.LoadScene(2);
    }
}