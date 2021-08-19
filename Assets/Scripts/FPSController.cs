using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSController : MonoBehaviour
{
    //移動用の変数を作成
    float x, z;
    //変数の宣言はカンマ(,)で区切ると同じ方の変数を連続で宣言する事が可能になる

    //スピード調整用の変数を作成
    float speed = 0.1f;

    //変数の宣言
    public GameObject cam;
    //変数でカメラの取得

    Quaternion cameraRot, characterRot;
    //カメラの回転を取得
    //Quaternion(クォータ二オン)を一言で言うと「回転を表すのに使用される仕組み」
    //そしてUnityは「すべての回転を表現するのにQuaternionを内部的に使用」している
    //Rotはrotation

    float Xsensityvity = 3f, Ysensityvity = 3f;

    // Start is called before the first frame update
    void Start()
    {
        cameraRot = cam.transform.localRotation;
        characterRot = transform.localRotation;
        //ゲーム開始と同時に現在のカメラの角度を入れておく
    }

    // Update is called once per frame
    void Update()
    {
        //アップデートでマウスの入力を受け取り、その動きをカメラに反映
        float xRot = Input.GetAxis("Mouse X") * Ysensityvity;
        //水平方向の動きを取得
        float yRot = Input.GetAxis("Mouse Y") * Xsensityvity;
        //垂直方向の動きを取得

        //* Ysensityvity,* Xsensityvityは上記で用意した物を使う

        //上記のコードでマウスの動きを取得できるのでcameraRotとcharacterRotに反映
        cameraRot *= Quaternion.Euler(-yRot, 0, 0);
        characterRot *= Quaternion.Euler(0, xRot, 0);
        //Euler(オイラー)は引数にx、y、zの三つの引数を指定する必要がある。
        //なぜx軸に-yRotを入れて、y軸にxRotを入れているのかというと、xを軸にしてy回転してしまうため(横を軸にして縦回転してしまうため)逆に入れている。
        //-の理由は左右逆になっているため。

        //実際の角度を更新
        cam.transform.localRotation = cameraRot;
        //カメラの角度
        transform.localRotation = characterRot;
        //キャラクターの角度
    }

    //入力に合わせてプレイヤーの位置を変更していく
    private void FixedUpdate()
    //Updateは毎フレーム呼ばれるがFixedUpdateは0.02秒毎に呼ばれる。

    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        //Input.GetAxisRawはキーボードに入力されてる値をxとzに入れる。
        //Horizontalは水平(横),Vertical垂直(縦)

        //transform.position += new Vector3(x,0,z);

        //カメラの正面方向に進むようにコードを記述
        transform.position += cam.transform.forward * z + cam.transform.right * x;
        //forwardはカメラが向いている正面のこと
        //rightはカメラのx軸のことを指しておりright * xでxが+なのか-なのかで左右が変わる
        //このコードでカメラの向いている方にキャラクターが動くようになる

    }
}
