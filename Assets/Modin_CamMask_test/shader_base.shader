Shader "Custom/shader_base" {
	Properties {
		//_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {} //CameraStreamTex

		//_Glossiness ("Smoothness", Range(0,1)) = 0.5

		//_Metallic ("Metallic", Range(0,1)) = 0.0


		//_CamStreamTex ("CameraStreamTex (RGB)", 2D) = "white" {}
		_CamTempTex ("CameraStaticTex (временное изображение) (RGB)", 2D) = "white" {}
		_VirtCamRenderTex ("Virtual Cam Render (RGBA)", 2D) = "white" {}
		_CutNumH ("Cut Hlevel", Range(0,1)) = 1.00
		_CutNumL ("Cut Llevel", Range(-1,0)) = -0.25
		_Multipler ("Multipler", Range(0,20)) = 1
		_ClipAMin ("ClipL", Range(0,1)) = 0.0
		_ClipAMax ("ClipH", Range(0,1)) = 1.0

	}
	SubShader {
		//Tags { "RenderType"="Transparent" }
		Tags {"Queue"="Transparent" "IgnoreProjector"="True" "RenderType"="Transparent"}
		LOD 200
		
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types
		//#pragma surface surf Standard fullforwardshadows
		#pragma surface surf Standard alpha

		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _CamTempTex;
		sampler2D _VirtCamRenderTex;
		float _CutNumH;
		float _CutNumL;
		float _Multipler;
		float _ClipAMin;
		float _ClipAMax;


		struct Input {
			float2 uv_MainTex;
		};

		//half _Glossiness;
		//half _Metallic;
		//fixed4 _Color;

		void surf (Input IN, inout SurfaceOutputStandard o) { //конечный вывод
			// Albedo comes from a texture tinted by color
			//fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color; //original shader
			//fixed4 c = tex2D (_MainTex, IN.uv_MainTex) - tex2D (_VirtCamRenderTex, IN.uv_MainTex);
			//fixed4 c = ( ( 1 - _BlendAlpha ) * tex2D( _MainTex, IN.uv_MainTex ) + _BlendAlpha * tex2D( _BlendTex, IN.uv_MainTex ) ) * _Color;
			fixed4 t1 = tex2D(_MainTex, IN.uv_MainTex);
			fixed4 t2 = tex2D (_VirtCamRenderTex, IN.uv_MainTex);
			fixed4 t3 = tex2D(_CamTempTex, IN.uv_MainTex);

			//half4 texcol = tex2D (_MainTex, IN.uv_MainTex);
			//fixed4 c2 = dot(texcol.rgb, float3(0.3, 0.59, 0.11));

			//задача - сравнить текстуру камеры с временной текстурой, результат отправить в лерп.3
			// как вариант t3.r - t1.r = разница
			// clamp(x, a, b) Если x < a, то возвращает а, если x > b, то возвращает b, иначе возвращает x.

			float _r = clamp((t3.r - t1.r), _CutNumL, 0)*-1 + clamp((t3.r - t1.r), 0, _CutNumH);
			//_r += clamp((t3.r - t1.r), 0, 1);
			float _g = clamp((t3.g - t1.g), _CutNumL, 0)*-1 + clamp((t3.g - t1.g), 0, _CutNumH);
			float _b = clamp((t3.b - t1.b), _CutNumL, 0)*-1 + clamp((t3.b - t1.b), 0, _CutNumH);

			//o.Albedo.r = ((_r+_g+_b)*255);
			//o.Albedo.r = 1;
			//o.Albedo.g = 1;
			//o.Albedo.b = 1;
			//o.Albedo = dot((_r,_g,_b), float3(0.9, 0.9, 0.9));
			//o.Albedo = (_r,_g,_b)*255;
			//o.Albedo = clamp(x, a, b)
			//o.Albedo = c.rgba;//original shader
			//if ((t2.b+t2.r+t2.g) < 2.75){t2.a = 1;}
			
			t2.a -= (_r+_g+_b)*_Multipler;

			
			//float alp = t2.a;
			//float alp2 = t2.a - (_r*_g*_b*100);
			o.Albedo = lerp(t1, t2, clamp(t2.a,_ClipAMin,_ClipAMax) ); //на основе альфы рендер камеры отсекаем фон в конечном цвете пикселя.
			

			// Metallic and smoothness come from slider variables
			//o.Metallic = _Metallic;
			//o.Smoothness = _Glossiness;
			o.Alpha = 1; //для тестов
			//o.Alpha = ((_r)+(_g)+(_b));
			o.Emission = o.Albedo;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
