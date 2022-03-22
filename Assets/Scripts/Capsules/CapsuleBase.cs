using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class CapsuleBase : MonoBehaviour
{  
    [Header("Basic Properties")]
    [Range(2, 10)]
    [SerializeField] private float speed = 4f;
    [SerializeField] private float durationEffect = 3f;
    private const float inferiorLimit = -5;
    protected GameObject Player;
    private bool isUsed = false;

    protected void Start() {
        Player = GameObject.FindGameObjectWithTag("Player");
    }

    private void Update() {
        transform.Translate(0, -speed * Time.deltaTime, 0);

        if(transform.position.y < inferiorLimit && !isUsed)
        {
            Destroy(gameObject);
        }
    }
    protected abstract void ExecuteAction();
    protected abstract void Recover();

    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player")
        {
            isUsed = true;
            ExecuteAction();
            StartCoroutine(RecoverEffect()); 
            GetComponent<MeshRenderer>().enabled = false;
        }
    }

    private IEnumerator RecoverEffect()
    {
        yield return new WaitForSeconds(durationEffect);
        Recover();
        Destroy(gameObject);   
    }
}
