Shader "Default/MelonTonemapping"

Pass 0
{
	Vertex
	{
		in vec3 vertexPosition;

		void main()
		{
			gl_Position = vec4(vertexPosition, 1.0);
		}
	}

	Fragment
	{
		uniform vec2 Resolution;

		uniform sampler2D gAlbedo;
		
		layout(location = 0) out vec4 OutputColor;
		
		vec3 Tonemap(vec3 color)
		{
			// remaps the colors to [0-1] range
			// tested to be as close ti ACES contrast levels as possible
			color = pow(color, 1.56); 
			color = color/(color + 0.84);
			
			// governs the transition to white for high color intensities
			float factor = Cmax(color) * 0.15; // multiply by 0.15 to get a similar look to ACES
			factor = factor / (factor + 1); // remaps the factor to [0-1] range
			factor *= factor; // smooths the transition to white
			
			// shift the hue for high intensities (for a more pleasing look).
			color = mix(color, HueShift(color), factor); // can be removed for more neutral colors
			color = mix(color, 1, factor); // shift to white for high intensities
			
			// clamp to [0-1] range
		    return saturate(color);
		}
		
		// Shifts red to Yellow, green to Yellow, blue to Cyan,
		vec3 HueShift(vec3 In)
		{
			float A = max(In.x, In.y);
			return vec3(A, max(A, In.z), In.z); 
		}
		
		float Cmax(vec3 In)
		{
			return max(max(In.r, In.g), In.b);
		}

		void main()
		{
			vec2 texCoords = gl_FragCoord.xy / Resolution;
			vec3 color = texture(gAlbedo, texCoords).rgb;
		
			// Make sure to use Linear color space as input
			OutputColor = vec4(Tonemap(color), 1.0);
		}
	}
}