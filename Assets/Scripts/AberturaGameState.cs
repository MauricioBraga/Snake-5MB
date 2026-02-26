using UnityEngine;

public class AberturaGameState: GameBaseState
{
    public override void enterState(GameStateManager gameState)  {
        Debug.Log("entramos na tela inicial");
    }
    public override void updateState(GameStateManager gameState)  {

    }
    public override void leaveState(GameStateManager gameState)  {
        Debug.Log("saímos da tela inicial");
    }
}

