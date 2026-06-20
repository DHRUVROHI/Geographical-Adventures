# Heritage Explorer

## Overview
Heritage Explorer is a Unity-based globe exploration game where players discover famous Indian monuments, collect artifacts, and complete exploration objectives.

## Unity Version
Unity 2021.3.2f1

## Setup Instructions
1. Clone the repository
2. Open the project using Unity Hub
3. Open the main scene
4. Press Play

## Controls
WASD - Move
E - Pick Up / Drop Artifact

## Build Instructions
1. Open Build Settings
2. Select WebGL
3. Click Build

## Architecture Overview

### Player System
- Planetary movement
- Surface-aligned locomotion

### Camera System
- Third-person follow camera
- Dynamic FOV

### Artifact System
- ScriptableObject-based data
- Pickup and drop mechanics

### Monument System
- Region detection
- Quest progression

### UI System
- Event-driven HUD updates
- DOTween transitions



## Performance Considerations

-Triangle count 824.1k
-Draw calls  260
-Texture sizes 18 mb

### Optimization Techniques Used
- Low-poly assets
- Reused materials where possible
- Lightweight UI elements
- Event-driven UI updates
- ScriptableObjects for artifact data
- Occlusion culling 

### Texture Usage
- 512x512 and 1024x1024 textures used where appropriate


