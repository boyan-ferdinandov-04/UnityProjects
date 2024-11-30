Shader "Custom/FresnelBlink"
{
    Properties
    {
        _Color ("Color", Color) = (1,1,1,1)
        _MainTex ("Albedo (RGB)", 2D) = "white" {}
        _Glossiness ("Smoothness", Range(0,1)) = 0.5
        _Metallic ("Metallic", Range(0,1)) = 0.0

        _FresnelColor ("Fresnel Color", Color) = (1,1,1,1)
        _FresnelStrength ("Fresnel Strength", Range(0,1)) = 0.5

        // Blink speed control
        _BlinkSpeed ("Blink Speed", Range(0.1, 10)) = 2.0
        _IsLightOn ("Is Light On", Float) = 0.0
    }
    SubShader
    {
        Tags { "RenderType"="Opaque" }
        LOD 200

        CGPROGRAM
        #pragma surface surf Standard fullforwardshadows

        #pragma target 3.0

        sampler2D _MainTex;

        struct Input
        {
            float2 uv_MainTex;
            float3 worldNormal;
            float3 viewDir;
        };

        half _Glossiness;
        half _Metallic;
        fixed4 _Color;

        half _FresnelStrength;
        fixed4 _FresnelColor;
        half _BlinkSpeed;
        float _IsLightOn;

        void surf (Input IN, inout SurfaceOutputStandard o)
        {
            fixed4 c = tex2D(_MainTex, IN.uv_MainTex) * _Color;
            o.Albedo = c.rgb;
            o.Metallic = _Metallic;
            o.Smoothness = _Glossiness;
            o.Alpha = c.a;

            if (_IsLightOn < 0.5)
            {
                half fresnelFactor = 1.0 - dot(normalize(IN.viewDir), IN.worldNormal);
                fresnelFactor = pow(fresnelFactor, _FresnelStrength);
                half blink = abs(sin(_Time.y * _BlinkSpeed));
                fresnelFactor *= blink;
                o.Emission = _FresnelColor.rgb * fresnelFactor;
            }
        }
        ENDCG
    }
    FallBack "Diffuse"
}
