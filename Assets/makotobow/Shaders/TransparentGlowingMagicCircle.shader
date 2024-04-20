Shader "Custom/TransparentGlowingMagicCircle"
{
    Properties
    {
        _MainTex ("Texture", 2D) = "white" {}
        _Color ("Color", Color) = (1,1,1,1)
        _GlowColor ("Glow Color", Color) = (1,1,1,1)
        _GlowIntensity ("Glow Intensity", Range(0,10)) = 1
        _GlowSize ("Glow Size", Range(0,10)) = 2
    }
    SubShader
    {
        Tags { "RenderType"="Transparent" "Queue"="Transparent" }
        Blend SrcAlpha OneMinusSrcAlpha
        
        CGPROGRAM
        #pragma surface surf Lambert alpha:blend
        
        sampler2D _MainTex;
        fixed4 _Color;
        fixed4 _GlowColor;
        float _GlowIntensity;
        float _GlowSize;
        
        struct Input
        {
            float2 uv_MainTex;
        };
        
        void surf (Input IN, inout SurfaceOutput o)
        {
            fixed4 c = tex2D (_MainTex, IN.uv_MainTex) * _Color;
            
            // Make the background transparent
            clip(c.a - 0.01);
            
            o.Albedo = c.rgb;
            o.Alpha = c.a;
            
            // Add glow effect
            float2 uv = IN.uv_MainTex;
            float dist = distance(uv, float2(0.5, 0.5));
            o.Emission = _GlowColor.rgb * (1.0 - dist / _GlowSize) * _GlowIntensity;
        }
        ENDCG
    }
    FallBack "Diffuse"
}
