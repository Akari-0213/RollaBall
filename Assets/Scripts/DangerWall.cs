using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class DangerWallController : MonoBehaviour
{
    private float speed = 5.0f;
    private bool flag;
    float x;
    public ParticleSystem  explosionParticle;
    // Start is called before the first frame update
    
       

    // Update is called once per frame
    void Update()
    {
        if (transform.position.z >= 5)
            flag = true;
        else if (transform.position.z <= 0)
            flag = false;

        if (flag)
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3((float)4.52, (float)0.5, 0), speed * Time.deltaTime);
        else if (!flag)
            transform.position =
                Vector3.MoveTowards(transform.position, new Vector3((float)4.52, (float)0.5, 5), speed * Time.deltaTime);

        x += Time.deltaTime * 10;
        transform.rotation = Quaternion.Euler(x, 0, 0);

    }
    void OnCollisionEnter(Collision hit)
    {
        //接触したオブジェクトのタグが”Player”の場合
        if (hit.gameObject.CompareTag("Player"))
        {
            
            
            //現在のシーン番号を取得
            int sceneIndex = SceneManager.GetActiveScene().buildIndex;
            //現在のシーンをリセットする
            SceneManager.LoadScene(sceneIndex);
        }
    }
}
