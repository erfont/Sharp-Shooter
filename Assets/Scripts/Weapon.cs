using StarterAssets;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    StarterAssetsInputs starterAssetsInput;

    void Awake()
    {
        starterAssetsInput = GetComponentInParent<StarterAssetsInputs>();
    }

    // Update is called once per frame
    void Update()
    {       

       if (starterAssetsInput.shoot)
        {
            RaycastHit hit;
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, Mathf.Infinity))
            {
                Debug.Log(hit.collider.name); 
                
            }

            starterAssetsInput.ShootInput(false);
        }

    }
}
