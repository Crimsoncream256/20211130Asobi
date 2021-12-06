using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EneCannonController : MonoBehaviour
{
    public GameObject muzzlePoint; // 弾を発射する場所
    public GameObject ball; // 再セットする弾のオブジェクト
    public float speed = 30f; // 弾のスピード
    private int attackTime = 0; // 弾の発射までのカウント
    public int intvalTime = 30; // 弾の発射する間隔



    public void EneCannonShot()
    {
        Vector3 mballPos = muzzlePoint.transform.position;
        GameObject newBall = Instantiate(ball, mballPos, transform.rotation);
        //muzzlePointの位置に、instantiateで「ball」Prefabオブジェクトを出現させます
        Vector3 dir = newBall.transform.forward;
        //出現したボールのforward（ｚ軸）方向を読みこみます（*muzzlePointがz軸方向を向いているなら、それでも可）
        newBall.GetComponent<Rigidbody>().AddForce(dir * speed, ForceMode.Impulse);
        //弾の発射方向にnewBallのｚ方向（ローカル座標）を入れ、弾オブジェクトのrigidbodyに衝撃力を加えます
        newBall.name = ball.name;
        Destroy(newBall, 0.8f); //newBallの名前をballの名に変えて、0.8秒後にnewBallオブジェクトを消します
    }

    void Update()
    {
        attackTime += 1;
        if (attackTime % intvalTime == 0)
        {
            EneCannonShot();
        }
    }

}
