using UnityEngine;

public class BiggerPale : CapsuleBase
{
    [Header("Specific properties")]
    [SerializeField] private float scale = 1.5f;
    private Vector3 originalScale;

    private new void Start() 
    {
        base.Start();
        originalScale = Player.transform.localScale;
    }

    protected override void ExecuteAction()
    {
        Player.transform.localScale = new Vector3(originalScale.x*scale, originalScale.y, originalScale.z);
    }

    protected override void Recover()
    {
        Player.transform.localScale = originalScale;
    }
}
