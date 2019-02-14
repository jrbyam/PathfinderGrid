using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using UnityEngine.UI;

public class ImageController : MonoBehaviour
{
    private int idx = -1;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(UpdateSceneImage());
        GetComponent<Image>().preserveAspect = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab)) {
            StartCoroutine(UpdateSceneImage());
        }
    }

    private IEnumerator UpdateSceneImage() {
        idx++;
        FileInfo[] images = new DirectoryInfo(Application.streamingAssetsPath).GetFiles("*.png");
        if (idx == images.Length) idx = 0;
        GetComponent<Image>().sprite = Resources.Load<Sprite>(images[idx].FullName);

        string path = "file://" + images[idx].FullName;
        WWW textureFile = new WWW(path);
    
        yield return textureFile;
    
        GetComponent<Image>().sprite = Sprite.Create(
            textureFile.texture as Texture2D, 
            new Rect(0, 0, textureFile.texture.width, textureFile.texture.height), 
            Vector2.zero
        );
    }
}
