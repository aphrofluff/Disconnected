using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class DashGUI : MonoBehaviour
{
    [SerializeField] Player_Manager _playerManagerScript;

    private bool isFirstPress = true;
    private bool _canDash;
    float currentValue;
    [SerializeField] private Image dashImage;

    void Start()
    {
        currentValue = 0f;
        dashImage.fillAmount = 1f;
    }

    void Update()
    {
        SelectDash();

        if (isFirstPress && Input.GetKeyDown(KeyCode.LeftShift))
        {
            StartCoroutine(StartCooldown());
            isFirstPress = false;
        }
        else if (!isFirstPress && Input.GetKeyDown(KeyCode.LeftShift) && _canDash)
        {
            StartCoroutine(StartCooldown());
            isFirstPress = false;
        }
    }

    void SelectDash()
    {
        if (_canDash)
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
            _canDash = true;
            isFirstPress = false;
        }

        currentValue = _playerManagerScript.dashingcooldown;
        _canDash = false;

        while (currentValue > 0)
        {
            currentValue -= Time.deltaTime;
            yield return null;
        }

        currentValue = 0f;
        yield return new WaitForSeconds(_playerManagerScript.dashingTime);
        _canDash = true;
    }
}
