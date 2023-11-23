using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class DashGUI : MonoBehaviour
{
    [SerializeField] Player_Manager _playerManagerScript;

    private bool isFirstPress = true;
    float currentValue;
    [SerializeField] private Image dashImage;

    void Update()
    {
        SelectDash();

        if (isFirstPress && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(StartCooldown());
            isFirstPress = false;
        }
        else if (!isFirstPress && Input.GetKeyDown(KeyCode.LeftShift) && _playerManagerScript.canDash)
        {
            StartCoroutine(StartCooldown());
            isFirstPress = false;
        }
    }

    void SelectDash()
    {
        if (_playerManagerScript.canDash)
        {
            dashImage.fillAmount = 0f;
        }
        else
        {
            dashImage.fillAmount = currentValue / _playerManagerScript.dashingcooldown;
        }
    }

    IEnumerator StartCooldown()
    {
        if (isFirstPress)
        {
            _playerManagerScript.canDash = true;
            isFirstPress = false;
        }

        currentValue = _playerManagerScript.dashingcooldown;
        _playerManagerScript.canDash = false;

        while (currentValue > 0)
        {
            currentValue -= Time.deltaTime;
            yield return null;
        }

        currentValue = 0f;
        _playerManagerScript.canDash = true;
        isFirstPress = true;
    }
}
