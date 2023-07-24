using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Red_bullet : Red
{
    //총알의 종류, 지금은 임시로 int 형으로 선언
    public int Bullet_type;

    //각각 총알의 공격력, 체력, 이동속도 
    public float Bullet_dmg;

    public float Bullet_hp;

    public float Bullet_speed;

    //탄퍼짐 정도를 랜덤으로 돌린 것을 저장할 변수
    private float Spread;
    
    //Rigidbody 2d component를 받을 변수
    private Rigidbody2D Rb2;

    //탱크 Red의 정보를 받을 변수
    public GameObject Red;

    //벡터 회전을 위해 Vector3, Vector2를 저장할 변수
    private Vector2 vector_2;

    private Vector3 vector_3;



    // Start is called before the first frame update
    void Start()
    {
        //rigidbody 2d 가져오기
        Rb2 = gameObject.GetComponent<Rigidbody2D>();

        //Red 라는 이름의 GameObject 가져오기
        Red = GameObject.Find("Red");


         

        Tank_gun_vec =  (Vector2)transform.position - (Vector2)Red.transform.position;

        print(Tank_gun_vec);

        //탄퍼짐 정도 랜덤 생성
        Spread = Random.Range(-Spread_bullet, Spread_bullet);

        vector_3 = Quaternion.AngleAxis(Spread, new Vector3(0, 0, 1)) * Tank_gun_vec;

        vector_2 = (Vector2) vector_3;


    }

    // Update is called once per frame
    void Update()
    {
        

        Rb2.velocity = vector_2.normalized * Bullet_speed;


    }
}
