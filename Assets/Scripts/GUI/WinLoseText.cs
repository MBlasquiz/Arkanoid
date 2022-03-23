using System.Collections;
using TMPro;
using UnityEngine;

public class WinLoseText : MonoBehaviour
{
    [Header ("Basic Properties")]
    [SerializeField] private GameObject winLoseText;
    [SerializeField] private float textOnScreenTime = 1f;

    private void Start() 
    {
        winLoseText.SetActive(false);
        FindObjectOfType<GameController>().onFinishedGame+=SetText;
    }
    
    private void SetText(string text)
    {
        winLoseText.SetActive(true);
        winLoseText.GetComponentInChildren<TextMeshProUGUI>().text = text;
        StartCoroutine(DisableText());
    }

    private IEnumerator DisableText()
    {
        yield return new WaitForSeconds(textOnScreenTime);
        winLoseText.SetActive(false);
    }
    
}
