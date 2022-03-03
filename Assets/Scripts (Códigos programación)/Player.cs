using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    //Variable para la velocidad y fuerza de salto
   public float speed = 5f;
   public float jumpForce = 10f;
    //Variable para saber si estamos en el suelo
   public bool isGrounded;
    //Variable para almacenar el input de movimiento
   private float dirx; 

    //Variables de componentes
   public SpriteRenderer renderer;
   public Animator _animator;
   Rigidbody2D _rBody;
    private GameManager gameManager;


   void Awake()
   {
       //Asignamos los componentes a las variables
       _animator = GetComponent<Animator>();
       _rBody = GetComponent<Rigidbody2D>();
       gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
   }
    // Start is called before the first frame update
 
    // Update is called once per frame
    void Update()
    {
        dirx = Input.GetAxisRaw ("Horizontal");
        Debug.Log(dirx);       

        //transform.position += new Vector3(dirx, 0, 0) * speed * Time.deltaTime;    
        
        if(dirx == -1)
        { 
            renderer.flipX = true;
            _animator.SetBool("Animación corriendo", true);
        }
        else if(dirx == 1)
        {
            renderer.flipX = false;
             _animator.SetBool("Animación corriendo", true);
        }
        else
        {
             _animator.SetBool("Animación corriendo", false);
        }

        if(Input.GetButtonDown("Jump") && isGrounded)
    {
        _rBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        _animator.SetBool("Animación salto", true);
    }

    }
    
    void FixedUpdate()
    {
        _rBody.velocity = new Vector2(dirx * speed, _rBody.velocity.y);
    }

        void OnTriggerEnter2D(Collider2D collider)
        {
            //Si el objeto que entra en el trigger tiene el tag de Goombas
            if(collider.gameObject.CompareTag("Goombas"))
            {
                //Llamamos a la funcion DeathGoomba del script GameManager
                Debug.Log("Goomba muerto");
                gameManager.DeathGoomba(collider.gameObject);
            }
            //Si el trigger entra en la zona de muerte
            if(collider.gameObject.CompareTag("Zona de muerte"))
            {
                Debug.Log("Estoy muerto");
                gameManager.DeathMario();
                              
            }

            //Si el objeto que entra en el trigger tiene el tag de flagpole
            if(collider.gameObject.CompareTag("Flagpole"))
            {
                Debug.Log("Ganaste");
                //Llamamos a la funcion flagpole del script GameManager
                gameManager.Flagpole();
            }

            //Si el objeto que entra en el trigger tiene el tag de monedas
            if(collider.gameObject.CompareTag("Monedas"))
            {
                Debug.Log("Tengo monedas");
                //Llamamos a la funcion tengo monedas del Game Manager
                gameManager.TengoMonedas(collider.gameObject);
            }
        }
    }
