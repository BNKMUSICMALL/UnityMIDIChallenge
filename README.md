# UnityMIDIChallenge
This is the test of **Unity Developer** from **Mutex Team**. Test duration is **7 days** since this test has been received. It is a simple challenge for drawing a gameplay scene from a MIDI file using Unity engine(C#), please thoroughly read before the start.
> Unity engine version 2020.3.14f1

## Requirements
### Gameplay
- The game should contains only a single gameplay screen(no other screens)
- Total 6 note lines

| No. | Note | Sound     | MIDI value | Color  | Score point | Input key |
|-----|------|-----------|------------|--------|-------------|-----------|
| 1   | C#2  | rim snare | 37         | purple | 20          | A         |
| 2   | C#3  | cymbal    | 49         | blue   | 20          | S         |
| 3   | D2   | snare     | 38         | green  | 20          | D         |
| 4   | C2   | bass drum | 36         | yellow | 20          | F         |
| 5   | C3   | high tom  | 48         | orange | 20          | G         |
| 6   | G2   | floor tom | 43         | red    | 20          | H         |

 
- Player must press key on the keyboard in time when the scrolling notes collide with the note indicator
- For every note hit, it should increases the total score by `Score point` from the table
- For every note hit, note should be destroyed/hidden
- When complete a song, player can press `spacebar` to restart the game
- Speed of notes scrolling down is configurable
- Color of notes is configurable
- Size of notes is configurable(optional)
- Score point of notes is configurable
- Input key is configurable

### Game Visual
- Default screen size should be 1270 x 720 with responsive UI
- Displays key panel with input guide(A, S, D, F, G, H) on the bottom of the screen as gameplay screenshots
    - Each key display in its own color (see the color column in the table above)
    - Each key will display key-down feedback
- Displays the note indicator at the top of key panel
- Notes scroll down to the key in vertical in configured speed
    - The notes should be generated by the MIDI data from `DrumTrack1.mid` in `AssetData/Midi`
    - MIDI file is configurable
- Display total score on the top-left of the screen(for example: `Score: 500`)

### Sound
- Play MIDI song in time with scrolling notes using `DrumTrack1.mp3` in `AssetData/Sounds`
    - MIDI song is configurable as the MIDI file

### Additional Requirements
- Unit test is required
- UML Diagram is required, you can use any tools and techniques to create the diagram

## Limitation
- No Playmaker
- 3rd party libraries for **MIDI are allowed**, but others are not
- You can remove/create any files and folders if needed

## Art
- You can use .png file in `AssetData/Sprites` folder to create game sprites
- Game background can be any plain color
- Text can be any font you like

## Evaluation
- Completeness
- Architecture
- Data structures
- Time & memory complexity of algorithms
- Overall Performance
- Code readability
- Code cleanliness
- Unity engine usage
- Design principle, Diagram and Explanation

## Submission
Submit your test by creating PR to this repository
<!-- replace your link here --><!-- replace your link here -->
UML diagram: [link](https://docs.google.com/document/d/1K37ROpNNiicsqDEXrBKGxZ8g6nqV07Zfvu-6-DlUTTQ/edit?usp=sharing)
