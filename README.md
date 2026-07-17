# Planet Destruction <!-- Replace with your game's actual title -->

**A 2D arcade survival game for WebGL and Android — keep the planets apart or watch them collide.**

Planets drift through space, inexorably pulled toward each other. Your job: drag them apart before they crash. Survive the timer and the game ramps up — planets get faster the longer you last. Two levels, one finger (or mouse).

<!-- If you publish the WebGL build, put the play link right here — for a web game this is the single most valuable line of the README:
**[▶ Play in your browser](https://your-name.itch.io/planet-destruction)**
-->

<!-- Add a short gameplay GIF here:
![Gameplay](Docs/gameplay.gif) -->

## Features

- **One input codebase, two platforms** — pointer-based drag input that works identically with mouse (WebGL/desktop) and touch (Android, via Unity's touch-to-mouse simulation).
- **Time-based difficulty ramp** — planet speed interpolates from min to max over a configurable window (`Mathf.Lerp` over `timeSinceLevelLoad`), so every run gets harder the longer you survive.
- **Two hazard behaviors** — planets that chase each other (`MoveTowards`) and planets that wander to random points in space (`MoveInSpace`).
- **Survival timer win condition** — outlast the countdown to advance; two levels plus a win screen.
- **Juice** — grab/pop particle effects, scrolling parallax background, sci-fi soundtrack.

## Built With

| Technology | Version |
|---|---|
| Unity | 6 (6000.x), 2D |
| UI | Unity UI + TextMeshPro |
| Platforms | WebGL, Android |

## Project Structure

```
Assets/
├── Scenes/       MainMenuScene, GameScene, GameScene2, WinScene
├── Scripts/      DragNDrop (unified pointer input), GameManager (timer/win/lose),
│                 MoveTowards + MoveInSpace (planet behaviors), MovingBackgrounds,
│                 SceneChanger, ReturnToMenu
├── Images/       Sprites (see External Assets Required)
├── Animations/   Grab / pop animation clips
└── Music/        Soundtrack (see External Assets Required)
```

## External Assets Required

This repo excludes third-party art and music — they belong to their respective creators. To run the project with full visuals and sound, download and import into these folders (scenes will show missing sprites until then):

| Asset | Author | Import to |
|---|---|---|
| [Pixel Planets](https://faktory.itch.io/pixel-planets) | Faktory | `Assets/Images/Planets/` |
| [Three Light Effects](https://karlote.itch.io/three-light-effects) | Karlote | `Assets/Images/MoveImages/` and `Assets/Images/PopImages/` |
| [Space Backgrounds](https://thedarkbear.itch.io/space-beckgrounds) | TheDarkBear | `Assets/Images/Background/` |
| [Free Sci-Fi Game Music Pack](https://alkakrab.itch.io/free-sci-fi-game-music-pack) | Alkakrab | `Assets/Music/` |
| Text logos (generated) | [CoolText.com](https://cooltext.com) | `Assets/Images/Logos/` |

## Setup

1. Clone and open with **Unity 6000.x** (Unity 6).
2. Import the external assets listed above into their original folders.
3. Open `Assets/Scenes/MainMenuScene.unity` and press **Play** — drag planets with the mouse.
4. To build: **File → Build Settings**, pick **WebGL** or **Android**, and Build.

## Credits

- Game design, programming and Unity 6 migration: **Andralan-Dev**.
- Art and music by [Faktory](https://faktory.itch.io/pixel-planets), [Karlote](https://karlote.itch.io/three-light-effects), [TheDarkBear](https://thedarkbear.itch.io/space-beckgrounds) [Alkakrab](https://alkakrab.itch.io/free-sci-fi-game-music-pack), and text logos generated with [CoolText.com](https://cooltext.com) — thank you for making free assets available to indie developers.

## License

Original code in `Assets/Scripts/` is provided for portfolio and educational purposes. Third-party content remains under its respective licenses.
