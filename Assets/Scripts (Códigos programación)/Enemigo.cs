using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemigo : MonoBehaviour
{
    // Variable para controlar la velocidad del goomba
    public float movementSpeed = 4.5f;
    // Variable para saber en que direccion se mueve en el eje X
    private int directionX = 1;

   // Variable para almacenar el rigidbody del enemigo
    private Rigidbody2D rigidBody;
  //Variable para saber si el goomba esta muerto
    public bool estaVivo = true;


    private GameManager gameManager;

    
    private void Awake()
    {
      rigidBody = GetComponent<Rigidbody2D>();
      gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      if(estaVivo)
      {
        //Añade velocidad en el eje X
        rigidBody.velocity = new Vector2(directionX * movementSpeed, rigidBody.velocity.y);
      }
      else
      {
        rigidBody.velocity = Vector2.zero;
      }
        
    }

    private void OnCollisionEnter2D(Collision2D hit)
    {
      //Si detecta colision con un objeto con tag Pared
      if(hit.gameObject.tag == "Pared" || hit.gameObject.tag == "Goombas")
      {
        Debug.Log("Me he chocado");

        if(directionX == 1)
        {
          directionX = -1;

        }
        //Si nos movemos a la izquierda lo cambia a la derecha
        else
        {
          directionX = 1;
        }

      }
      //Si se choca con el Mario lo destruye
      else if(hit.gameObject.tag == "Mario")
      {
        Destroy(hit.gameObject);
        gameManager.DeathMario();
      }
    }
}
