using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	Rigidbody2D rigid2D;
	Animator animator;
	float jumpForce = 680.0f;
	float walkForce = 30.0f;
	float maxWalkSpeed = 2.0f;

	// Use this for initialization
	void Start () {
		this.rigid2D = GetComponent<Rigidbody2D>();
		this.animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		//jump
		if (Input.GetKeyDown(KeyCode.Space))
		{
			this.rigid2D.AddForce(transform.up * this.jumpForce);
		}

		//左右移動
		int key = 0;
		if (Input.GetKey(KeyCode.RightArrow)) key = 1;
		if (Input.GetKey(KeyCode.LeftArrow)) key = -1;

		float speedx = Mathf.Abs(this.rigid2D.velocity.x);

		//スピード制限
		if (speedx < this.maxWalkSpeed)
		{
			this.rigid2D.AddForce(transform.right * key * this.walkForce);
		}


		//動く方向に応じて反転
		if(key != 0)
		{
			transform.localScale = new Vector3(key, 1, 1);
		}

		//プレイヤの速度に応じてアニメーション速度を変える
		this.animator.speed = speedx / 2.0f;

	}
}
