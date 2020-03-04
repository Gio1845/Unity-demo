using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float fireDelay = 1f;

    private float maxPositionX = 1f;
    private float minPositionX= 0f;

    private bool movingRight = true;

    public float movementSpeed = 0.1f;
    // Start is called before the first frame update
    void Start()
    {
      
    }

    // Update is called once per frame
    void Update()
    {
        var pos = Camera.main.WorldToViewportPoint(transform.position);
        pos.x = Mathf.Clamp01(pos.x);
        pos.y = Mathf.Clamp01(pos.y);

        if(movingRight) {
            //move rigth
            transform.Translate(new Vector2(-movementSpeed, 0f));
            //revisar si llega al limite superior en x permitido
            if(pos.x >= maxPositionX){
                //ahora se debe mover a la izquierda
                movingRight = false;
            }
        }
        else{
            //move left
            transform.Translate(new Vector2(movementSpeed, 0f));
            if(pos.x <= minPositionX){
                //ahora se debe mover a la derecha
                movingRight=true;
            }
        }
    }
}
