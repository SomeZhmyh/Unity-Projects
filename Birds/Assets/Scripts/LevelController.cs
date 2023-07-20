using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelController : MonoBehaviour
{
    Monster[] monsters;
    [SerializeField] string nextLevelName;

    void OnEnable() 
    {
        monsters = FindObjectsOfType<Monster>();
    }

    void Update()
    {
        if (MonstersAreDead())
        GoToNextLevel();
    }

    private void GoToNextLevel()
    {
        Debug.Log("Go to level" + nextLevelName);
        SceneManager.LoadScene(nextLevelName);
    }

    private bool MonstersAreDead()
    {
        foreach (var monster in monsters)
        {
            if (monster.gameObject.activeSelf)
            return false;
        }
        return true;
    }
}
