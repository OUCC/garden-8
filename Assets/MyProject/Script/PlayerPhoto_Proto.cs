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

    // �J�����f����ۑ�
    public IEnumerator Save(Camera camera, Vector2Int size, string savePath)
    {
        // ���̃t���[���ł̃J�����̃����_�����O��҂�
        yield return new WaitForEndOfFrame();

        var renderTexture = new RenderTexture(size.x, size.y, 0);
        camera.targetTexture = renderTexture;

        // �J�����̕`����e�N�X�`���[�ɏ�������
        camera.Render();
        // ���݂̃A�N�e�B�u��RenderTextuer���L���b�V��
        var cache = RenderTexture.active;
        // Pixel����ǂݍ��ނ��߂ɃA�N�e�B�u�Ɏw��
        RenderTexture.active = renderTexture;
        var texture = new Texture2D(size.x, size.y, TextureFormat.RGB24, false);
        // RenderTexture.active����ǂݍ���
        texture.ReadPixels(new Rect(0, 0, size.x, size.y), 0, 0);
        // �e�N�X�`���̕ۑ�
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
        // �J�[�\������ʓ��œ�������
        Cursor.lockState = CursorLockMode.Confined;
        // �J�[�\���\��
        Cursor.visible = true;
        yield return null;
    }
}
