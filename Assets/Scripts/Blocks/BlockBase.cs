using UnityEngine;
using System.Collections.Generic;
using System;

[RequireComponent(typeof(AudioSource))]
public class BlockBase : MonoBehaviour
{
    [Header ("Basic Properties")]
    [Range(1,3)]
    [SerializeField] private int lives = 1;
    [SerializeField] private bool isUnbreakableBlock;
    internal bool isUnbreakable { get {return isUnbreakableBlock; } } 

    [Header ("Capsules")]
    [Range(0f,0.3f)]
    [SerializeField] private float probabilityToDropCapsule = 0.15f;
    [SerializeField] private List<GameObject> capsules;
    public Action onBlockDestroyed;

    private AudioSource audioSource;

    private void Start() {
        audioSource = GetComponent<AudioSource>();   
    }
    private void OnTriggerEnter(Collider other) 
    {
        if(!isUnbreakable)
        {
            if(other.tag == "Ball" && lives > 0)
            {
                audioSource.Play();
                lives--;
            }

            if(lives <= 0)
            {
                var prob = UnityEngine.Random.Range(0f,1f);
                if(prob < probabilityToDropCapsule)
                {
                    Instantiate(capsules[UnityEngine.Random.Range(0,capsules.Count)],
                                transform.position, 
                                Quaternion.identity);
                }
                onBlockDestroyed?.Invoke();
                Destroy(gameObject);
            }
        }
    }
}
