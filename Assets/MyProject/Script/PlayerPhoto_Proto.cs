using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerPhoto_Proto : MonoBehaviour
{
    // Start is called before the first frame update
    bool isSetCamera;
    [SerializeField] Camera _camera;
    [SerializeField] GameObject CameraPhone;
    [SerializeField] RenderTexture CameraTexture;

    [SerializeField] RawImage PhotoImage;
    void Start()
    {
        isSetCamera = false;
        CameraPhone.SetActive(isSetCamera);
        PhotoImage.gameObject.SetActive(false);
    }

    public void CameraSet()
    {
        isSetCamera = !isSetCamera;
        CameraPhone.SetActive(isSetCamera);
    }
    public void CameraShot()
    {
        if (!isSetCamera) return;
        StartCoroutine(Save(_camera, new Vector2Int(1920, 1080), Application.dataPath + "/" + "test.png"));
    }

    // カメラ映像を保存
    public IEnumerator Save(Camera camera, Vector2Int size, string savePath)
    {
        // 今のフレームでのカメラのレンダリングを待つ
        yield return new WaitForEndOfFrame();

        var renderTexture = new RenderTexture(size.x, size.y, 0);
        camera.targetTexture = renderTexture;

        // カメラの描画をテクスチャーに書き込み
        camera.Render();
        // 現在のアクティブなRenderTextuerをキャッシュ
        var cache = RenderTexture.active;
        // Pixel情報を読み込むためにアクティブに指定
        RenderTexture.active = renderTexture;
        var texture = new Texture2D(size.x, size.y, TextureFormat.RGB24, false);
        // RenderTexture.activeから読み込み
        texture.ReadPixels(new Rect(0, 0, size.x, size.y), 0, 0);
        // テクスチャの保存
        texture.Apply();

        try
        {
            System.IO.File.WriteAllBytes(savePath, texture.EncodeToPNG());
        }
        catch
        {
            Debug.Log("Error");
        }

        RenderTexture.active = cache;
        camera.targetTexture = CameraTexture;
        Destroy(renderTexture);
        PhotoImage.texture = texture;
        PhotoImage.gameObject.SetActive(true);
        // カーソルを画面内で動かせる
        Cursor.lockState = CursorLockMode.Confined;
        // カーソル表示
        Cursor.visible = true;
        yield return null;
    }
}
