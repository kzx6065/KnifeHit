using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Knife : MonoBehaviour
{
    public new Rigidbody2D rigidbody2D;
    public Vector2 force = new Vector2(0, 20f);
    void Start()
    {
        print("Start");
        rigidbody2D = GetComponent<Rigidbody2D>();
        rigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        rigidbody2D.AddForce(force, ForceMode2D.Impulse);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        var tr = transform;
        var tag = collision.gameObject.tag;
        switch (tag)
        {
            case "GameBoard":
                //보드에 칼이 꽂힌 연출
                tr.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                tr.SetParent(collision.transform); //칼의 부모를 GameBoard로 설정.
                break;
            case "Apple":
                //보드에 칼이 꽂힌 연출
                //점수 증가.
                break;
            case "Knife":
                //칼이 튕겨나가게 하기
                break;
        }
    }

}
