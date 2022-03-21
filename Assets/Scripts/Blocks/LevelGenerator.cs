using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [Header("Level Generator Properties")]
    [Range(1, 8)]
    [SerializeField] private int numberOfRows = 4;
    [Range(1,6)]
    [SerializeField] private  int numberOfBlocksPerRow = 6;

    [Header("Block types")]
    [SerializeField] private GameObject BasicBlockPrefab;

    private const float xMin = -2.5f; 
    private const float yMin = 5.5f; 
    private const float blockWidth = 1f;
    private const float blockHeight = 0.5f;

    void Start()
    {
        GenerateLevel();
    }

    private void GenerateLevel()
    {
        var yPosition = yMin;
        for(var row=0; row<numberOfRows; row++)
        {
            GenerateRow(yPosition);
            yPosition-=blockHeight;
        }
    }

    private void GenerateRow(float yPosition)
    {
        var position = new Vector3(xMin, yPosition, 0);
        for(var block=0; block<numberOfBlocksPerRow; block++)
        {            
            Instantiate(BasicBlockPrefab, position, Quaternion.identity, transform);
            position.x+=blockWidth;
        }
    }
}
