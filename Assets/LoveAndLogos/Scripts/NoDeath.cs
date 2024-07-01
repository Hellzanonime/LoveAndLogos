using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace LoveAndLogos
{
    public class NoDeath : MonoBehaviour
    {
        private static NoDeath instance = null;
        public static NoDeath GetInstance() => instance;
        private void Awake()
        {
            if (instance != null && instance != this)
            {
                Destroy(gameObject);
            }
            else
            {
                instance = this;
                DontDestroyOnLoad(this);
            }
        }
        // Start is called before the first frame update
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
