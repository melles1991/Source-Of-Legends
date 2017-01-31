Shader "Custom/miniMapSheder" {
	Properties {

		_MainTex ("Base (RGB)", 2D) = "white" {}
		_Mask ("Culling Mask", 2D) = "white" {}
		_Cutoff ("Alpha cutoff", Range(0,1)) = 0.1
	}
	SubShader {
		Tags { "RenderType"="Opaque" }
		Lighting Off
		ZWrite Off
		Blend SrcAlpha OneMinusScrAipha
		AlphaTest GEqual [_Cutoff]
		Pass
		{
		SetTexture [_Mask] (combine texture)
		SetTexture [_MainTex] (combine texture, previous)
		}
	}

}
