using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[ExecuteInEditMode]
public class LevelGenerator : MonoBehaviour
{
    [Header("Level Generator Properties")]
    [Range(1, 8)]
    [SerializeField] private int numberOfRows = 4;
    [Range(1,6)]
    [SerializeField] private  int numberOfBlocksPerRow = 6;

    [Header("Block types")]
    [Range(0f,0.5f)]
    [SerializeField] private float probabilityUnbreakableBlock = 0.1f;
    [SerializeField] private List<GameObject> BlocksPrefabs;
    [SerializeField] private GameObject UnbreakableBlockPrefabs;

    private const float xMin = -2.5f; 
    private const float yMin = 5.5f; 
    private const float blockWidth = 1f;
    private const float blockHeight = 0.5f;

    internal void GenerateLevel()
    {
        ClearPreviousLevels();

        var yPosition = yMin;
        for(var row=0; row<numberOfRows; row++)
        {
            GenerateRow(yPosition);
            yPosition-=blockHeight;
        }
    }

    private void ClearPreviousLevels()
    {
        for(var childIndex = 0; childIndex < transform.childCount; childIndex++)
        {
            DestroyImmediate(transform.GetChild(childIndex).gameObject);
        }
    }

    private void GenerateRow(float yPosition)
    {
        var position = new Vector3(xMin, yPosition, 0);
        for(var block=0; block<numberOfBlocksPerRow; block++)
        {            
            Instantiate(GetRandomPrefab(), position, Quaternion.identity, transform);
            position.x+=blockWidth;
        }
    }

    private GameObject GetRandomPrefab()
    {
        var random = UnityEngine.Random.Range(0f, 1f);

        if(random < probabilityUnbreakableBlock)
        {
            return UnbreakableBlockPrefabs;
        }

        return BlocksPrefabs[UnityEngine.Random.Range(0,BlocksPrefabs.Count)];

    }
}
