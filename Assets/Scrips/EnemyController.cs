using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float fireDelay = 1f;

    private float maxPositionX;
    private float minPositionX;

    private bool movingRight = true;

    public float movementSpeed = 1f;
    // Start is called before the first frame update
    void Start()
    {
        //tamaño pantalla
        //Screen.width

        //tamaño nave
       SpriteRenderer sr = GetComponent<SpriteRenderer>();
       float spriteWidth = sr.sprite.rect.width;

       maxPositionX = Camera.current.pixelRect.width - (spriteWidth / 2);
       minPositionX = 0 + (spriteWidth / 2);
    }

    // Update is called once per frame
    void Update()
    {
        if(movingRight){
            //move rigth
            transform.Translate(new Vector2(movementSpeed, 0f));
            //revisar si llega al limite superior en x permitido
            if(transform.position.x >= maxPositionX){
                //ahora se debe mover a la izquierda
                movingRight=false;
            }
        }else{
            //move left
            transform.Translate(new Vector2(-movementSpeed, 0f));
            if(transform.position.x <= minPositionX){
                //ahora se debe mover a la derecha
                movingRight=true;
            }
        }
    }
}
