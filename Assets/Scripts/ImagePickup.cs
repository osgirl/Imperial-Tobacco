using UnityEngine;
using System;
using System.Collections;
using jp.nyatla.nyartoolkit.cs.markersystem;
using jp.nyatla.nyartoolkit.cs.core;
using NyARUnityUtils;
using System.IO;
/// <summary>
/// このサンプルプログラムは、マーカ表面の画像をテクスチャとして取得します。
/// マーカファイルには、hiroマーカを使用してください。
/// </summary>
public class ImagePickup : MonoBehaviour
{
	private NyARUnityMarkerSystem _ms;
	private NyARUnityWebCam _ss;
	private int mid;//marker id
	private GameObject _bg_panel;
    public GameObject Box;
	void Awake()
	{
		//setup unity webcam
		WebCamDevice[] devices= WebCamTexture.devices;
		if (devices.Length <= 0){
			Debug.LogError("No Webcam.");
			return;
		}
		WebCamTexture w=new WebCamTexture(1280,720,15);
		//Make WebcamTexture wrapped Sensor.
		this._ss=NyARUnityWebCam.createInstance(w);
		//Make configulation by Sensor size.
		NyARMarkerSystemConfig config = new NyARMarkerSystemConfig(this._ss.width,this._ss.height);

		this._ms=new NyARUnityMarkerSystem(config);
		mid=this._ms.addARMarker(
			new StreamReader(new MemoryStream(((TextAsset)Resources.Load("patt.clock", typeof(TextAsset))).bytes)),
			16,25,80);
		//setup background
		this._bg_panel=GameObject.Find("Plane");
        this._bg_panel.GetComponent<Renderer>().material.mainTexture = w;
		this._ms.setARBackgroundTransform(this._bg_panel.transform);
		
		//setup camera projection
        this._ms.setARCameraProjection(this.GetComponent<Camera>());
//        GameObject.Find("Cube").GetComponent<Renderer>().material.mainTexture = new Texture2D(64, 64);
	}	
	// Use this for initialization
	void Start ()
	{
		this._ss.start();
	}
	// Update is called once per frame
	void Update ()
	{
		//Update marker system by ss
		this._ss.update();
		this._ms.update(this._ss);
		//update Gameobject transform
		if(this._ms.isExistMarker(mid)){
            Vector3 pos = new Vector3();
            _ms.getMarkerPlanePos(mid, 0, 0, ref pos);
//            GameObject b =  Instantiate(Box);
////            b.transform.parent = _bg_panel.transform;
//            b.transform.position = _bg_panel.transform.position + pos;
            Debug.Log(pos);
			this._ms.setMarkerTransform(mid,GameObject.Find("MarkerObject").transform);
			//update cube texture
//            this._ms.getMarkerPlaneImage(mid, this._ss, -40, -40, 80, 80, (Texture2D)(GameObject.Find("watch").GetComponent<Renderer>().material.mainTexture));
		}else{
			// hide Game object
			GameObject.Find("MarkerObject").transform.localPosition=new Vector3(0,0,-100);
		}
	}
}
