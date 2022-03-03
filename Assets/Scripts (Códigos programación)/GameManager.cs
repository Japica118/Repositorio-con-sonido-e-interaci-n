using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    private SFXManager sfxManager;
    private BOMManager bomManager;

    void Awake()
    {
        sfxManager = GameObject.Find("SFXManager").GetComponent<SFXManager>();
        bomManager = GameObject.Find("BOMManager").GetComponent<BOMManager>();
    }


    public void DeathMario()
    {
        sfxManager.DeathSound();
        bomManager.StopBOMM();
    }

    public void Flagpole()
    {
        sfxManager.FlagpoleSound();
        bomManager.StopBOMM();
    }

    public void TengoMonedas(GameObject coins)
    {
        sfxManager.CoinSound();
        Destroy(coins, 0.1f);
    }

    //Funcion para matar goombas
    public void DeathGoomba(GameObject goomba)
    {
        //Variable para el animator de goomba
        Animator goombaAnimator;
        //Variable para el script del goomba
        Enemigo goombaScript;
        //Variable para el collider
        BoxCollider2D goombaCollider;
        //Asignamos las variables
        goombaScript = goomba.GetComponent<Enemigo>();
        goombaAnimator = goomba.GetComponent<Animator>();
        goombaCollider = goomba.GetComponent<BoxCollider2D>();

        //Cambiamos a la animacion de muerte
        goombaAnimator.SetBool("Muerte Goomba", true);

        //Cambaimos la variable del goomba a false
        goombaScript.estaVivo = false;


        //Ajustamos el collider
        /*goombaCollider.size = new Vector2(1, 0.51f);
        goombaCollider.offset = new Vector2(0.06f, 0.31f);*/

        //Desactivo el collider
        goombaCollider.enabled = false;

        //Destruimos el goomba
        Destroy(goomba, 0.3f);

        //Llamamos la funcion del sonido de muerte del goomba
        sfxManager.GoombaSound();
       
    }

}
