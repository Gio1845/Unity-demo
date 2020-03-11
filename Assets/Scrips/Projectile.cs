using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float projectileSpeed = 0.7f;

    

    public int maxYposition = 100;
    public int minYposition = 100;

    public string damagebleTartgetTag = "";
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(new Vector2(0f, projectileSpeed));
        if (transform.position.y > maxYposition || transform.position.y < minYposition)
        {
            Destroy(gameObject);
        }
        
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if (other.gameObject.tag == damagebleTartgetTag){
            Stats enemyStats = other.gameObject.GetComponent<Stats>();

            enemyStats.OnHit();

        }
    }
}
