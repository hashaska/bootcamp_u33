Shader "SFHologram/HologramShaderWithWaveEffect"
{
	Properties
	{
		// General
		_Brightness("Brightness", Range(0.1, 6.0)) = 4.0
		_Alpha ("Alpha", Range (0.0, 1.0)) = 0.8
		_Direction ("Direction", Vector) = (0,1,0,0)
		// Main Color
		_MainTex ("MainTexture", 2D) = "white" {}
		_MainColor ("MainColor", Color) = (1,1,1,1)
		// Rim/Fresnel
		_RimColor ("Rim Color", Color) = (1,1,1,1)
		_RimPower ("Rim Power", Range(0.1, 10)) = 5.0
		// Scanline
		_ScanTiling ("Scan Tiling", Range(0.01, 10.0)) = 0.05
		_ScanSpeed ("Scan Speed", Range(-2.0, 2.0)) = 1.6
		// Glow
		_GlowTiling ("Glow Tiling", Range(0.01, 1.0)) = 0.02
		_GlowSpeed ("Glow Speed", Range(-10.0, 10.0)) = 5.0
		// Glitch
		 _GlitchSpeed ("Glitch Speed", Range(0, 50)) = 10.0
		_GlitchIntensity ("Glitch Intensity", Float) = 0
		// Alpha Flicker
		_FlickerTex ("Flicker Control Texture", 2D) = "white" {}
		_FlickerSpeed ("Flicker Speed", Range(0.01, 100)) = 25.0

		// Wave Effect
		_WaveSpeed("Wave Speed", Range(0.1, 10.0)) = 7.0
		_WaveIntensity("Wave Intensity", Range(0.1, 10.0)) = 1.0
		_WaveFrequency("Wave Frequency", Range(0.1, 10.0)) = 4.0
		_WaveColor("Wave Color", Color) = (0, 1, 1, 1)

		// Settings
		[HideInInspector] _Fold("__fld", Float) = 1.0
	}

	SubShader
	{
		Tags { "Queue"="Transparent" "RenderType"="Transparent" }
		Blend SrcAlpha OneMinusSrcAlpha
		LOD 100
		ColorMask RGB
		Cull Back

		Pass
		{
			CGPROGRAM
			#pragma shader_feature _SCAN_ON
			#pragma shader_feature _GLOW_ON
			#pragma shader_feature _GLITCH_ON
			#pragma vertex vert
			#pragma fragment frag

			#include "UnityCG.cginc"

			struct appdata
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float2 uv : TEXCOORD0;
				float4 waveData : TEXCOORD1;
			};

			struct v2f
			{
				float4 vertex : SV_POSITION;
				float2 uv : TEXCOORD0;
				float4 worldVertex : TEXCOORD1;
				float3 viewDir : TEXCOORD2;
				float3 worldNormal : NORMAL;
				float4 waveData : TEXCOORD3;
			};

			sampler2D _MainTex;
			sampler2D _FlickerTex;
			float4 _Direction;
			float4 _MainTex_ST;
			float4 _MainColor;
			float4 _RimColor;
			float _RimPower;
			float _GlitchSpeed;
			float _GlitchIntensity;
			float _Brightness;
			float _Alpha;
			float _ScanTiling;
			float _ScanSpeed;
			float _GlowTiling;
			float _GlowSpeed;
			float _FlickerSpeed;

			// Wave Effect
			float _WaveSpeed;
			float _WaveIntensity;
			float _WaveFrequency;
			float4 _WaveColor;

			v2f vert (appdata v)
			{
				v2f o;

				// Glitches
				#if _GLITCH_ON
					v.vertex.x += _GlitchIntensity * (step(0.5, sin(_Time.y * 2.0 + v.vertex.y * 1.0)) * step(0.99, sin(_Time.y*_GlitchSpeed * 0.5)));
				#endif

				o.vertex = UnityObjectToClipPos(v.vertex);

				o.uv = TRANSFORM_TEX(v.uv, _MainTex);
				o.worldVertex = mul(unity_ObjectToWorld, v.vertex);
				o.worldNormal = UnityObjectToWorldNormal(v.normal);
				o.viewDir = normalize(UnityWorldSpaceViewDir(o.worldVertex.xyz));
				o.waveData = v.waveData;

				return o;
			}


			fixed4 frag (v2f i) : SV_Target
			{
				fixed4 texColor = tex2D(_MainTex, i.uv);

				half dirVertex = (dot(i.worldVertex, normalize(float4(_Direction.xyz, 1.0))) + 1) / 2;

				// Scanlines
				float scan = 0.0;
				#ifdef _SCAN_ON
					scan = step(frac(dirVertex * _ScanTiling + _Time.w * _ScanSpeed), 0.5) * 0.65;
				#endif

				// Glow
				float glow = 0.0;
				#ifdef _GLOW_ON
					glow = frac(dirVertex * _GlowTiling - _Time.x * _GlowSpeed);
				#endif

				// Flicker
				fixed4 flicker = tex2D(_FlickerTex, _Time * _FlickerSpeed);

				// Rim Light
				half rim = 1.0 - saturate(dot(i.viewDir, i.worldNormal));
				fixed4 rimColor = _RimColor * pow(rim, _RimPower);

				// Wave Effect
				float wave = sin(i.waveData.x * _WaveSpeed + _Time.y * _WaveFrequency) * _WaveIntensity;
				fixed4 waveColor = _WaveColor * wave;

				fixed4 col = texColor * _MainColor + (glow * 0.35 * _MainColor) + rimColor + waveColor;
				col.a = texColor.a * _Alpha * (scan + rim + glow) * flicker;

				col.rgb *= _Brightness;

				return col;
			}
			ENDCG
		}
	}

	CustomEditor "HologramShaderGUI"
}

