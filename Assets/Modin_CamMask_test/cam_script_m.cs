using UnityEngine;
using System.Collections;

public class cam_script_m : MonoBehaviour
{

    public Texture2D temp_txt;
    public Texture2D temp_txt_out;
    public WebCamTexture w;

    IEnumerator Start()
    {
        //Show Authrizatton dialog box.
        yield return Application.RequestUserAuthorization(UserAuthorization.WebCam);
        //許可が出ればWebCamTextureを使用する
        if (Application.HasUserAuthorization(UserAuthorization.WebCam))
        {
            w = new WebCamTexture(480,640);
            //Materialにテクスチャを貼り付け
            //renderer.material.mainTexture = w;
            GetComponent<Renderer>().material.mainTexture = w;
            
            //再生
            w.Play();
        }
    }

    public void onClick()
    {

        Debug.Log("onClick!");//тут мы должны сохранить текстуру в temp_cam_frame

        //temp_txt = new Texture2D(320, 240);
        temp_txt = new Texture2D(w.width, w.height, TextureFormat.ARGB32, false);
        //temp_txt_out = new Texture2D(w.width, w.height, TextureFormat.ARGB32, false); //второй буфер для результата вычислений
        Color[] textureData = w.GetPixels();
        temp_txt.SetPixels(textureData);
        temp_txt.Apply();

        /*GameObject Sphere_temp = GameObject.Find("Sphere_temp");
        if (Sphere_temp)
        {
            Debug.Log("Sphere_temp_ok");
            Sphere_temp.GetComponent<Renderer>().material.mainTexture = temp_txt; //перезаписать во вторую текстуру 

        }*/
       
        GameObject Plane_temp = GameObject.Find("Plane_WEBCAM");
        if (Plane_temp)
        {
            Debug.Log("Plane_WEBCAM_ok");
            Plane_temp.GetComponent<Renderer>().material.SetTexture("_CamTempTex", temp_txt); 

        }
        
        
    }

    void Update()
    {
        //тут нужно извлечь актуальные пиксели из Color[] textureData = w.GetPixels(); //не надо уже.
        
    }

    /* схема шейдера для плейна -
     * вход - 
     * текстура из камеры. как есть
     * временная текстура обновляется кликом
     * текстура из второй камеры
     * операции - 
     * сравнить пиксель из основной камеры и базового кадра, полученный результат в диапазоне -255 0 255 привести к беззнаковому 0 - 255
     * игнорить диапазон 0-20
     * полученную карту сгладить, инвертировать. 255 должен преобладать. 
     * в слой рендеркамеры в пиксель записать альфу из полученного флоат значения
     
     
     
     */


}
