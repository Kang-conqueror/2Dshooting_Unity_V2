using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Green : Player_control
{
    // Start is called before the first frame update
    void Start()
    {
         //게임 시작 시, rigidbody 2d component 받아오기
        R_b2 = gameObject.GetComponent<Rigidbody2D>();

        //시작 시 main camera 받기
        Cam = Camera.main;
        
    }

    // Update is called once per frame
    void Update()
    {
        Move_vector = new Vector3(Input.GetAxisRaw("Horizontal"), 0f, Input.GetAxisRaw("Vertical"));
        R_b2.velocity = Move_vector.normalized * Player_speed;

        //Mouse의 좌표 받아오기
        Mouse_pos = Cam.ScreenToWorldPoint(Input.mousePosition);

        //Mouse 좌표에서 자신의 좌표 빼서 벡터값 구하기
        Angle2 = Mouse_pos - (Vector2)transform.position;
    }

    //충돌 판정
    private void OnTriggerEnter2D(Collider2D other) {
        
    }






}
