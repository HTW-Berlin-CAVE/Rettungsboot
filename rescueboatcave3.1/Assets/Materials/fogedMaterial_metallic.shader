// Upgrade NOTE: upgraded instancing buffer 'Props' to new syntax.

// Upgrade NOTE: replaced '_Object2World' with 'unity_ObjectToWorld'

// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

Shader "Custom/fogedMaterial_metallic" {
	Properties 
	{
		_Color ("Color", Color) = (1,1,1,1)
		_MainTex ("Albedo (RGB)", 2D) = "white" {}
		_BumpMap ("Bumpmap", 2D) = "bump" {}
		_Glossiness ("Smoothness", Range(0,1)) = 0.5
		_Metallic ("Metallic", Range(0,1)) = 0.0
		//orignal shader src:
		//_DetailMask("Detail Mask", 2D) = "white" {}
		_DetailAlbedoMap("Detail Albedo x2", 2D) = "grey" {}
		_DetailNormalMapScale("Scale", Float) = 1.0 
		_DetailNormalMap("Normal Map", 2D) = "bump" {}
		//use material.SetTextureOffset ("_DetailAlbedoMap", new Vector2 (DetailTextureOffset, 0))
	}
	SubShader 
	{
		Tags { "RenderType"="Opaque" }
		LOD 200
		
		CGPROGRAM
		// Physically based Standard lighting model, and enable shadows on all light types

		#pragma surface surf Standard fullforwardshadows vertex:vert finalcolor:fog 


		// Use shader model 3.0 target, to get nicer looking lighting
		#pragma target 3.0

		sampler2D _MainTex;
		sampler2D _BumpMap;
		sampler2D _DetailAlbedoMap;
		sampler2D _DetailNormalMap;
		

		#include "UnityCG.cginc"

		float4 _FogColor;
		float _FogDensity;

			struct Input {
			float2 uv_MainTex;
			float2 uv_BumpMap;
			float2 uv_DetailAlbedoMap;
			float dist;
		};

		void vert (inout appdata_full v,out Input o)
        {
			
			float dist = distance(_WorldSpaceCameraPos, mul(unity_ObjectToWorld, v.vertex))-20;
			UNITY_INITIALIZE_OUTPUT(Input,o);
			o.dist = lerp(1,0,clamp(dist/300,0,1));

        }

		half _Glossiness;
		half _Metallic;
		fixed4 _Color;

		// Add instancing support for this shader. You need to check 'Enable Instancing' on materials that use the shader.
		// See https://docs.unity3d.com/Manual/GPUInstancing.html for more information about instancing.
		// #pragma instancing_options assumeuniformscaling
		UNITY_INSTANCING_BUFFER_START(Props)
			// put more per-instance properties here
		UNITY_INSTANCING_BUFFER_END(Props)

		void surf (Input IN, inout SurfaceOutputStandard o)
		{
			// Albedo comes from a texture tinted by color
			fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
			o.Albedo = c.rgb ;
			o.Albedo *= tex2D (_DetailAlbedoMap, IN.uv_DetailAlbedoMap).rgb *2;
			// Metallic and smoothness come from slider variables
			o.Metallic = _Metallic;
			o.Normal = UnpackNormal ( tex2D ( _BumpMap, IN.uv_BumpMap));

			o.Smoothness = _Glossiness;
			o.Alpha = c.a;
		
		}
		
		void fog(Input IN, SurfaceOutputStandard o, inout fixed4 color)
		{

		color.rgb = color.rgb * IN.dist;
		color.a = 1;
		}
		ENDCG
	}
	FallBack "Diffuse"
}
