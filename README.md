# Autocomplete Soundboard
Forked from [JNSoundboard](https://gitlab.com/Jitnaught/JNSoundboard).

Features:
* Can play MP3, WAV, WMA, M4A, and AC3 audio files
* Play sounds through any sound device (speakers, virtual audio cable, etc.)
* Microphone loopback (loops microphone sound through playback device)
* Add, edit, remove, and clear hotkeys
* Can play a random sound out of multiple (just select multiple files when adding a hotkey)
* Restrict hotkey so that the hotkey is only played when a certain window is in the foreground
* Save (and load) hotkeys to XML file
* Hotkey that stops currently playing sound
* Hotkeys that load XML files containing hotkeys
* Auto press push-to-talk key when playing sound
* Text-to-speech

Requires: 
* .NET Framework 4.6
* NAudio

Setup: 
* Install a virtual audio cable (I recommend [VB-CABLE](http://vb-audio.pagesperso-orange.fr/Cable/index.htm))
* Set the playback device to the virtual audio cable
* Set the loopback device to your microphone
* In the application you're playing sound into, set the microphone device to "VB-Audio Virtual Cable"

Screenshots: 

![Main window](https://i.imgur.com/7mGHN9g.jpg)

![Add hokey window](https://i.imgur.com/pgKoli1.jpg)

![Settings window](https://i.imgur.com/yYsm1TR.jpg)

![Text-to-speech window](https://i.imgur.com/EoPayHn.png)

TODO:
* Add secondary playback device option
* Implement Autocomplete Console
* Import sound clips by dragging them into the window


