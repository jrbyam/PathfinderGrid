using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AdjustController : MonoBehaviour
{
    public GameObject grid;
    public GameObject scene;
    public Sprite gridSprite;
    public Sprite sceneSprite;
    public Sprite direction;
    public Sprite zoom;
    public Sprite show;
    public Sprite hide;
    public Sprite plus;
    public Sprite minus;
    public Sprite arrow;
    private bool controlGrid = true;
    private bool controlZoom = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow)) {
            UpArrowPressed();
        }
        if (Input.GetKeyDown(KeyCode.DownArrow)) {
            DownArrowPressed();
        }
        if (Input.GetKeyDown(KeyCode.LeftArrow)) {
            LeftArrowPressed();
        }
        if (Input.GetKeyDown(KeyCode.RightArrow)) {
            RightArrowPressed();
        }
    }

    public void ToggleObject() {
        controlGrid = !controlGrid;
        transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = controlGrid ? gridSprite : sceneSprite;
        transform.GetChild(2).gameObject.SetActive(controlGrid);
    }

    public void ToggleControl() {
        controlZoom = !controlZoom;
        transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = controlZoom ? zoom : direction;
        transform.GetChild(3).GetChild(0).gameObject.SetActive(!controlZoom);
        transform.GetChild(3).GetChild(1).gameObject.SetActive(!controlZoom);
        transform.GetChild(3).GetChild(2).GetChild(0).GetComponent<Image>().sprite = controlZoom ? plus : arrow;
        transform.GetChild(3).GetChild(3).GetChild(0).GetComponent<Image>().sprite = controlZoom ? minus : arrow;
    }

    public void ToggleShow() {
        grid.GetComponent<Image>().color = new Vector4(1f, 1f, 1f, grid.GetComponent<Image>().color.a == 0.4f ? 0.0f : 0.4f);
        transform.GetChild(2).GetChild(0).GetComponent<Image>().sprite = grid.GetComponent<Image>().color.a == 0.4f ? hide : show;
    }

    public void UpArrowPressed() {
        if (controlGrid) {
            if (controlZoom) {
                grid.GetComponent<Image>().sprite = Sprite.Create(
                    grid.GetComponent<Image>().sprite.texture, 
                    new Rect(0, 0, grid.GetComponent<Image>().sprite.texture.width, grid.GetComponent<Image>().sprite.texture.height), 
                    new Vector2(0.5f, 0.5f), 
                    grid.GetComponent<Image>().sprite.pixelsPerUnit - 5
                );
            } else {
                Vector3 location = grid.GetComponent<RectTransform>().localPosition;
                grid.GetComponent<RectTransform>().localPosition = new Vector3(location.x, location.y + 5, location.z);
            }
        } else {
            if (controlZoom) {
                Vector3 scale = scene.GetComponent<RectTransform>().localScale;
                scene.GetComponent<RectTransform>().localScale = new Vector3(scale.x + 0.1f, scale.y + 0.1f, scale.z + 0.1f);
            } else {
                Vector3 location = scene.GetComponent<RectTransform>().localPosition;
                scene.GetComponent<RectTransform>().localPosition = new Vector3(location.x, location.y + 5, location.z);
            }
        }
    }

    public void DownArrowPressed() {
        if (controlGrid) {
            if (controlZoom) {
                grid.GetComponent<Image>().sprite = Sprite.Create(
                    grid.GetComponent<Image>().sprite.texture, 
                    new Rect(0, 0, grid.GetComponent<Image>().sprite.texture.width, grid.GetComponent<Image>().sprite.texture.height), 
                    new Vector2(0.5f, 0.5f), 
                    grid.GetComponent<Image>().sprite.pixelsPerUnit + 5
                );
            } else {
                Vector3 location = grid.GetComponent<RectTransform>().localPosition;
                grid.GetComponent<RectTransform>().localPosition = new Vector3(location.x, location.y - 5, location.z);
            }
        } else {
            if (controlZoom) {
                Vector3 scale = scene.GetComponent<RectTransform>().localScale;
                scene.GetComponent<RectTransform>().localScale = new Vector3(scale.x - 0.1f, scale.y - 0.1f, scale.z - 0.1f);
            } else {
                Vector3 location = scene.GetComponent<RectTransform>().localPosition;
                scene.GetComponent<RectTransform>().localPosition = new Vector3(location.x, location.y - 5, location.z);
            }
        }
    }

    public void LeftArrowPressed() {
        if (!controlZoom) {
            if (controlGrid) {
                Vector3 location = grid.GetComponent<RectTransform>().localPosition;
                grid.GetComponent<RectTransform>().localPosition = new Vector3(location.x - 5, location.y, location.z);
            } else {
                Vector3 location = scene.GetComponent<RectTransform>().localPosition;
                scene.GetComponent<RectTransform>().localPosition = new Vector3(location.x - 5, location.y, location.z);
            }
        }
    }

    public void RightArrowPressed() {
        if (!controlZoom) {
            if (controlGrid) {
                Vector3 location = grid.GetComponent<RectTransform>().localPosition;
                grid.GetComponent<RectTransform>().localPosition = new Vector3(location.x + 5, location.y, location.z);
            } else {
                Vector3 location = scene.GetComponent<RectTransform>().localPosition;
                scene.GetComponent<RectTransform>().localPosition = new Vector3(location.x + 5, location.y, location.z);
            }
        }
    }

}
