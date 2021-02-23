using System;
using System.Collections.Generic;
using UnityEngine;

namespace Controllers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;

        private List<BaseGamerController> controllers;

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else
            {
                Destroy(this.gameObject);
            }
            
            controllers = new List<BaseGamerController>(this.GetComponents<BaseGamerController>());
            InitAllControllers();
        }

        private void InitAllControllers()
        {
            foreach (var controller in controllers)
            {
                controller.Init(this);
            }
        }
    }
}
