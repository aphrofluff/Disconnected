using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    Animator anim;
    Player_Manager _playerManagerScript;

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
        if(_playerManagerScript.IsGrounded())
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
