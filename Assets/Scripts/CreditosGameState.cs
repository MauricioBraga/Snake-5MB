using UnityEngine;

public class CreditosGameState: GameBaseState
{
    public override void enterState(GameStateManager gameState)  {
        Debug.Log("entramos na tela de créditos");
    }
    public override void updateState(GameStateManager gameState)  {
       if (Input.GetKeyDown(KeyCode.Space))  {
            gameState.switchState(gameState.telaInicialState);
        }

    }
    public override void leaveState(GameStateManager gameState)  {
        Debug.Log("saímos da tela de créditos");
    }
}

