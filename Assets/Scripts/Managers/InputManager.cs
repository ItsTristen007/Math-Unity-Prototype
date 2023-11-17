using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public static class InputManager 
{
    private static GameControls _gameControls;
    
    public static void Init(Player myPlayer)
    {
        _gameControls = new GameControls();
        
        _gameControls.Enable();
        
        _gameControls.InGame.Movement.performed += ctx =>
        {
            myPlayer.SetMovementDirection(ctx.ReadValue<Vector2>());
        };

        _gameControls.InGame.Jump.started += hi =>
        {
            myPlayer.jump();
        };

    }

    public static void SetGameControls()
    {
        _gameControls.InGame.Enable();
    }
}
