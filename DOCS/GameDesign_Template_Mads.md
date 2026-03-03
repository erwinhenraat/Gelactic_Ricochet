# Game Design Document — [RNGbumper]

> **Instructie:** Kopieer dit bestand en hernoem het naar `GameDesign_[FeatureNaam].md`.
> Vul alle secties zo volledig mogelijk in voordat je begint met ontwikkelen.

---

## 1. Overzicht

| Veld             | Invullen                                      |
| ---------------- | --------------------------------------------- |
| **Feature Naam** | _RNG Bumper_                   |
| **Auteur**       | _Mads Hoogeveen_                       |
| **Datum**        | _3-3-2026_                                  |
| **Versie**       | _1.0_                                         |
| **Branch**       | `origin/feature/RNGbumper`                       |
| **Status**       | ✅ Afgerond |

---

## 2. User Story

>Als speler wil ik dat als de game begint dat er RNG bumpers zijn die de bal kan aanraken. 
Als deze Bumper word aangeraakt word er een random waarde aan punten aan de speler gegeven.

---

## 3. Beschrijving

Deze feature bevat een RNG bumper prefab die er voor 
zorgt als het balletje de bumper raakt, dat er dan een
random aantal aan punten tussen bepaalde eenheden word gegeven aan de speler.

---

## 4. Gameplay Impact

Deze feature zorgt ervoor dat er meer spanning en variatie in gameplay
is vanwege de random punten die kunnen worden verdiend. Spelers zullen worden aangemoedigd
om risico's te nemen door de bumper te raken, in de hoop op een hoge score.

### 4.1 Kernmechanisme

Het balletje moet de bumper hitten
het directe resultaat is een random aantal aan punten dat aan de speler word gegeven.

### 4.2 Relatie met bestaande systemen

_Geef aan welke bestaande systemen worden beïnvloed of aangevuld (bijv. Score, Combo, Lives, Multiplier, Input). Verwijs waar nodig naar het [Technisch Design](./TechnicalDesign.md)._

| Bestaand Systeem   | Relatie / Impact               |
| ------------------ | ------------------------------ |
| Score              |  Random punten word aan de speler gegeven   
| Combo / Multiplier |  De mulitplier word gebruikt voor de RNG bumper zodat de punten hiervan vermedigvuldigd kunnen worden |
| Lives              |	geen invloed             
| Input              |  geen invloed       
| _Ander systeem_    |  geen invloed                          

### 4.3 Game Feel

_Welke feedback krijgt de speler? Denk aan: screenshake, geluid, visuele effecten, UI-updates, animaties._

| Feedback Type | Beschrijving                       |
| ------------- | ---------------------------------- |
| Visueel       | RNG bumper balletje met (?) Symbool 
| Audio         | Reward geluidje           |
| Screenshake   | geen invloed    
| UI            | geen invloed       |
| Animatie      | geen invloed            

---

## 5. Regels & Parameters

_Definieer de concrete spelregels en instelbare waarden voor deze feature._

| Parameter            | Waarde  | Beschrijving                    |
| -------------------- | ------- | ------------------------------- |
| RNG Systeem		   | Random Nummer tussen 1-... | De RNG bumper prefab kan worden aangepast op basis van hoe laag en hoog de maximale en minmale random waarde is|


---

## 6. Visueel Ontwerp

_Voeg schetsen, wireframes, of referentiebeelden toe. Beschrijf de gewenste look & feel._



### Schetsen / Referenties

> _Plaats hier afbeeldingen of links naar referentiemateriaal._
> `![beschrijving](pad/naar/afbeelding.png)`

### Placeholder Art Beschrijving

_Beschrijf welke placeholder art nodig is om de feature te ontwikkelen en te testen._

---

## 7. Audio Ontwerp

_Welke geluiden zijn nodig? Beschrijf per geluid het gewenste karakter._

| Geluid               | Beschrijving / Karakter            | Placeholder  |
| -------------------- | ---------------------------------- | ------------ |
| _bijv. activate SFX_ | _Korte, punchy synth hit_          | ☐ Ja / ☐ Nee |
| _bijv. loop SFX_     | _Zacht ambient hum tijdens actief_ | ☐ Ja / ☐ Nee |

---

## 8. Technische Overwegingen

### 8.1 Architectuurlaag

_In welke laag van de architectuur past deze feature? (Input & Control / Interaction / Game Logic / Feedback)_

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

_Welke nieuwe events worden aangemaakt? Op welke bestaande events wordt geabonneerd?_

| Event                        | Richting        | Beschrijving                  |
| ---------------------------- | --------------- | ----------------------------- |
| _bijv. `onPowerUpCollected`_ | Publish (nieuw) | _Fired bij oppakken power-up_ |
| _bijv. `onHitBumper`_        | Subscribe       | _Luistert naar bumper hits_   |

### 8.3 Benodigde Scripts / Componenten

| Script / Component   | Verantwoordelijkheid                   |
| -------------------- | -------------------------------------- |
| _bijv. PowerUp.cs_   | _Detectie collision, activeren effect_ |
| _bijv. PowerUpUI.cs_ | _Tonen van actief power-up icoon_      |

### 8.4 Uitschakelbaar

_Beschrijf hoe deze feature uitgeschakeld kan worden zonder dat de rest van het spel breekt (conform de [Definition of Done](./DefinitionOfDone.md)). Welk GameObject moet gedeactiveerd worden?_

---

## 9. Todo Lijst

_Maak een concrete checklist van alle taken die nodig zijn om deze feature te implementeren._

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

_Noteer hier eventuele openstaande vragen, risico's of afhankelijkheden._

- _…_
