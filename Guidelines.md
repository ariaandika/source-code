# 🎲 Personal Project Structure
💎 💡 📦 🛠️ 🧲 ⚙️ 
> text

this `is a` text
```
copy button
```
- [x] done
- [ ] task
- [ ] \(optional) nice

footnote[^1].

[^1]: will put in a bottom screen
<!-- hidden -->

# ⚡ Core
### Q		: Provide debugging and most used function in shorthand
- p, r
- RandomInsideCircle	: return random x and z position in edge of a circle
- VecByAngle			: return vector2 by given angle
- Vc					: return converted vector3 to vector2
- Approx				: return true if float or v3 is approximately close, with given threshold

### LookAround	: first person camera
### RayPosition	: cast ray from player perspective

### Move	: flexible 3D movement
- speed, jumpHeight, gravity,
- Activatable
  - Run, Crouch, Glide


# 🔥 Manager Directory
### Manager	: Main game manager
- For instantiating level manager
- Main menu
- Dont destroy on load

### IO		: import export data
- player save
- multiple resource

### U		: global data
### Preference	: player progress
- player progress
- achievement
- secret found
- hidden object
- custom settings


