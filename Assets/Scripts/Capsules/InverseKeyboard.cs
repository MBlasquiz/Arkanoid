using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseKeyboard : CapsuleBase
{
    protected override void ExecuteAction()
    {
        Player.GetComponent<PlayerMovement>().InverseMovement(true);
    }

    protected override void Recover()
    {
        Player.GetComponent<PlayerMovement>().InverseMovement(false);
    }
}
