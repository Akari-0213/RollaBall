using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Bomb : MonoBehaviour
{
    public ParticleSystem explosionParticle;
    

    // Update is called once per frame
    void Update()
    {
        
        if(transform.position.y <= -5){
            Destroy(gameObject);
        }
    }
    private void  OnCollisionEnter(Collision hit)
    {
        if(hit.gameObject.CompareTag("Ground")){
            Destroy(gameObject);
            explosionParticle.Play();
        

        }else if (hit.gameObject.CompareTag("Player")){

            Destroy(gameObject);
            explosionParticle.Play();
             //現在のシーン番号を取得
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            //現在のシーンをリセットする
            SceneManager.LoadScene(sceneIndex);
        }
    }
   
}
