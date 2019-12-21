using UnityEngine;
using System.Collections;

public class FluidSource : MonoBehaviour {		
	public float Interval = 0.025f;
	public Vector3 ParticleForce;
	public Transform ParticleParent;

	private float _lastSpawnTime = float.MinValue;

	void Start()
    {

    }

	void Update()
    {
        if (_lastSpawnTime + Interval < Time.time)
        {
            GameObject newLiquidParticle =(GameObject)Instantiate(Resources.Load("Prefabs/FluidParticle"));
			newLiquidParticle.GetComponent<Rigidbody2D>().AddForce(ParticleForce);

			//FluidParticle particleScript=newLiquidParticle.GetComponent<FluidParticle>();
            //particleScript.ParticleLifeTime = 3;

			newLiquidParticle.transform.position = transform.position;
			newLiquidParticle.transform.SetParent(ParticleParent);
            _lastSpawnTime = Time.time;
		}		
	}
}
