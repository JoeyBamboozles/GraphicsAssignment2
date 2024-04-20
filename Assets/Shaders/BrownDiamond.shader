Shader "Custom/BrownDiamond"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _CustomTime ("Custom Time", Float) = 0.0
        _Resolution ("Resolution", Vector) = (1, 1, 0, 0)
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        Pass
        {
            CGPROGRAM
            #pragma vertex vert
            #pragma fragment frag

            #include "UnityCG.cginc"

            struct appdata
            {
                float4 vertex : POSITION;
                float2 uv : TEXCOORD0;
            };

            struct v2f
            {
                float2 uv : TEXCOORD0;
                UNITY_FOG_COORDS(1)
                float4 vertex : SV_POSITION;
            };

            sampler2D _MainTex;
            float _CustomTime;
            float2 _Resolution;

            v2f vert (appdata v)
            {
                v2f o;
                o.vertex = UnityObjectToClipPos(v.vertex);
                o.uv = v.uv;
                return o;
            }

            void frag (v2f i, out float4 oColor : SV_Target)
            {
                float2 uv = i.uv;
                float t = 0.5 + 0.5 * sin(_CustomTime);
                float2 centered_uv = 4.0 * (uv - float2(0.5, 0.5));
                float diamond_pattern = abs(centered_uv.x) + abs(centered_uv.y);
                float alternating_pattern = floor(diamond_pattern - t * 2.0) % 2.0;
                float3 brown = float3(0.4, 0.2, 0.0); 
                float3 dark_brown = float3(0.3, 0.15, 0.05); 
                float3 color = lerp(brown, dark_brown, alternating_pattern);
                oColor = float4(color, 1.0);
            }
            ENDCG
        }
    }
}
