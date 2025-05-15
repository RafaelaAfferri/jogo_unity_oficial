using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.SceneManagement;

public class TilemapDoorController : MonoBehaviour
{
    public Tilemap[] doorTilemaps;
    public TileBase closedDoorTile;
    public TileBase openDoorTile;
    public string[] requiredPuzzles;
    public float openDistance = 3f;
    public float enterDistance = 1f;
    public string nextScene;

    private Transform player;
    public bool doorOpened;
    private bool progressUnlocked;
    private List<(Tilemap tilemap, Vector3Int pos)> doorTilesList = new List<(Tilemap, Vector3Int)>();

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player")?.transform;
        progressUnlocked = PuzzleProgressManager.Instance.AllSolved(requiredPuzzles);

        foreach (var tmap in doorTilemaps)
        {
            var bounds = tmap.cellBounds;
            foreach (var cellPos in bounds.allPositionsWithin)
                if (tmap.GetTile(cellPos) == closedDoorTile)
                    doorTilesList.Add((tmap, cellPos));
        }
    }

    void Update()
    {
        if (!progressUnlocked || player == null) return;

        float dist = Vector2.Distance(player.position, transform.position);

        if (!doorOpened && dist <= openDistance)
        {
            foreach (var entry in doorTilesList)
                entry.tilemap.SetTile(entry.pos, openDoorTile);

            doorOpened = true;
        }

        if (doorOpened && dist <= enterDistance)
        {
            SceneFader.Instance.FadeToScene(nextScene);
            enabled = false;
        }
    }
}