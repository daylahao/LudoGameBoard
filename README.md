# LudoGame (Cờ Cá Ngựa Mobile)

## Overview

LudoGame is a mobile adaptation of the traditional Vietnamese board game **Cờ Cá Ngựa**, developed using **Unity** and **C#**.

The game supports **3–5 players** on a single device, allowing players to compete against friends or AI opponents. The project features multiple board layouts, bilingual localization (Vietnamese & English), and 3D cartoon-style chess pieces designed for a casual and family-friendly experience.

---

## Features

### Core Gameplay

* Traditional Cờ Cá Ngựa gameplay mechanics.
* Support for **3–5 players**.
* Local multiplayer on a single device.
* Customizable player setup:

  * Select total number of players.
  * Select how many players are controlled by AI.
* Dice rolling and turn-based movement system.
* Winning condition based on bringing all pieces to the destination.

### Localization

* Vietnamese language support.
* English language support.
* Runtime language switching.

### Board Selection

Players can choose between multiple board layouts before starting a match.

* Map 3
* Map 4
* Map 5

### AI Opponents

* AI-controlled players available.
* Supports mixed matches between human players and AI players.

### Settings & User Experience

* In-game settings menu.
* Game rules dialog.
* User-friendly mobile UI.
* Optimized for touch controls.

---

# Screenshots

## Main Menu

### Vietnamese

![MainScene Vi](https://github.com/daylahao/LudoGameBoard/blob/main/Assets/Images/Demo/Ludo%20game%20board/VI_Main.jpg?raw=true)

### English

![MainScene Eng](https://github.com/daylahao/LudoGameBoard/blob/main/Assets/Images/Demo/Ludo%20game%20board/En%20-%20Main.jpg?raw=true)

---

## Rule Dialog

### Vietnamese

![Rule Dialog Vi](https://github.com/daylahao/LudoGameBoard/blob/main/Assets/Images/Demo/Ludo%20game%20board/Vi%20-%20Law.jpg?raw=true)
### English

![Rule Dialog Eng](https://github.com/daylahao/LudoGameBoard/blob/main/Assets/Images/Demo/Ludo%20game%20board/EN%20-%20RULE.jpg?raw=true)

---

## Settings Dialog

### Vietnamese

![INSERT_SETTING_DIALOG_VI_IMAGE](https://github.com/daylahao/LudoGameBoard/blob/main/Assets/Images/Demo/Ludo%20game%20board/Vi%20-%20Setting%20.jpg?raw=true)

### English

![INSERT_SETTING_DIALOG_EN_IMAGE](https://github.com/daylahao/LudoGameBoard/blob/main/Assets/Images/Demo/Ludo%20game%20board/en%20-%20setting.jpg?raw=true)

---

## Board Selection

<p align="center">
  <img src="https://github.com/daylahao/LudoGameBoard/blob/main/Assets/Images/Map%203.png?raw=true" width="30%">
  <img src="https://github.com/daylahao/LudoGameBoard/blob/main/Assets/Images/Map%204.png?raw=true" width="30%">
  <img src="https://github.com/daylahao/LudoGameBoard/blob/main/Assets/Images/Map%205.png?raw=true" width="30%">
</p>

---

## Gameplay

![INSERT_GAMEPLAY_SCREENSHOT](https://github.com/daylahao/LudoGameBoard/blob/main/Assets/Images/Demo/Ludo%20game%20board/Vi%20Game%20Play.jpg?raw=true

---

# 3D Assets

The game uses stylized 3D cartoon chess pieces to create a colorful and approachable visual style suitable for casual players.

[INSERT_3D_PIECES_IMAGE]

---

# Technical Details

## Built With

* Unity
* C#
* Unity UI (UGUI)

## Implemented Systems

### Game State Management

* Main Menu
* Board Selection
* Gameplay
* Victory Flow

### Turn Management

* Player turn rotation
* AI turn handling
* Dice result processing

### Piece Movement System

* Board path navigation
* Movement validation
* Destination path handling

### Localization System

* Vietnamese / English support
* Dynamic UI text switching

### AI System

* Automated dice rolling
* Piece selection logic
* Turn execution

---

# Project Structure

```text
Assets/
├── Scripts/
│   ├── Gameplay/
│   ├── AI/
│   ├── UI/
│   ├── Managers/
│   └── Localization/
├── Prefabs/
├── Scenes/
├── Materials/
├── Models/
└── Images/
```

---

# My Responsibilities

As the developer of this project, I was responsible for:

* Designing and implementing gameplay mechanics.
* Developing turn-based game logic.
* Creating AI player behavior.
* Implementing localization (Vietnamese / English).
* Building UI flows and menus.
* Integrating 3D assets into gameplay.
* Optimizing gameplay experience for mobile devices.

---

# Platform

* Android

---

# Future Improvements

* Online multiplayer support.
* Additional board themes.
* Enhanced AI difficulty levels.
* Save/Load game system.
* Player statistics and achievements.

---

# Author

**Day La Hao**

Unity Game Developer

GitHub: https://github.com/daylahao
