using System;
using UnityEngine;
using System.Linq;

public class LevelController : MonoBehaviour
{
    private int numberOfblocks;
    public Action onFinishedLevel;


    private void Start() 
    {
        var childs = transform.GetComponentsInChildren<BlockBase>();
        numberOfblocks = childs.Count(x=>!x.GetComponent<BlockBase>().isUnbreakable);
        foreach(var block in childs)
        {
            block.onBlockDestroyed+=UpdateCounter;
        }
    }

    private void UpdateCounter()
    {
        numberOfblocks--;
        if(numberOfblocks == 0)
        {
            onFinishedLevel?.Invoke();
        }
    }
}
