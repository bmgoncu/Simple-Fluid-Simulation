using UnityEngine;
using System.Collections;

public class FluidParticle : MonoBehaviour {
    public Rigidbody2D RigidBody;
    public GameObject CurrentImage;
	public float ParticleLifeTime = 2.0f;
	private float _startTime = 0;


    private void Awake(){
        RigidBody = GetComponent<Rigidbody2D>();
        RigidBody.gravityScale = 1.0f;        
        _startTime = Time.time;
        RigidBody.velocity = new Vector2();   
        CurrentImage.SetActive(true);
    }

    private void Update ()
    {
        Vector3 velocityScale = new Vector3(1.0f, 1.0f, 1.0f);
        velocityScale.x += Mathf.Abs(RigidBody.velocity.x) / 30.0f;
        velocityScale.z += Mathf.Abs(RigidBody.velocity.y) / 30.0f;
        velocityScale.y = 1.0f;
        CurrentImage.transform.localScale = velocityScale;

        float scaleValue = 1.0f - ((Time.time - _startTime) / ParticleLifeTime);
        Vector2 scale = Vector2.one;
        if (scaleValue <= 0)
        {
            Destroy(gameObject);
        }
        else
        {
            scale.x = scaleValue;
            scale.y = scaleValue;
            transform.localScale = scale;
        }
    }
    
	void OnCollisionEnter2D(Collision2D other){
		// color change logic, doTween color gradient or shader wizdry here
	}
	
}
