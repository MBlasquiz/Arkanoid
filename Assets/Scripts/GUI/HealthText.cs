using UnityEngine;
using TMPro;

public class HealthText : MonoBehaviour
{
    private TextMeshProUGUI lifes;

    void Start()
    {
        lifes = GetComponent<TextMeshProUGUI>();
        GameObject.FindGameObjectWithTag("Player").GetComponent<HealthController>().onLostLife+=UpdateText;
    }

    void UpdateText(int amount)
    {
        lifes.text = string.Format("x{0}", amount);
    }
}
