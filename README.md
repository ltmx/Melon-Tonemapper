# Melon Cinematic Tonemapper
An efficient Tonemapper to fix ACES Issues - For Unity &amp; Prowl Game Engines

![LTMX_Melon_Banner_Thin](https://raw.githubusercontent.com/ltmx/Melon-Tonemapper/main/.branding/LTMX_Melon_Banner_Thin.jpeg)

# Motivations
ACES is broken - High intensity colors shift hues
- Intense blue shifts to purple, making highlights dull and dissappear completely in some cases,
- Intense Reds shift to Yellow, providing a warmer feeling, but making things appear as they have some black body radiation.

Melon tonemapping fixes that by shifting the color to white at high intensities, 
with a slight "controlable" hue shift for a more pleasing look:
Green and red slightly shift to yellow and blue shifts to cyan before going to white.

Contrast is ajusted to approximate ACES levels

# Supported Platforms

### Unity Engine
- Currently only supports High Definition Render Pipeline 14.0.3 and above, using a fullscreen shader graph
- Will add support for Universal Render Pipeline and Post Processing Stack Package.

### Prowl Engine
- Implemented natively
- See : https://github.com/michaelsakharov/Prowl


# Screenshots

![ACES VS MELON](https://github.com/ltmx/Melon-Tonemapper/assets/47640688/ba8a07db-a037-428c-8ce9-eb311f29535e)

# Why "Melon" you might ask !?
- My last name is Reinhard but Reinhard tonemapping already exists, so I just picked an old pseudonym I go by ;)
