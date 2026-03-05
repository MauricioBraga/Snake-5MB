using UnityEngine;

public class CreditosGameState: GameBaseState
{
    private GameObject telaCreditosJogo;
    private float tempo_mudanca = 0.5f;
    private float timer;
    private int contador;

    public override void enterState(GameStateManager gameState)  {
        Debug.Log("entramos na tela de créditos");
        telaCreditosJogo = GameObject.Find("tela_creditos_Snake_1280_1060_0");
        telaCreditosJogo.GetComponent<SpriteRenderer>().enabled = true;
        timer = 0;
        contador = 10;
    }
    public override void updateState(GameStateManager gameState)  {
        if (timer < tempo_mudanca)  {
            timer = timer + Time.deltaTime;
        }
        else  {
            contador--;
            timer = 0;
            if (contador < 0)  {
                gameState.switchState(gameState.telaInicialState);        
            }
        }
       if (Input.GetKeyDown(KeyCode.Space))  {
            gameState.switchState(gameState.telaInicialState);
        }

    }
    public override void leaveState(GameStateManager gameState)  {
        Debug.Log("saímos da tela de créditos");
        telaCreditosJogo.GetComponent<SpriteRenderer>().enabled = false;
    }
}

