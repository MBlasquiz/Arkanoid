using UnityEngine;

public class BlockBase : MonoBehaviour
{
    [Header ("Basic Properties")]
    [Range(1,3)]
    [SerializeField] private int lives = 1;
    [SerializeField] private bool isUnbreakable = false;

    private void OnTriggerEnter(Collider other) 
    {
        if(!isUnbreakable)
        {
            if(other.tag == "Ball" && lives > 0)
            {
                lives--;
            }

            if(lives <= 0)
            {
                Destroy(gameObject);
            }
        }
    }
}
