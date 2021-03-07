using System.Collections.Generic;
using Config;
using UnityEngine;

namespace Controllers
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager instance;
        public static ResourcesProvider resourcesProvider;
        public static UiController uiController;

        public GameConfig gameConfig;

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

            resourcesProvider = this.GetComponentInChildren<ResourcesProvider>();

            controllers = new List<BaseGamerController>(this.GetComponents<BaseGamerController>());
            uiController = this.GetComponent<UiController>();
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
