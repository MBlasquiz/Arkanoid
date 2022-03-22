using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    [Header("Levels")]
    [SerializeField] private List<GameObject> Levels;
    [SerializeField] private int currentLevel = 0;
    private const int maxLevel = 2;
    public Action onNextLevel;

    void Start()
    {
        LoadLevel();
    }

    private void LoadLevel()
    {
        var level = Instantiate(Levels[currentLevel], transform);
        level.GetComponent<LevelController>().onFinishedLevel += NextLevel;
    }

    private void NextLevel()
    {
        if(currentLevel < maxLevel)
        {
            currentLevel++;
            ClearBlocks();
            onNextLevel?.Invoke();
            LoadLevel();
        }
    }

    private void ClearBlocks()
    {
        for(var childIndex = 0; childIndex < transform.childCount; childIndex++)
        {
            Destroy(transform.GetChild(childIndex).gameObject);
            Debug.Break();
        }
    }
}
