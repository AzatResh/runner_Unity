using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] Vector2 MaxMinSpeed;

    [SerializeField] GameObject particle;

    void Start(){
        speed = Mathf.Lerp(MaxMinSpeed.x, MaxMinSpeed.y, Difficulty.GetDifficulty());
    }    
    void Update()
    {
        transform.Translate(Vector2.left*speed*Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player"){
            other.GetComponent<PlayerStats>().TakeDamage();
            Instantiate(particle, (transform.position+other.transform.position)/2, Quaternion.identity);
            Destroy(gameObject);
        }

        else if(other.tag == "Destroy"){
            Destroy(gameObject);
        }
    }
}
