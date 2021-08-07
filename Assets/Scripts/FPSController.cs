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

    //入力に合わせてプレイヤーの位置を変更していく


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    //Updateは毎フレーム呼ばれるがFixedUpdateは0.02秒毎に呼ばれる。

    {
        x = 0;
        z = 0;

        x = Input.GetAxisRaw("Horizontal") * speed;
        z = Input.GetAxisRaw("Vertical") * speed;

        //Input.GetAxisRawはキーボードに入力されてる値をxとzに入れる。
        //Horizontalは水平(横),Vertical垂直(縦)

        transform.position += new Vector3(x,0,z);
    }
}
