# Game Design Document — [Feature Naam]

> **Instructie:** Alle segmenten met een uitroepteken (!) aan het begin moeten no worden aangepast.

---

## 1. Overzicht

| Veld             | Invullen                                      |
| ---------------- | --------------------------------------------- |
| **Feature Naam** | _Startscherm_                                 |
| **Auteur**       | _Steale van Walbeek & Shannon Ruiter_         |
| **Datum**        | _18-02-2026_                                  |
| **Versie**       | _0.0_                                         |
| **Branch**       | _Feature/Startscherm_                         |
| **Status**       | ✅ Afgerond                                   |

---

## 2. User Story

> Als player wil ik een startscherm waar ik de levels kan selecten en niet gelijk in de game gegooid wordt.

---

## 3. Beschrijving

Deze feature voegt een startscherm toe die je krijgt te zien als je de game opstart. Van dit scherm kan de user de game starten door de gegeven knop te clicken. Dit zorgt ervoor dat de user een makkelijker transitie van  het opstarten van de game naar de core van de gameplay en voorkomt dat de user overprikeld raakt door .

---

## 4. Gameplay Impact

### 4.1 Kernmechanisme

Deze feature maakt het zo dat de speler een zogenaamde _landing page_ heeft. Via deze _Landing page_ kan de speler een menu openen waar die uit een of meerdere _Levels_ kan kiezen. Als de speler een keuze maakt kan de speler op de knop drukken van de gecorreleerde _Level_, wordt de speler verwijsd naar de correcte scene waarin die _Level_ zich bevindt.

### 4.2 Relatie met bestaande systemen

_n.v.t._

| Bestaand Systeem   | Relatie / Impact               |
| ------------------ | ------------------------------ |
| _Null_             | _Null_                         |

### 4.3 Game Feel

_Feedback die de speler krijgt van onze mechanic._

| Feedback Type | Beschrijving                               |
| ------------- | -------------------------------------------|
| Visueel       | _Thematische visualisatie van componenten_ |
| UI            | _Knop & menu voor levels_                  |
| Animatie      | _color-transitie van button-text_          |

---

## 5. Regels & Parameters

_n.v.t._

| Parameter            | Waarde  | Beschrijving                    |
| -------------------- | ------- | ------------------------------- |
| _Null_               | _Null_  |  _Null_                         |

---

## 6. Visueel Ontwerp

### Schetsen / Referenties

> [Inpsiratie van de layout](./../Assets/2d/readMe_Content/arcadeStart.png)

## 7. Audio Ontwerp

_Audio die gebruikt wordt in de mechanic._

| Geluid               | Beschrijving / Karakter            | Placeholder  |
| -------------------- | ---------------------------------- | ------------ |
| Achtergrond muziek   | Ambiance meegeven aan de speler    | ☐ Ja / ✅ Nee|

---

## 8. Technische Overwegingen

### 8.1 Architectuurlaag

```
┌─────────────────────────────────────┐
│   Feedback Layer                    │  ✅
│   (UI, Visuals, Sound)              │
├─────────────────────────────────────┤
│   Game Logic Layer                  │  ☐
│   (Scoring, Lives, Combos)          │
├─────────────────────────────────────┤
│   Interaction Layer                 │  ☐
│   (Bumpers, Ball Physics)           │
├─────────────────────────────────────┤
│   Input & Control Layer             │  ✅
│   (Crosshair, Aim, Shoot)           │
└─────────────────────────────────────┘
```

### 8.2 Benodigde Events

_Er wordt niet geaboneerd op een huidige event noch wordt er een aangemaakt._

| Event                        | Richting        | Beschrijving                  |
| ---------------------------- | --------------- | ----------------------------- |
| _null_                       | _Null_          | _Null_                        |

### 8.3 Benodigde Scripts / Componenten

_n.v.t._

| Script / Component   | Verantwoordelijkheid                   |
| -------------------- | -------------------------------------- |
| _Null_               | _Null_                                 |

### 8.4 Uitschakelbaar

_Als we de game willen laten runnen zonder deze feature moeten wij der voor zorgen dat de build start op de game-scene en niet de start-scene. Om dit te doen moeten we de game-scene annduiden als scene-0 in de Unity editor **voor** de creatie van de build._

---

## 9. Todo Lijst

- [✅] Game design document invullen en reviewen
- [✅] Script(s) aanmaken en implementeren
- [✅] UI elementen toevoegen
- [ ] Feature testen op bugs
- [ ] Usertest uitvoeren (min. 3 spelers)
- [ ] Usertest documentatie schrijven (`Usertest_[FeatureNaam].md`)
- [ ] Alle documentatie dubbelchecken
- [ ] Code review / pull request aanmaken

---

## 10. Acceptatiecriteria

_Wanneer is deze feature "af"? Verwijs ook naar de [Definition of Done](./DefinitionOfDone.md)._

- [✅] De user story is volledig geïmplementeerd
- [✅] De feature is uitschakelbaar zonder bugs
- [✅] Alle placeholder art/audio is aanwezig
- [ ] Usertest is afgerond en gedocumenteerd
- [ ] Geen errors of bugs in test build
- [ ] Technisch design document is bijgewerkt
- [ ] Pull request is goedgekeurd en gemerged naar `development`

---

## 11. Opmerkingen / Open Vragen

_!Noteer hier eventuele openstaande vragen, risico's of afhankelijkheden._
Omdat Wij niet weten welke scene's nog moeten worden toegevoegd kunnen wij deze nit in de menu zetten en moet dit later weer in aanvraag komen.

- _…_
