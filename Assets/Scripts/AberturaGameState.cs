using UnityEngine;

public class AberturaGameState: GameBaseState
{
    private GameObject telaInicialJogo;
    private float tempo_mudanca = 0.5f;
    private float timer;
    private int contador;

    private GameObject sfxTelaInicialJogo;
    public override void enterState(GameStateManager gameState)  {
        Debug.Log("entramos na tela inicial");
        telaInicialJogo = GameObject.Find("tela_nova_inicial_Snake_1280_1060_0");
        telaInicialJogo.GetComponent<SpriteRenderer>().enabled = true;

        timer = 0;
        contador = 20;
        sfxTelaInicialJogo = GameObject.Find("snake-hissing");
        sfxTelaInicialJogo.GetComponentInParent<AudioSource>().Play();

    }
    public override void updateState(GameStateManager gameState)  {

        if (timer < tempo_mudanca)  {
            timer = timer + Time.deltaTime;
        }
        else  {
            contador--;
            timer = 0;
            if (contador < 0)  {
                gameState.switchState(gameState.telaCreditosState);        
            }
        }
        if (Input.GetKeyDown(KeyCode.Space))  {
            gameState.switchState(gameState.jogoState);
        }

    }
    public override void leaveState(GameStateManager gameState)  {
        Debug.Log("saímos da tela inicial");
        telaInicialJogo.GetComponent<SpriteRenderer>().enabled = false;
        sfxTelaInicialJogo.GetComponentInParent<AudioSource>().Stop();
                                        
    }
}

