using UnityEngine;
using System.Collections;

// Cartoon FX  - (c) 2015 Jean Moreno

// Automatically destructs an object when it has stopped emitting particles and when they have all disappeared from the screen.
// Check is performed every 0.5 seconds to not query the particle system's state every frame.
// (only deactivates the object if the OnlyDeactivate flag is set, automatically used with CFX Spawn System)

[RequireComponent(typeof(ParticleSystem))]
public class CFXGame1 : MonoBehaviour
{
	// If true, deactivate the object instead of destroying it
	public bool OnlyDeactivate;
	public static int QuantityEffect;
    public static int AllEffect;
    int numEffect;
    public static int destroyEffect;
	void OnEnable()
	{
		StartCoroutine("CheckIfAlive");
        AllEffect++;
		numEffect = AllEffect;

    }
	
	IEnumerator CheckIfAlive ()
	{
		ParticleSystem ps = this.GetComponent<ParticleSystem>();
		
		while(true && ps != null)
		{
			yield return new WaitForSeconds(0.5f);
			if(!ps.IsAlive(true))
			{
				if (QuantityEffect >= 12)
				{
                    if (numEffect == destroyEffect)
					{
						QuantityEffect--;
                        destroyEffect++;
                        GameObject.Destroy(this.gameObject);
                    }


                }
				if(OnlyDeactivate)
				{
					#if UNITY_3_5
						this.gameObject.SetActiveRecursively(false);
					#else
						this.gameObject.SetActive(false);
					#endif
				}
				else
				{
                    QuantityEffect--;
					GameObject.Destroy(this.gameObject);
                }
					
				break;
			}
		}
	}
}
