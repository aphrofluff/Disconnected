using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DashGUI : MonoBehaviour
{
    [SerializeField] PlayerMovement _playerMovementScript;

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
        else if(!isFirstPress && Input.GetKeyDown(KeyCode.LeftShift) && _playerMovementScript.canDash)
        {
            StartCoroutine(StartCooldown());
        }
    }

    void SelectDash()
    {
        if(_playerMovementScript.canDash)
        {
            dashImage.fillAmount = 0f;
        }
        else
        {
            dashImage.fillAmount = currentValue / _playerMovementScript.dashingcooldown;
        }
    }

    IEnumerator StartCooldown()
    {
        if (isFirstPress)
        {
            _playerMovementScript.canDash = true;
            isFirstPress = false;
        }

        currentValue = _playerMovementScript.dashingcooldown;
        _playerMovementScript.canDash = true;

        while (currentValue > 0)
        {
            currentValue -= Time.deltaTime;
            yield return null;
        }

        currentValue = 0f;
        _playerMovementScript.canDash = false;
    }
}
