using System.Collections;
using UnityEngine;

[RequireComponent(typeof(AudioSource))]
public abstract class CapsuleBase : MonoBehaviour
{  
    [Header("Basic Properties")]
    [Range(2, 10)]
    [SerializeField] private float speed = 4f;
    [SerializeField] private float durationEffect = 3f;
    private const float inferiorLimit = -5;
    protected GameObject Player;
    private bool isUsed = false;
    private AudioSource audioSource;

    protected void Start() {
        Player = GameObject.FindGameObjectWithTag(Tags.Player.ToString());
        audioSource = GetComponent<AudioSource>();
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
        if(other.tag == Tags.Player.ToString())
        {
            audioSource.Play();
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
