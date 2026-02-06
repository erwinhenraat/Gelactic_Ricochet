# LEES MIJ EERST - Setup Samenvatting / READ ME FIRST - Setup Summary

## Nederlands

### 🎯 Doel
Deze pull request configureert de repository zodat collaborators:
- ✅ Branches kunnen maken vanaf `development`
- ✅ Kunnen pushen naar hun eigen branches  
- ❌ NIET direct kunnen pushen naar `development`
- ✅ Pull requests kunnen maken die door jou goedgekeurd moeten worden

### 📁 Toegevoegde Bestanden

1. **`.github/CODEOWNERS`**
   - Specificeert dat jij (@erwinhenraat) alle wijzigingen moet reviewen
   - Wordt gebruikt door GitHub's branch protection

2. **`.github/BRANCH_PROTECTION_SETUP.md`** (Nederlands)
   - Stap-voor-stap handleiding om branch protection in te stellen
   - Bevat screenshots en gedetailleerde instructies
   - **Dit moet je volgen om de bescherming te activeren!**

3. **`.github/BRANCH_PROTECTION_SETUP_EN.md`** (English)
   - Engelse versie van de setup handleiding

4. **`.github/CONTRIBUTOR_GUIDE.md`** (Tweetalig)
   - Snelle referentie voor collaborators
   - Bevat git commando's en workflow

5. **`README.md`** (Bijgewerkt)
   - Toegevoegd: Contributing sectie met links naar documentatie

### ⚡ Acties die JIJ moet uitvoeren

#### 1. Development Branch Aanmaken (indien nog niet aanwezig)
```bash
git checkout main
git checkout -b development
git push -u origin development
```

Of via GitHub web interface (zie `.github/BRANCH_PROTECTION_SETUP.md`)

#### 2. Branch Protection Instellen op GitHub

**Volg de stappen in:** `.github/BRANCH_PROTECTION_SETUP.md`

**Korte samenvatting:**
1. Ga naar repository Settings → Branches
2. Klik "Add branch protection rule"
3. Branch pattern: `development`
4. Vink aan:
   - ✅ Require a pull request before merging
   - ✅ Require approvals (min 1)
   - ✅ Require review from Code Owners
   - ❌ Allow force pushes (UIT)
   - ❌ Allow deletions (UIT)
5. Klik "Create"

#### 3. Collaborators Toevoegen
1. Settings → Collaborators and teams
2. Voeg gebruikers toe met **Write** toegang
3. Deel de link naar `.github/CONTRIBUTOR_GUIDE.md` met hen

### 📋 Verificatie Checklist

Na het instellen, test of:
- [ ] Development branch bestaat
- [ ] Branch protection rule is actief voor `development`
- [ ] Collaborators hebben Write toegang
- [ ] Directe push naar development wordt geblokkeerd
- [ ] Pull requests vereisen jouw approval

### 📚 Documentatie Links

- **Setup Handleiding (NL):** `.github/BRANCH_PROTECTION_SETUP.md`
- **Setup Guide (EN):** `.github/BRANCH_PROTECTION_SETUP_EN.md`
- **Contributors Guide:** `.github/CONTRIBUTOR_GUIDE.md`

---

## English

### 🎯 Goal
This pull request configures the repository so that collaborators can:
- ✅ Create branches from `development`
- ✅ Push to their own branches
- ❌ NOT push directly to `development`
- ✅ Create pull requests that must be approved by you

### 📁 Added Files

1. **`.github/CODEOWNERS`**
   - Specifies that you (@erwinhenraat) must review all changes
   - Used by GitHub's branch protection

2. **`.github/BRANCH_PROTECTION_SETUP.md`** (Dutch)
   - Step-by-step guide to set up branch protection
   - Contains screenshots and detailed instructions
   - **You must follow this to activate protection!**

3. **`.github/BRANCH_PROTECTION_SETUP_EN.md`** (English)
   - English version of the setup guide

4. **`.github/CONTRIBUTOR_GUIDE.md`** (Bilingual)
   - Quick reference for collaborators
   - Contains git commands and workflow

5. **`README.md`** (Updated)
   - Added: Contributing section with links to documentation

### ⚡ Actions YOU need to take

#### 1. Create Development Branch (if not already present)
```bash
git checkout main
git checkout -b development
git push -u origin development
```

Or via GitHub web interface (see `.github/BRANCH_PROTECTION_SETUP_EN.md`)

#### 2. Configure Branch Protection on GitHub

**Follow the steps in:** `.github/BRANCH_PROTECTION_SETUP_EN.md`

**Quick summary:**
1. Go to repository Settings → Branches
2. Click "Add branch protection rule"
3. Branch pattern: `development`
4. Enable:
   - ✅ Require a pull request before merging
   - ✅ Require approvals (min 1)
   - ✅ Require review from Code Owners
   - ❌ Allow force pushes (OFF)
   - ❌ Allow deletions (OFF)
5. Click "Create"

#### 3. Add Collaborators
1. Settings → Collaborators and teams
2. Add users with **Write** access
3. Share the link to `.github/CONTRIBUTOR_GUIDE.md` with them

### 📋 Verification Checklist

After setup, verify that:
- [ ] Development branch exists
- [ ] Branch protection rule is active for `development`
- [ ] Collaborators have Write access
- [ ] Direct push to development is blocked
- [ ] Pull requests require your approval

### 📚 Documentation Links

- **Setup Guide (NL):** `.github/BRANCH_PROTECTION_SETUP.md`
- **Setup Guide (EN):** `.github/BRANCH_PROTECTION_SETUP_EN.md`
- **Contributors Guide:** `.github/CONTRIBUTOR_GUIDE.md`
