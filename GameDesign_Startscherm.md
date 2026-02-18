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
| **Status**       | 📝 Concept / 🔨 In ontwikkeling / ✅ Afgerond |

---

## 2. User Story

> Als player wil ik een startscherm waar ik de levels kan selecten en niet gelijk in de game gegooid wordt.

---

## 3. Beschrijving

_!Geef een uitgebreide beschrijving van de feature. Wat doet het? Hoe past het binnen Galactic Ricochet? Waarom maakt het het spel beter?_

---

## 4. Gameplay Impact

### 4.1 Kernmechanisme

!Deze feature maakt het zo dat de speler een zogenaamde _landing page_ heeft. Via deze _Landing page_ kan de speler een menu openen waar die uit een of meerdere _Levels_ kan kiezen.

### 4.2 Relatie met bestaande systemen

_!Geef aan welke bestaande systemen worden beïnvloed of aangevuld (bijv. Score, Combo, Lives, Multiplier, Input). Verwijs waar nodig naar het [Technisch Design](./TechnicalDesign.md)._

| Bestaand Systeem   | Relatie / Impact               |
| ------------------ | ------------------------------ |
| Score              | _bijv. verhoogt score met X_   |
| Combo / Multiplier | _bijv. reset combo bij missen_ |
| Lives              | _bijv. geen invloed_           |
| Input              | _bijv. extra knop nodig_       |
| _Ander systeem_    | _…_                            |

### 4.3 Game Feel

_!Welke feedback krijgt de speler? Denk aan: screenshake, geluid, visuele effecten, UI-updates, animaties._

| Feedback Type | Beschrijving                       |
| ------------- | ---------------------------------- |
| Visueel       | _bijv. particle effect bij impact_ |
| Audio         | _bijv. power-up geluid_            |
| Screenshake   | _bijv. korte shake bij activatie_  |
| UI            | _bijv. icoon verschijnt in HUD_    |
| Animatie      | _bijv. idle → active state_        |

---

## 5. Regels & Parameters

_!Definieer de concrete spelregels en instelbare waarden voor deze feature._

| Parameter            | Waarde  | Beschrijving                    |
| -------------------- | ------- | ------------------------------- |
| _bijv. cooldown_     | _2 sec_ | _Tijd voordat het opnieuw kan_  |
| _bijv. puntenwaarde_ | _500_   | _Punten per activatie_          |
| _bijv. duur_         | _5 sec_ | _Hoe lang het effect actief is_ |

---

## 6. Visueel Ontwerp

_!Voeg schetsen, wireframes, of referentiebeelden toe. Beschrijf de gewenste look & feel._

### Schetsen / Referenties

> _!Plaats hier afbeeldingen of links naar referentiemateriaal._
> `![beschrijving](pad/naar/afbeelding.png)`

### Placeholder Art Beschrijving

_!Beschrijf welke placeholder art nodig is om de feature te ontwikkelen en te testen._

---

## 7. Audio Ontwerp

_!Welke geluiden zijn nodig? Beschrijf per geluid het gewenste karakter._

| Geluid               | Beschrijving / Karakter            | Placeholder  |
| -------------------- | ---------------------------------- | ------------ |
| _bijv. activate SFX_ | _Korte, punchy synth hit_          | ☐ Ja / ☐ Nee |
| _bijv. loop SFX_     | _Zacht ambient hum tijdens actief_ | ☐ Ja / ☐ Nee |

---

## 8. Technische Overwegingen

### 8.1 Architectuurlaag

_!In welke laag van de architectuur past deze feature? (Input & Control / Interaction / Game Logic / Feedback)_

```
┌─────────────────────────────────────┐
│   Feedback Layer                    │  ☐
│   (UI, Visuals, Sound)              │
├─────────────────────────────────────┤
│   Game Logic Layer                  │  ☐
│   (Scoring, Lives, Combos)          │
├─────────────────────────────────────┤
│   Interaction Layer                 │  ☐
│   (Bumpers, Ball Physics)           │
├─────────────────────────────────────┤
│   Input & Control Layer             │  ☐
│   (Crosshair, Aim, Shoot)           │
└─────────────────────────────────────┘
```

### 8.2 Benodigde Events

_!Welke nieuwe events worden aangemaakt? Op welke bestaande events wordt geabonneerd?_

| Event                        | Richting        | Beschrijving                  |
| ---------------------------- | --------------- | ----------------------------- |
| _bijv. `onPowerUpCollected`_ | Publish (nieuw) | _Fired bij oppakken power-up_ |
| _bijv. `onHitBumper`_        | Subscribe       | _Luistert naar bumper hits_   |

### 8.3 Benodigde Scripts / Componenten

!

| Script / Component   | Verantwoordelijkheid                   |
| -------------------- | -------------------------------------- |
| _bijv. PowerUp.cs_   | _Detectie collision, activeren effect_ |
| _bijv. PowerUpUI.cs_ | _Tonen van actief power-up icoon_      |

### 8.4 Uitschakelbaar

_!Beschrijf hoe deze feature uitgeschakeld kan worden zonder dat de rest van het spel breekt (conform de [Definition of Done](./DefinitionOfDone.md)). Welk GameObject moet gedeactiveerd worden?_

---

## 9. Todo Lijst

- [ ] Game design document invullen en reviewen
- [ ] Placeholder art maken / verzamelen
- [ ] Placeholder audio maken / verzamelen
- [ ] Script(s) aanmaken en implementeren
- [ ] Events koppelen aan bestaande systemen
- [ ] UI elementen toevoegen
- [ ] Feature testen op bugs
- [ ] Usertest uitvoeren (min. 3 spelers)
- [ ] Usertest documentatie schrijven (`Usertest_[FeatureNaam].md`)
- [ ] Technisch design document updaten
- [ ] Alle documentatie dubbelchecken
- [ ] Code review / pull request aanmaken
- [ ] _Voeg extra taken toe indien nodig_

---

## 10. Acceptatiecriteria

_Wanneer is deze feature "af"? Verwijs ook naar de [Definition of Done](./DefinitionOfDone.md)._

- [ ] De user story is volledig geïmplementeerd
- [ ] Alle parameters zijn instelbaar via de Unity Inspector
- [ ] De feature is uitschakelbaar zonder bugs
- [ ] Alle placeholder art/audio is aanwezig
- [ ] Usertest is afgerond en gedocumenteerd
- [ ] Geen errors of bugs in test build
- [ ] Technisch design document is bijgewerkt
- [ ] Pull request is goedgekeurd en gemerged naar `development`

---

## 11. Opmerkingen / Open Vragen

_!Noteer hier eventuele openstaande vragen, risico's of afhankelijkheden._

- _…_
