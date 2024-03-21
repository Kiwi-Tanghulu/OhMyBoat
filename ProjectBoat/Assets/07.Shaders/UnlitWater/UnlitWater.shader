Shader"Unlit/UnlitWater"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _BaseColor ("BaseColor", Color) = (1, 1, 1, 1)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 100

        HLSLINCLUDE
        //#include "Packages/com.unity.render-piplines.universal/ShaderLibrary/Core.hlsl"
        #include "UnityCG.cginc"

        CBUFFER_START(UnityPerMaterial)
            float4 _BaseColor;
        CBUFFER_END

        struct VertexInput
        {
            float4 position : POSITIONT;
            float2 uv : TEXCOORD;
        };

        struct VertexOutput
        {
            float4 position : SV_Position;
            float2 uv : TEXCOORD;
        };
        
        ENDHLSL
        
        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert    
            #pragma fragment frag
    
            VertexOutput vert(VertexInput i)
            {
                VertexOutput o;
                o.position = UnityObjectToClipPos(i.position);
                o.uv = i.uv;
                return o;
            }

            float4 frag(VertexOutput o) : SV_Target
            {
                
                return _BaseColor;
            }

            ENDHLSL
        }
    }
}
