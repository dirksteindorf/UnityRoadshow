using UnityEngine;
using System.Collections;

public class SpecialEffects : Singleton<SpecialEffects>
{
	public void create(ParticleSystem effect, Vector3 position)
	{
		ParticleSystem newParticleSystem = Instantiate(effect, position, Quaternion.identity) as ParticleSystem;
		Destroy(newParticleSystem.gameObject, newParticleSystem.startLifetime);
	}
}
