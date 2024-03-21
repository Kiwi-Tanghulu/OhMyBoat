Shader"Unlit/ToonWater"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _WaterSpeed ("WaterSpeed", float) = 1
        _WaterHeight ("WaterHeight", float) = 1
        _WaterLength ("WaterLength", float) = 1
        _Color ("Color", Color) = (1,1,1)
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" }
        LOD 100

        Pass
        {
            HLSLPROGRAM
            #pragma vertex vert
            #pragma fragment frag
            // make fog work
            #pragma multi_compile_fog

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
                float3 normal : NORMAL;
                float4 color : COLOR;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
                float3 normal : NORMAL;
                float4 color : COLOR;
            };

            sampler2D _MainTex;
            float4 _MainTex_ST;
            float _WaterSpeed;
            float _WaterHeight;
            float _WaterLength;
            fixed4 _Color;

            v2f vert (appdata v)
            {
                v2f o;
                float cycle = 2 * UNITY_PI / _WaterLength;
                float rad = (v.vertex.x - _Time.y * _WaterSpeed) * cycle;
                float3 tangent = normalize(float3(1, cycle * _WaterHeight * cos(rad), 0));
                float3 normal = float3(-tangent.y, tangent.x, 0);
    
                v.vertex.y = sin(rad) * _WaterHeight;
                v.vertex.x += cos(rad) * _WaterHeight;
                v.normal = normal;
    
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.normal = v.normal;
                o.uv = TRANSFORM_TEX(v.uv, _MainTex);
                UNITY_TRANSFER_FOG(o,o.vertex);
                return o;
            }

            fixed4 frag (v2f i) : SV_Target
            {
                // sample the texture
                //fixed4 col = tex2D(_MainTex, i.uv);
                //// apply fog
                //UNITY_APPLY_FOG(i.fogCoord, col);
                return _Color;
            }
            ENDHLSL
        }
    }
}
