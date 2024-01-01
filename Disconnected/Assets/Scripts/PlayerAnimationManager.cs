using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    Animator anim;
    Player_Manager _playerManagerScript;
    [SerializeField] PauseMenu _pauseMenuScript;

    string currentState;

    const string PLAYER_IDLE = "Player_Idle_2";
    const string PLAYER_RUN = "Player_Run";

    void Start()
    {
        anim = GetComponent<Animator>();
        _playerManagerScript = GetComponentInParent<Player_Manager>();
    }

    void Update()
    {
        if(_playerManagerScript.IsGrounded() && !_pauseMenuScript.isPaused)
        {
            if(_playerManagerScript.horizontal != 0)
            {
                ChangeAnimationState(PLAYER_RUN);
            }
            else
            {
                ChangeAnimationState(PLAYER_IDLE);
            }
        }
    }

    void ChangeAnimationState(string newState)
    {
        if(currentState == newState) return;

        anim.Play(newState);

        currentState = newState;
    }
}
