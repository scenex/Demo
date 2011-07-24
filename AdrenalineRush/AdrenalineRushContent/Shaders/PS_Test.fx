sampler firstSampler;

float4 PS_COLOR(float2 texCoord: TEXCOORD0) : COLOR
{
   float4 color = tex2D(firstSampler, texCoord);   

   // color.g = 0.0f;
   color.r = 1.0f - color.r;
   color.g = 1.0f - color.g;
   color.b = 1.0f - color.b; 

   return color;
} 

technique Technique1
{
    pass Pass1
    {
        PixelShader = compile ps_2_0 PS_COLOR();
    }
}
