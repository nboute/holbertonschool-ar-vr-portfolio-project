Shader "HDRP/Custom/ModelShader"
{
    Properties
    {
        _MainTex ("Base Color (RGB)", 2D) = "white" {}
        _BumpMap ("Normal Map", 2D) = "bump" {}
        _SpecMap ("Specular Color Map", 2D) = "white" {}
        _Detail ("Detail Map", 2D) = "gray" {}
        _RimColor ("Rim Color", Color) = (0.26,0.19,0.16,0.0)
        _RimPower ("Rim Power", Range(0.5,8.0)) = 3.0
    }

    SubShader
    {
        Tags
        {
            "RenderPipeline" = "HDRP"
            "RenderType" = "Opaque"
        }

        Pass
        {
            Tags
            {
                "LightMode" = "ForwardBase"
            }

            HLSLINCLUDE

#include "Packages/com.unity.render-pipelines.high-definition/Runtime/Lighting/ShaderLibrary/NormalSurfaceGradient.hlsl"

            struct Attributes
            {
                float3 positionOS : POSITION;
                float3 normalOS : NORMAL;
                float2 texCoord0 : TEXCOORD0;
            };

            struct Varyings
            {
                float4 positionCS : SV_POSITION;
                float3 normalWS : NORMAL;
                float2 texCoord0 : TEXCOORD0;
            };

            Varyings vert (Attributes input)
            {
                Varyings output;

                output.positionCS = TransformObjectToHClip(input.positionOS);
                output.normalWS = mul(float4(input.normalOS, 0.0), (float4x4)_ObjectToWorld).xyz;
                output.texCoord0 = input.texCoord0;

                return output;
            }

            half4 frag (Varyings input) : SV_Target
            {
                half4 baseColor = tex2D(_MainTex, input.texCoord0);

                half3 viewDir = normalize(UnityWorldSpaceViewDir(input.positionCS.xyz));

                // Rim lighting settings
                half rim = 1.0 - saturate(dot(normalize(input.normalWS), viewDir));
                half3 rimColor = _RimColor.rgb * pow(rim, _RimPower);

                half3 finalColor = baseColor.rgb * 0.4; // Adjust base color intensity

                // Apply detail texture
                finalColor *= tex2D(_Detail, input.texCoord0).rgb * 2.5;

                // Apply specular color
                half3 specColor = tex2D(_SpecMap, input.texCoord0).rgb;

                // Apply specular lighting
                half nh = max(0, dot(normalize(input.normalWS), normalize(float3(0.0, 0.0, 1.0) + viewDir)));
                half spec = pow(nh, 32.0);
                finalColor += specColor * spec;

                // Apply rim lighting
                finalColor += rimColor;

                return half4(finalColor, baseColor.a);
            }

            ENDHLSL
        }
    }

    Fallback "HDRP/Lit"
}
