# Quick Reference for Contributors / Snelle Referentie voor Bijdragers

## English

### Creating a new feature/bugfix

```bash
# 1. Update your local development branch
git checkout development
git pull origin development

# 2. Create a new feature branch
git checkout -b feature/my-feature-name
# or for bugfixes:
git checkout -b fix/bug-description

# 3. Make your changes and commit
git add .
git commit -m "Clear description of changes"

# 4. Push to your branch
git push origin feature/my-feature-name

# 5. Create Pull Request on GitHub
# Go to: https://github.com/erwinhenraat/Gelactic_Ricochet
# Click: "Compare & pull request"
# Select base: development
# Wait for approval from @erwinhenraat
```

### Important Notes
- ✅ You CAN create branches from `development`
- ✅ You CAN push to your own branches
- ❌ You CANNOT push directly to `development`
- ⚠️ All changes to `development` require a Pull Request and approval

---

## Nederlands

### Een nieuwe feature/bugfix maken

```bash
# 1. Update je lokale development branch
git checkout development
git pull origin development

# 2. Maak een nieuwe feature branch
git checkout -b feature/mijn-feature-naam
# of voor bugfixes:
git checkout -b fix/bug-beschrijving

# 3. Maak je wijzigingen en commit
git add .
git commit -m "Duidelijke beschrijving van wijzigingen"

# 4. Push naar jouw branch
git push origin feature/mijn-feature-naam

# 5. Maak Pull Request aan op GitHub
# Ga naar: https://github.com/erwinhenraat/Gelactic_Ricochet
# Klik op: "Compare & pull request"
# Selecteer base: development
# Wacht op goedkeuring van @erwinhenraat
```

### Belangrijke Opmerkingen
- ✅ Je KAN branches maken vanaf `development`
- ✅ Je KAN pushen naar je eigen branches
- ❌ Je KAN NIET direct pushen naar `development`
- ⚠️ Alle wijzigingen aan `development` vereisen een Pull Request en goedkeuring

---

## Branch Naming Conventions / Branch Naamconventies

### Recommended / Aanbevolen:
- `feature/beschrijving` - voor nieuwe features
- `fix/beschrijving` - voor bug fixes
- `docs/beschrijving` - voor documentatie wijzigingen
- `refactor/beschrijving` - voor code refactoring
- `test/beschrijving` - voor test toevoegingen/wijzigingen

### Examples / Voorbeelden:
- `feature/player-movement`
- `fix/collision-detection`
- `docs/readme-update`
- `refactor/game-loop`

---

## Need Help? / Hulp nodig?

Contact the repository owner / Neem contact op met de repository eigenaar: @erwinhenraat
