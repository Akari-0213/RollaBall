using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public float speed = 20;
    private Rigidbody rb;
    public Text ScoreText;
    public Text winText;

    public bool gameOver;

    private int score;
    public ParticleSystem explosionParticle;
    
    // Start is called before the first frame update
    void Start()
    {
        //Rigidbodyを取得
       rb = GetComponent<Rigidbody>();

        //UIを初期化
        score = 0;
        SetCountText();
        winText.text = "";

        gameOver = false;

       
        
    }

    // Update is called once per frame
    void Update()
    {
        //カーソルキーの入力を取得
        var moveHorizontal = Input.GetAxis("Horizontal");
        var moveVertical = Input.GetAxis("Vertical");

        //カーソルキーの入力に合わせて移動方向を設定
        var movement = new Vector3(moveHorizontal,0,moveVertical);

        //Rigidbodyに力を与えて玉を動かす
        rb.AddForce(movement * speed);



    }

    private void OnTriggerEnter(Collider other)
    {
        //ぶつかったオブジェクトが収集アイテムだった場合
        if (other.gameObject.CompareTag("Pick Up"))
        {
            //その収集アイテムを非表示にします
            other.gameObject.SetActive(false);

            //スコアを加算します
            score = score + 1;

            //UIの表示を更新
            SetCountText();
        }
        
    }

    private void SetCountText()
    {
        //スコアの表示を更新
        ScoreText.text = "Count:" + score.ToString();

        //全ての収集アイテムを獲得した場合
        if(score >= 6)
        {
            //リザルトの表示を更新
            winText.text = "CLEAR!";
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        //DangerWallにぶつかったら爆発する→ゲームオーバー
        if(collision.gameObject.CompareTag("Danger")){
           Debug.Log("衝突が検知されました");
           explosionParticle.Play();
           gameOver = true;
        }
           
    }

    
}
