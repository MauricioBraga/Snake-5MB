using UnityEngine;

public class JogoGameState: GameBaseState
{
    private GameObject gameMusic;
    public override void enterState(GameStateManager gameState)  {
        Debug.Log("entramos no modo jogo.");
        gameState.AtivarElementosJogo(true);
        gameState.player.GetComponent<Snake>().ResetState();
        gameMusic = GameObject.Find("Tight_Turns");
        // gameMusic.GetComponentInParent<AudioSource>().Play();

    }
    public override void updateState(GameStateManager gameState)  {
       if (Input.GetKeyDown(KeyCode.Space))  {
            gameState.switchState(gameState.telaCreditosState);
        }

    }
    public override void leaveState(GameStateManager gameState)  {
        Debug.Log("saímos do modo jogo");
        gameState.AtivarElementosJogo(false);
        gameMusic.GetComponentInParent<AudioSource>().Stop();

    }
}

