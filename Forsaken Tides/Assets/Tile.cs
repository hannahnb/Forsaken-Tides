using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile : MonoBehaviour
{
    [SerializeField] private Color baseColor, offsetColor;
    [SerializeField] private SpriteRenderer _renderer;
    [SerializeField] private GameObject highlight;
    [SerializeField] private Transform cam;
    Grid grid;
    bool isZoomed = false;
    public string Terrain;
    public void Init(int type) {
        if(type != 0) {
            _renderer.color = new Color(0,0,0.8f,1f);
            Terrain = "Land";
        } else {
            _renderer.color = new Color(0.5f,0.5f,0,1f);
            Terrain = "Sea";
        }
        grid = GameObject.Find("Grid").GetComponent<Grid>();
    }

    void OnMouseEnter() {
        highlight.SetActive(true);
    }

    void OnMouseExit() {
        highlight.SetActive(false);
    }

    void OnMouseDown() {
        Vector3 oldPos = cam.transform.position;
        if (!isZoomed) {
            Vector3 mousePos3 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos = new Vector2((mousePos3.x), (mousePos3.y));
            Vector2 tilePos = new Vector2((float)((int)mousePos.x), (float)((int)mousePos.y));
            //Tile curTile = grid.GetTileAtPosition(tilePos);
            //Debug.Log(curTile.Terrain);
            isZoomed = true;
            oldPos = cam.transform.position;
            cam.transform.position = new Vector3(mousePos.x, mousePos.y, -10);
        } else {
            cam.transform.position = new Vector3(oldPos.x, oldPos.y, -100);
            isZoomed = false;
        }
    }
}
