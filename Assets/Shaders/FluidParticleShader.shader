Shader "Custom/FluidParticleShader" {
Properties {    
    _MainTex ("Texture", 2D) = "white" { }    
}
SubShader {
	Tags {"Queue" = "Transparent" }
    Pass {
    Blend SrcAlpha OneMinusSrcAlpha     
	CGPROGRAM
	#pragma vertex vert
	#pragma fragment frag	
	#include "UnityCG.cginc"	
	float4 _Color;
	sampler2D _MainTex;	
	struct v2f {
	    float4  pos : SV_POSITION;
	    float2  uv : TEXCOORD0;
	};	
	float4 _MainTex_ST;		
	v2f vert (appdata_base v){
	    v2f o;
	    o.pos = UnityObjectToClipPos (v.vertex);
	    o.uv = TRANSFORM_TEX (v.texcoord, _MainTex);
	    return o;
	}	
	
	half4 frag (v2f i) : COLOR{		
		half4 texcol = tex2D (_MainTex, i.uv); 
		half4 finalColor = texcol;					

	    finalColor = half4(0.0, texcol.b / 2.0,texcol.b, 0.5);
		finalColor.b = floor((finalColor.b / 0.1) * 0.5);
		finalColor.r = floor((finalColor.b / 0.1) * 0.5);
		return finalColor;
	}
	ENDCG

    }
}
Fallback "VertexLit"
} 