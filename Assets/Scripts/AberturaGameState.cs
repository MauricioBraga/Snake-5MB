using UnityEngine;

public class AberturaGameState: GameBaseState
{
    private GameObject telaInicialJogo;
    public override void enterState(GameStateManager gameState)  {
        Debug.Log("entramos na tela inicial");
        telaInicialJogo = GameObject.Find("tela_nova_inicial_Snake_1280_1060_0");
        telaInicialJogo.GetComponent<SpriteRenderer>().enabled = true;
    }
    public override void updateState(GameStateManager gameState)  {

        if (Input.GetKeyDown(KeyCode.Space))  {
            gameState.switchState(gameState.jogoState);
        }

    }
    public override void leaveState(GameStateManager gameState)  {
        Debug.Log("saímos da tela inicial");
        telaInicialJogo.GetComponent<SpriteRenderer>().enabled = false;
    }
}

