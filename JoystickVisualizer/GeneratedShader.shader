Shader "PBR Master"
{
	Properties
	{
				[NonModifiableTextureData] [NoScaleOffset] _SampleTexture2D_49765BE3_Tex("Texture", 2D) = "white" {}
				[NonModifiableTextureData] [NoScaleOffset] _SampleTexture2D_D1F919C8_Tex("Texture", 2D) = "white" {}
				[NonModifiableTextureData] [NoScaleOffset] _SampleTexture2D_7DA9A78C_Tex("Texture", 2D) = "white" {}
	}
	SubShader
	{
		Tags{ "RenderPipeline" = "LightweightPipeline"}
		Tags
		{
			"RenderType"="Opaque"
			"Queue"="Geometry"
		}
		Pass
		{
			Tags{"LightMode" = "LightweightForward"}
			
					Blend One Zero
					Cull Back
					ZTest LEqual
					ZWrite On
			
			CGPROGRAM
			#pragma target 3.0
			
		    #pragma multi_compile _ _MAIN_LIGHT_COOKIE
		    #pragma multi_compile _MAIN_DIRECTIONAL_LIGHT _MAIN_SPOT_LIGHT
		    #pragma multi_compile _ _ADDITIONAL_LIGHTS
		    #pragma multi_compile _ _MIXED_LIGHTING_SUBTRACTIVE
		    #pragma multi_compile _ UNITY_SINGLE_PASS_STEREO STEREO_INSTANCING_ON STEREO_MULTIVIEW_ON
		    #pragma multi_compile _ LIGHTMAP_ON
		    #pragma multi_compile _ DIRLIGHTMAP_COMBINED
		    #pragma multi_compile _ _HARD_SHADOWS _SOFT_SHADOWS _HARD_SHADOWS_CASCADES _SOFT_SHADOWS_CASCADES
		    #pragma multi_compile _ _VERTEX_LIGHTS
		    #pragma multi_compile_fog
		    #pragma multi_compile_instancing
		    #pragma vertex vert
			#pragma fragment frag
			
			#pragma glsl
			#pragma debug
			
						#define _NORMALMAP 1
			#include "LightweightLighting.cginc"
								void Unity_Remap_float(float4 In, float2 InMinMax, float2 OutMinMax, out float4 Out)
							{
							    Out = OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
							}
							struct GraphVertexInput
							{
								float4 vertex : POSITION;
								float3 normal : NORMAL;
								float4 tangent : TANGENT;
								float4 texcoord0 : TEXCOORD0;
								float4 texcoord1 : TEXCOORD1;
								UNITY_VERTEX_INPUT_INSTANCE_ID
							};
							struct SurfaceInputs{
								half4 uv0;
							};
							struct SurfaceDescription{
								float3 Albedo;
								float3 Normal;
								float3 Emission;
								float Metallic;
								float Smoothness;
								float Occlusion;
								float Alpha;
							};
							UNITY_DECLARE_TEX2D(_SampleTexture2D_49765BE3_Tex);
							float4 _SampleTexture2D_49765BE3_UV;
							UNITY_DECLARE_TEX2D(_SampleTexture2D_D1F919C8_Tex);
							float4 _SampleTexture2D_D1F919C8_UV;
							UNITY_DECLARE_TEX2D(_SampleTexture2D_7DA9A78C_Tex);
							float4 _SampleTexture2D_7DA9A78C_UV;
							float4 _Remap_487BB099_InMinMax;
							float4 _Remap_487BB099_OutMinMax;
							float4 _PBRMaster_241930A9_Emission;
							float _PBRMaster_241930A9_Metallic;
							float _PBRMaster_241930A9_Occlusion;
							float _PBRMaster_241930A9_Alpha;
							GraphVertexInput PopulateVertexData(GraphVertexInput v){
								return v;
							}
							SurfaceDescription PopulateSurfaceData(SurfaceInputs IN) {
								SurfaceDescription surface = (SurfaceDescription)0;
								half4 uv0 = IN.uv0;
								float4 _SampleTexture2D_49765BE3_RGBA = UNITY_SAMPLE_TEX2D(_SampleTexture2D_49765BE3_Tex,uv0.xy);
								float _SampleTexture2D_49765BE3_R = _SampleTexture2D_49765BE3_RGBA.r;
								float _SampleTexture2D_49765BE3_G = _SampleTexture2D_49765BE3_RGBA.g;
								float _SampleTexture2D_49765BE3_B = _SampleTexture2D_49765BE3_RGBA.b;
								float _SampleTexture2D_49765BE3_A = _SampleTexture2D_49765BE3_RGBA.a;
								float4 _SampleTexture2D_D1F919C8_RGBA = UNITY_SAMPLE_TEX2D(_SampleTexture2D_D1F919C8_Tex,uv0.xy);
								_SampleTexture2D_D1F919C8_RGBA.rgb = UnpackNormal(_SampleTexture2D_D1F919C8_RGBA);
								float _SampleTexture2D_D1F919C8_R = _SampleTexture2D_D1F919C8_RGBA.r;
								float _SampleTexture2D_D1F919C8_G = _SampleTexture2D_D1F919C8_RGBA.g;
								float _SampleTexture2D_D1F919C8_B = _SampleTexture2D_D1F919C8_RGBA.b;
								float _SampleTexture2D_D1F919C8_A = _SampleTexture2D_D1F919C8_RGBA.a;
								float4 _SampleTexture2D_7DA9A78C_RGBA = UNITY_SAMPLE_TEX2D(_SampleTexture2D_7DA9A78C_Tex,uv0.xy);
								float _SampleTexture2D_7DA9A78C_R = _SampleTexture2D_7DA9A78C_RGBA.r;
								float _SampleTexture2D_7DA9A78C_G = _SampleTexture2D_7DA9A78C_RGBA.g;
								float _SampleTexture2D_7DA9A78C_B = _SampleTexture2D_7DA9A78C_RGBA.b;
								float _SampleTexture2D_7DA9A78C_A = _SampleTexture2D_7DA9A78C_RGBA.a;
								float4 _Remap_487BB099_Out;
								Unity_Remap_float(_SampleTexture2D_7DA9A78C_RGBA, _Remap_487BB099_InMinMax, _Remap_487BB099_OutMinMax, _Remap_487BB099_Out);
								surface.Albedo = _SampleTexture2D_49765BE3_RGBA;
								surface.Normal = _SampleTexture2D_D1F919C8_RGBA;
								surface.Emission = _PBRMaster_241930A9_Emission;
								surface.Metallic = _PBRMaster_241930A9_Metallic;
								surface.Smoothness = _Remap_487BB099_Out;
								surface.Occlusion = _PBRMaster_241930A9_Occlusion;
								surface.Alpha = _PBRMaster_241930A9_Alpha;
								return surface;
							}
			
			struct GraphVertexOutput
		    {
		        float4 position : SV_POSITION;
		#ifdef LIGHTMAP_ON
		        float4 lightmapUV : TEXCOORD0;
		#else
				float4 vertexSH : TEXCOORD0;
		#endif
				half4 fogFactorAndVertexLight : TEXCOORD1; // x: fogFactor, yzw: vertex light
		        			float3 WorldSpaceNormal : TEXCOORD3;
					float3 WorldSpaceTangent : TEXCOORD4;
					float3 WorldSpaceBiTangent : TEXCOORD5;
					float3 WorldSpaceViewDirection : TEXCOORD6;
					float3 WorldSpacePosition : TEXCOORD7;
					half4 uv0 : TEXCOORD8;
					half4 uv1 : TEXCOORD9;
				UNITY_VERTEX_OUTPUT_STEREO
		    };
			
		    GraphVertexOutput vert (GraphVertexInput v)
			{
			    v = PopulateVertexData(v);
				
				UNITY_SETUP_INSTANCE_ID(v);
		        GraphVertexOutput o = (GraphVertexOutput)0;
		        UNITY_INITIALIZE_VERTEX_OUTPUT_STEREO(o);
		        			o.WorldSpaceNormal = mul(v.normal,(float3x3)unity_WorldToObject);
					o.WorldSpaceTangent = mul((float3x3)unity_ObjectToWorld,v.tangent);
					o.WorldSpaceBiTangent = normalize(cross(o.WorldSpaceNormal, o.WorldSpaceTangent.xyz) * v.tangent.w);
					o.WorldSpaceViewDirection = mul((float3x3)unity_ObjectToWorld,ObjSpaceViewDir(v.vertex));
					o.WorldSpacePosition = mul(unity_ObjectToWorld,v.vertex);
					o.uv0 = v.texcoord0;
					o.uv1 = v.texcoord1;
				float3 lwWNormal = normalize(UnityObjectToWorldNormal(v.normal));
				float4 lwWorldPos = mul(unity_ObjectToWorld, v.vertex);
				float4 clipPos = mul(UNITY_MATRIX_VP, lwWorldPos);
		#ifdef LIGHTMAP_ON
				o.lightmapUV.zw = v.texcoord1 * unity_LightmapST.xy + unity_LightmapST.zw;
		#else
				o.vertexSH = half4(EvaluateSHPerVertex(lwWNormal), 0.0);
		#endif
				o.fogFactorAndVertexLight.yzw = VertexLighting(lwWorldPos.xyz, lwWNormal);
				o.fogFactorAndVertexLight.x = ComputeFogFactor(clipPos.z);
		        o.position = clipPos;
				return o;
			}
			fixed4 frag (GraphVertexOutput IN) : SV_Target
		    {
		    				float3 WorldSpaceNormal = normalize(IN.WorldSpaceNormal);
					float3 WorldSpaceTangent = IN.WorldSpaceTangent;
					float3 WorldSpaceBiTangent = IN.WorldSpaceBiTangent;
					float3 WorldSpaceViewDirection = normalize(IN.WorldSpaceViewDirection);
					float3 WorldSpacePosition = IN.WorldSpacePosition;
					float4 uv0  = IN.uv0;
					float4 uv1  = IN.uv1;
		        SurfaceInputs surfaceInput = (SurfaceInputs)0;
		        			surfaceInput.uv0 = uv0;
		        SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
				float3 Albedo = float3(0.5, 0.5, 0.5);
				float3 Specular = float3(0, 0, 0);
				float Metallic = 0;
				float3 Normal = float3(0, 0, 1);
				float3 Emission = 0;
				float Smoothness = 0.5;
				float Occlusion = 1;
				float Alpha = 1;
		        			Albedo = surf.Albedo;
					Normal = surf.Normal;
					Emission = surf.Emission;
					Metallic = surf.Metallic;
					Smoothness = surf.Smoothness;
					Occlusion = surf.Occlusion;
					Alpha = surf.Alpha;
		#if defined(UNITY_COLORSPACE_GAMMA) 
		       	Albedo = Albedo * Albedo;
		       	Emission = Emission * Emission;
		#endif
		#if _NORMALMAP
		    half3 normalWS = TangentToWorldNormal(Normal, WorldSpaceTangent, WorldSpaceBiTangent, WorldSpaceNormal);
		#else
		    half3 normalWS = normalize(WorldSpaceNormal);
		#endif
		#if LIGHTMAP_ON
			half3 indirectDiffuse = SampleLightmap(IN.lightmapUV.zw, normalWS);
		#else
			half3 indirectDiffuse = EvaluateSHPerPixel(normalWS, IN.vertexSH);
		#endif
			half4 color = LightweightFragmentPBR(
					WorldSpacePosition,
					normalWS,
					WorldSpaceViewDirection,
					indirectDiffuse,
					IN.fogFactorAndVertexLight.yzw, 
					Albedo,
					Metallic,
					Specular,
					Smoothness,
					Occlusion,
					Emission,
					Alpha);
			// Computes fog factor per-vertex
		    ApplyFog(color.rgb, IN.fogFactorAndVertexLight.x);
		#if _AlphaOut
				color.a = Alpha;
		#else
				color.a = 1;
		#endif
		#if _AlphaClip
				clip(Alpha - 0.01);
		#endif
				return color;
		    }
			ENDCG
		}
		Pass
		{
		    Tags{"LightMode" = "ShadowCaster"}
		    ZWrite On ZTest LEqual
		    CGPROGRAM
		    #pragma target 2.0
		    #pragma vertex ShadowPassVertex
		    #pragma fragment ShadowPassFragment
		    #include "UnityCG.cginc"
		    #include "LightweightPassShadow.cginc"
		    ENDCG
		}
		Pass
		{
		    Tags{"LightMode" = "DepthOnly"}
		    ZWrite On
		    ColorMask 0
		    CGPROGRAM
		    #pragma target 2.0
		    #pragma vertex vert
		    #pragma fragment frag
		    #include "UnityCG.cginc"
		    float4 vert(float4 pos : POSITION) : SV_POSITION
		    {
		        return UnityObjectToClipPos(pos);
		    }
		    half4 frag() : SV_TARGET
		    {
		        return 0;
		    }
		    ENDCG
		}
	}
}
