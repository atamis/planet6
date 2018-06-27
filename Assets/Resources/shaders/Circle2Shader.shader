// Upgrade NOTE: replaced 'mul(UNITY_MATRIX_MVP,*)' with 'UnityObjectToClipPos(*)'

 Shader "Custom/Circle2" {
     Properties {
         _Color ("Color", Color) = (1,0,0,0)
     }
     SubShader {


         Pass {
             CGPROGRAM
 
             #pragma vertex vert
             #pragma fragment frag
             #include "UnityCG.cginc"

 
             fixed4 _Color; // low precision type is usually enough for colors
 
             struct fragmentInput {
                 float4 pos : SV_POSITION;
                 float2 uv : TEXTCOORD0;
             };
 
             fragmentInput vert (appdata_base v)
             {
                 fragmentInput o;
 
                 o.pos = UnityObjectToClipPos (v.vertex);
                 o.uv = v.texcoord.xy - fixed2(0.5,0.5);
 
                 return o;
             }
 
             fixed4 frag(fragmentInput i) : SV_Target {
                 float distance = sqrt(pow(i.uv.x, 2) + pow(i.uv.y,2));
                 //float distancez = sqrt(distance * distance + i.l.z * i.l.z);
 
				// TODO: lerp the circle or antialias?
				//return lerp(fixed4(1,1,1,1), fixed4(0,0,0,1), pow(distance*2, 5));
                 if(distance > 0.5f){
				     // TODO: heard discard was inefficient.
                     discard;
					 // Although discard functions like "return", the return is
					 // necessary, otherwise the shader won't compile.
					 return fixed4(0, 0, 0, 0);
                 } else {
                     return fixed4(1,1,1,1);
                 }
             }
             ENDCG
         }
     }
 }