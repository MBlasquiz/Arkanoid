using System;
using UnityEngine;
using System.Linq;

public class LevelController : MonoBehaviour
{
    private int numberOfblocks;
    public Action onNewLevel;


    private void Start() 
    {
        var childs = transform.GetComponentsInChildren<BlockBase>();
        numberOfblocks = childs.Count(x=>!x.GetComponent<BlockBase>().isUnbreakable);
        foreach(var block in childs)
        {
            block.onBlockDestroyed+=UpdateCounter;
        }
    }

    private void Update() 
    {
        if(numberOfblocks == 0)
        {
            onNewLevel?.Invoke();
        }
    }

    private void UpdateCounter()
    {
        numberOfblocks--;
    }
}
