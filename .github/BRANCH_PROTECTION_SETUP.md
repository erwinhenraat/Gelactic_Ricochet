# Branch Protection Setup voor Gelactic_Ricochet

Dit document beschrijft hoe je branch protection regels instelt voor de `development` branch, zodat collaborators alleen via pull requests kunnen bijdragen.

## Vereisten

Collaborators moeten:
- ✅ Nieuwe branches kunnen maken vanaf `development`
- ✅ Kunnen pushen naar hun eigen branches
- ❌ NIET direct kunnen pushen naar `development`
- ✅ Pull requests kunnen maken naar `development`
- ⚠️ Pull requests moeten door jou worden goedgekeurd en gemerged

## Stappen om Branch Protection in te stellen

### 0. Maak eerst de Development Branch aan (indien nog niet aanwezig)

Als de `development` branch nog niet bestaat in de repository:

```bash
# Ga naar de repository directory
cd /pad/naar/Gelactic_Ricochet

# Zorg dat je op de hoofd branch staat (main of master)
git checkout main  # of: git checkout master

# Maak de development branch aan
git checkout -b development

# Push de nieuwe branch naar GitHub
git push -u origin development
```

Of via GitHub web interface:
1. Ga naar de repository op GitHub
2. Klik op de branch dropdown (staat standaard op "main" of "master")
3. Typ "development" in het zoekveld
4. Klik op "Create branch: development from 'main'"

### 1. Ga naar Repository Settings

1. Open de repository: https://github.com/erwinhenraat/Gelactic_Ricochet
2. Klik op **Settings** (bovenaan, rechtse tab)
3. Klik in het linkermenu op **Branches** (onder "Code and automation")

### 2. Voeg Branch Protection Rule toe

1. Klik op **Add branch protection rule** (of **Add rule**)
2. Vul bij **Branch name pattern** in: `development`

### 3. Configureer de Protection Rules

Vink de volgende opties aan:

#### ✅ Require a pull request before merging
- Schakel deze optie in
- **Require approvals**: Stel in op minimaal **1** approval
- ✅ **Dismiss stale pull request approvals when new commits are pushed** (aanbevolen)
- ✅ **Require review from Code Owners** (gebruikt het CODEOWNERS bestand)

#### ✅ Require status checks to pass before merging (optioneel)
- Alleen indien je CI/CD workflows hebt

#### ✅ Require conversation resolution before merging (aanbevolen)
- Zorgt ervoor dat alle discussies zijn opgelost voor merging

#### ✅ Require linear history (optioneel maar aanbevolen)
- Houdt de git history schoon

#### ✅ Include administrators (optioneel)
- Als je ook jezelf aan deze regels wilt houden
- Voor extra veiligheid is dit aan te raden

#### ❌ Allow force pushes
- Laat dit UIT staan (niet aanvinken)
- Voorkomt dat mensen de history overschrijven

#### ❌ Allow deletions
- Laat dit UIT staan (niet aanvinken)
- Voorkomt dat de development branch wordt verwijderd

### 4. Sla de regel op

Klik onderaan op **Create** of **Save changes**

## Collaborator Workflow

Na het instellen van deze regels werken collaborators als volgt:

### Nieuwe feature/bugfix beginnen:

```bash
# Update lokale development branch
git checkout development
git pull origin development

# Maak een nieuwe branch
git checkout -b feature/mijn-nieuwe-feature

# Werk aan de feature
git add .
git commit -m "Beschrijving van wijzigingen"

# Push naar eigen branch
git push origin feature/mijn-nieuwe-feature
```

### Pull Request maken:

1. Ga naar de repository op GitHub
2. Klik op **Pull requests** tab
3. Klik op **New pull request**
4. Selecteer:
   - **base**: `development`
   - **compare**: `feature/mijn-nieuwe-feature`
5. Klik op **Create pull request**
6. Vul een beschrijving in
7. Wacht op jouw approval

### Na goedkeuring:

- Jij (repository owner) merged de pull request
- De collaborator kan de branch verwijderen en een nieuwe feature beginnen

## CODEOWNERS Bestand

Het `.github/CODEOWNERS` bestand is al aangemaakt en specificeert dat:
- Alle wijzigingen review vereisen van @erwinhenraat

## Collaborator Permissions

Voor de juiste werking moeten collaborators de rol **Write** hebben:

1. Ga naar **Settings** > **Collaborators and teams**
2. Voeg collaborators toe met **Write** toegang
3. Met Write toegang kunnen ze:
   - Branches maken
   - Pushen naar hun eigen branches
   - Pull requests maken
   - NIET direct pushen naar protected branches

## Verificatie

Test de setup door:
1. Een collaborator toe te voegen
2. De collaborator een nieuwe branch te laten maken vanaf development
3. Te controleren dat directe push naar development wordt geblokkeerd
4. Een pull request te maken en te verifiëren dat jouw approval vereist is

## Extra beveiliging (optioneel)

### Restrict who can push to matching branches
- In de branch protection rule kun je ook expliciet instellen wie WEL direct mag pushen
- Dit is optioneel als "Require a pull request before merging" al is ingeschakeld

### Branch protection voor andere branches
- Overweeg ook protection voor `main` of `master` branch indien aanwezig
- Gebruik dezelfde instellingen als voor `development`

## Troubleshooting

**Probleem**: Collaborator kan geen branch maken
- **Oplossing**: Controleer of ze minimaal Write toegang hebben

**Probleem**: Pull request kan niet worden gemerged
- **Oplossing**: Controleer of alle required checks zijn geslaagd en approval is gegeven

**Probleem**: CODEOWNERS werkt niet
- **Oplossing**: Controleer of "Require review from Code Owners" is aangevinkt in branch protection

## Referenties

- [GitHub Branch Protection Documentation](https://docs.github.com/en/repositories/configuring-branches-and-merges-in-your-repository/managing-protected-branches/about-protected-branches)
- [GitHub CODEOWNERS Documentation](https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/about-code-owners)
