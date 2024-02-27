using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace MyAssets
{
    public class ExplosiveSphere : MonoBehaviour
    {
        public GameObject lava;

        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (IsTouchingLava())
            {
                Destroy(gameObject);
            }
        }

        bool IsTouchingLava()
        {
            return transform.position.y < 1f;
        }
    }
}