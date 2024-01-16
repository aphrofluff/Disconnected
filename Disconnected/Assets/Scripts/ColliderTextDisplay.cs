using UnityEngine;
using UnityEngine.UI;

public class ColliderTextDisplay : MonoBehaviour
{
    public Text displayText;
    public string message = "Welcome!";

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            displayText.text = message;
            displayText.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            displayText.gameObject.SetActive(false);
        }
    }
}
