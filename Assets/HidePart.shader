Shader "Sogoal/HidePart" {
        Properties{
                _Color("Color", Color) = (0.5,0.5,0.5,0.5)
                _MainTex("Particle Texture", 2D) = "white" {}
            posy("Pos Y", float) = 420
        }
 
        Category{
                Tags{ "Queue" = "Transparent" "IgnoreProjector" = "True" "RenderType" = "Transparent" }
                Blend SrcAlpha OneMinusSrcAlpha
                AlphaTest Greater .01
                ColorMask RGB
 
                Lighting Off
                Cull Off
                ZTest
                Always
                ZWrite
                Off
                Fog{ Mode Off }
 
                SubShader{
                Pass{
                Tags{ "LightMode" = "Vertex" }
 
                Lighting On
 
                CGPROGRAM
 
#pragma vertex vert
#pragma fragment frag
 
#include "UnityCG.cginc"
 
                sampler _MainTex;
            float4 _MainTex_ST;
            float posy;
 
        struct a2v {
                float4 vertex : POSITION;
                float3 normal : NORMAL;
                float4 texcoord : TEXCOORD0;
                fixed4 color : COLOR;
        };
 
        struct v2f {
                float4 pos : POSITION;
                float2 uv : TEXCOORD0;
                float3 color : TEXCOORD1;
        };
 
        v2f vert(a2v v) {
                v2f o;
                o.pos = mul(UNITY_MATRIX_MVP, v.vertex);
                o.uv = TRANSFORM_TEX(v.texcoord, _MainTex);
                o.color = ShadeVertexLights(v.vertex, v.normal) *v.color;
                return o;
        }
 
        float4 frag(v2f i) : COLOR{
                float4 c = tex2D(_MainTex, i.uv);
 
                if (i.pos.y > posy)
                {
                        c.a = 0;
                }
                else
                {
                        c.rgb = c.rgb * i.color;
                }
                return c;
        }
 
                ENDCG
              }
       }
        }
}