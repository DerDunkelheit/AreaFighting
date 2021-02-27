using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.Tilemaps;

namespace Controllers
{
    public class AreaController : BaseGamerController
    {
        [SerializeField] private Grid grid = null;
        [SerializeField] private Tilemap collisionMap = null;
        [SerializeField] private NavMeshSurface2d surface2d = null;

        private Camera mainCamera;
        private Coroutine bakeRoutine;

        private void Awake()
        {
            mainCamera = Camera.main;
        }

        //an example how to bake navMesh in runtime.
        private void Start()
        {
            surface2d.BuildNavMesh();
        }

        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Vector3Int pos = grid.WorldToCell(mainCamera.ScreenToWorldPoint(Input.mousePosition));
                var tile = collisionMap.GetTile(pos);
                if (tile != null)
                {
                    collisionMap.SetTile(pos, null);
                    TriggerBake();
                }
            }
        }

        //This was made because bake is faster then tile updates.
        private void TriggerBake()
        {
            if (bakeRoutine != null)
            {
                StopCoroutine(bakeRoutine);
            }

            bakeRoutine = StartCoroutine(BakeSurfaceRoutine());
        }

        private IEnumerator BakeSurfaceRoutine()
        {
            yield return new WaitForSeconds(0.1f);
            surface2d.BuildNavMesh();
        }
    }
}