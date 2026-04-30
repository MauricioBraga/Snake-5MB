using System;
using System.Collections.Generic;
using UnityEngine;

public class Snake : MonoBehaviour   {
    public int score;
    public Vector2Int direction = Vector2Int.right;
    private Vector2Int input;
    public List<Transform> segments = new List<Transform>();
    public Transform segmentPreFab;
    public bool ativo = false;
    public GameStateManager gameState;

    public AudioSource sfxComerComida;

    public void Start()        {
         // ativo = true; // remover essa linha depois.
        
        // Reseta a cobra para o tamanho inicial.
        // Faz isso limpando a lista, adicionando novamente a “cabeça”.       
        segments.Clear();
        segments.Add(transform);
        score = 0;
        direction = Vector2Int.right;
    }

    public void setAtivo(bool estado_player)    {
       ativo = estado_player;
    }

 private void Update()    {
        if (!ativo)
            return;
        
        // Only allow turning up or down while moving in the x-axis
        if (direction.x != 0f)      {
            if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))    {
                direction = Vector2Int.up;
            }
            else if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))     {
                direction = Vector2Int.down;
            }
        }
        
        // Só pode mover para a esquerda ou direita se estiver movendo na        
        // direção Y.
        else if (direction.y != 0f)    {
            if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
            {
                direction = Vector2Int.right;
            }
            else if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
            {
                direction = Vector2Int.left;
            }
        }
    }
    

 private void FixedUpdate()    {
        if (!ativo)
            return;
        // Set each segment's position to be the same as the one it follows. We
        // must do this in reverse order so the position is set to the previous
        // position, otherwise they will all be stacked on top of each other.
        for (int i = segments.Count - 1; i > 0; i--)     {
              segments[i].position = segments[i - 1].position;
        }
        // Move the snake in the direction it is facing
        // Round the values to ensure it aligns to the grid
        int x = Mathf.RoundToInt(transform.position.x) + direction.x;
        int y = Mathf.RoundToInt(transform.position.y) + direction.y;
        transform.position = new Vector2(x, y);
    }

    public void ResetState()
    {
        destroiCobra();

        direction = Vector2Int.right;
        transform.position = Vector3.zero;
        score = 0;

       
    }

    
public void destroiCobra()    {
        // destroi apenas os objetos segmentos da cobra,

        // não destrói a cabeça, por isso começa em 1.
        for (int i = 1; i < segments.Count; i++)     {
            // O metodo destroy recebe um GameObject, por isso
            // usamos a variável gameObject do Transform
            Destroy(segments[i].gameObject);
        }
        // objetos foram destruídos, mas a lista ainda tem variáveis que 
        // apontam para eles (apontam para null agora?)
        // então limpamos a lista, e depois adicionamos de volta a cabeça.
        segments.Clear();
        segments.Add(transform);
    }

public void Grow()     {
        // instancia um novo segmento para adicionar a cobra
        Transform segment = Instantiate(segmentPreFab);

        // pega para o novo segmento a posição do último 
        segment.position = segments[segments.Count - 1].position;

        // adiciona o novo segmento a cobra
        segments.Add(segment);

        Debug.Log("rodou");
    }

    private void OnTriggerEnter2D(Collider2D other)   {

        if (other.gameObject.CompareTag("Food"))   {
            this.sfxComerComida.Play();
            Grow();
            score++;
            Debug.Log("score: " + score);
        }
        else if (other.gameObject.CompareTag("Obstacle"))   {
            Debug.Log("bateu na parede ");
            destroiCobra();
            this.gameState.switchState(this.gameState.telaCreditosState);  
        }
    }




}
