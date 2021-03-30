Shader "hidden/preview"
{
	Properties
	{
				[NonModifiableTextureData] [NoScaleOffset] _SampleTexture2D_49765BE3_Tex("Texture", 2D) = "white" {}
				[NonModifiableTextureData] [NoScaleOffset] _SampleTexture2D_D1F919C8_Tex("Texture", 2D) = "white" {}
				[NonModifiableTextureData] [NoScaleOffset] _SampleTexture2D_7DA9A78C_Tex("Texture", 2D) = "white" {}
				[NonModifiableTextureData] [NoScaleOffset] _Texture2DAsset_AFE14619_Out("Texture", 2D) = "white" {}
	}
	CGINCLUDE
	#include "UnityCG.cginc"
			void Unity_Remap_float(float4 In, float2 InMinMax, float2 OutMinMax, out float4 Out)
			{
			    Out = OutMinMax.x + (In - InMinMax.x) * (OutMinMax.y - OutMinMax.x) / (InMinMax.y - InMinMax.x);
			}
			void Unity_Multiply_float(float A, float B, out float Out)
			{
			    Out = A * B;
			}
			struct GraphVertexInput
			{
				float4 vertex : POSITION;
				float3 normal : NORMAL;
				float4 tangent : TANGENT;
				float4 texcoord0 : TEXCOORD0;
				UNITY_VERTEX_INPUT_INSTANCE_ID
			};
			struct SurfaceInputs{
				half4 uv0;
			};
			struct SurfaceDescription{
				float4 PreviewOutput;
			};
			float Float_ADFB5A3F;
			UNITY_DECLARE_TEX2D(_SampleTexture2D_49765BE3_Tex);
			float4 _SampleTexture2D_49765BE3_UV;
			UNITY_DECLARE_TEX2D(_SampleTexture2D_D1F919C8_Tex);
			float4 _SampleTexture2D_D1F919C8_UV;
			UNITY_DECLARE_TEX2D(_SampleTexture2D_7DA9A78C_Tex);
			float4 _SampleTexture2D_7DA9A78C_UV;
			float4 _Remap_487BB099_InMinMax;
			float4 _Remap_487BB099_OutMinMax;
			float _Multiply_93827770_A;
			float _Multiply_93827770_B;
			UNITY_DECLARE_TEX2D(_Texture2DAsset_AFE14619_Out);
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
				if (Float_ADFB5A3F == 0) { surface.PreviewOutput = half4(_SampleTexture2D_49765BE3_RGBA.x, _SampleTexture2D_49765BE3_RGBA.y, _SampleTexture2D_49765BE3_RGBA.z, 1.0); return surface; }
				float4 _SampleTexture2D_D1F919C8_RGBA = UNITY_SAMPLE_TEX2D(_SampleTexture2D_D1F919C8_Tex,uv0.xy);
				_SampleTexture2D_D1F919C8_RGBA.rgb = UnpackNormal(_SampleTexture2D_D1F919C8_RGBA);
				float _SampleTexture2D_D1F919C8_R = _SampleTexture2D_D1F919C8_RGBA.r;
				float _SampleTexture2D_D1F919C8_G = _SampleTexture2D_D1F919C8_RGBA.g;
				float _SampleTexture2D_D1F919C8_B = _SampleTexture2D_D1F919C8_RGBA.b;
				float _SampleTexture2D_D1F919C8_A = _SampleTexture2D_D1F919C8_RGBA.a;
				if (Float_ADFB5A3F == 1) { surface.PreviewOutput = half4(_SampleTexture2D_D1F919C8_RGBA.x, _SampleTexture2D_D1F919C8_RGBA.y, _SampleTexture2D_D1F919C8_RGBA.z, 1.0); return surface; }
				float4 _SampleTexture2D_7DA9A78C_RGBA = UNITY_SAMPLE_TEX2D(_SampleTexture2D_7DA9A78C_Tex,uv0.xy);
				float _SampleTexture2D_7DA9A78C_R = _SampleTexture2D_7DA9A78C_RGBA.r;
				float _SampleTexture2D_7DA9A78C_G = _SampleTexture2D_7DA9A78C_RGBA.g;
				float _SampleTexture2D_7DA9A78C_B = _SampleTexture2D_7DA9A78C_RGBA.b;
				float _SampleTexture2D_7DA9A78C_A = _SampleTexture2D_7DA9A78C_RGBA.a;
				if (Float_ADFB5A3F == 2) { surface.PreviewOutput = half4(_SampleTexture2D_7DA9A78C_RGBA.x, _SampleTexture2D_7DA9A78C_RGBA.y, _SampleTexture2D_7DA9A78C_RGBA.z, 1.0); return surface; }
				float4 _Remap_487BB099_Out;
				Unity_Remap_float(_SampleTexture2D_7DA9A78C_RGBA, _Remap_487BB099_InMinMax, _Remap_487BB099_OutMinMax, _Remap_487BB099_Out);
				if (Float_ADFB5A3F == 3) { surface.PreviewOutput = half4(_Remap_487BB099_Out.x, _Remap_487BB099_Out.y, _Remap_487BB099_Out.z, 1.0); return surface; }
				float _Multiply_93827770_Out;
				Unity_Multiply_float(_Multiply_93827770_A, _Multiply_93827770_B, _Multiply_93827770_Out);
				if (Float_ADFB5A3F == 4) { surface.PreviewOutput = half4(_Multiply_93827770_Out, _Multiply_93827770_Out, _Multiply_93827770_Out, 1.0); return surface; }
				return surface;
			}
	ENDCG
	SubShader
	{
	    Tags { "RenderType"="Opaque" }
	    LOD 100
	    Pass
	    {
	        CGPROGRAM
	        #pragma vertex vert
	        #pragma fragment frag
	        #include "UnityCG.cginc"
	        struct GraphVertexOutput
	        {
	            float4 position : POSITION;
	            half4 uv0 : TEXCOORD;
	        };
	        GraphVertexOutput vert (GraphVertexInput v)
	        {
	            v = PopulateVertexData(v);
	            GraphVertexOutput o;
	            o.position = UnityObjectToClipPos(v.vertex);
	            o.uv0 = v.texcoord0;
	            return o;
	        }
	        fixed4 frag (GraphVertexOutput IN) : SV_Target
	        {
	            float4 uv0  = IN.uv0;
	            SurfaceInputs surfaceInput = (SurfaceInputs)0;;
	            surfaceInput.uv0 = uv0;
	            SurfaceDescription surf = PopulateSurfaceData(surfaceInput);
	            return surf.PreviewOutput;
	        }
	        ENDCG
	    }
	}
}
