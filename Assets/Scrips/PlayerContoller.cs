using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerContoller : MonoBehaviour
{
    
    public GameObject Projectile;

    public float fireDelay = 2f;

    private float timeSinceLastFire = 0f;

    public float playerSpeed = 0.1f;


    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
     
        //Axis (controles)

        //-1 <-- 0 --> 1 
        float VerticalMovement = Input.GetAxis("Vertical");
        float HorizontalMovement = Input.GetAxis("Horizontal");

        if(VerticalMovement != 0f || HorizontalMovement != 0f) {
            Vector2 newPosition = new Vector2(HorizontalMovement * playerSpeed, VerticalMovement * playerSpeed); 
            transform.Translate(newPosition); 

        }
        //agregar tiempo del ultimo frame al timepo trasncurrido 
        timeSinceLastFire += Time.deltaTime;
        //se puede disparar si ya paso el tiempo definido
        if(timeSinceLastFire >= fireDelay){
            //can shoot
            //if(Input.GetKeyDown(KeyCode.Space)){
            if(Input.GetButton("Fire1")){
            Debug.Log("PEW");

            Instantiate(Projectile, transform.position + new Vector3(0f, 1f, 0f), transform.rotation);
            timeSinceLastFire = 0f;
            Projectile.GetComponent<Projectile>().damangebleTargetTag = "Enemy";

            timeSinceLastFire = 0f;
            
        }
            
        }
       
        
        
    }
}
