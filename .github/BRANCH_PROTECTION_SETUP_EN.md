# Branch Protection Setup for Gelactic_Ricochet

This document describes how to set up branch protection rules for the `development` branch, so that collaborators can only contribute via pull requests.

## Requirements

Collaborators should be able to:
- ✅ Create new branches from `development`
- ✅ Push to their own branches
- ❌ NOT push directly to `development`
- ✅ Create pull requests to `development`
- ⚠️ Pull requests must be approved and merged by you (repository owner)

## Steps to Configure Branch Protection

### 0. Create the Development Branch First (if not already present)

If the `development` branch doesn't exist in the repository yet:

```bash
# Navigate to the repository directory
cd /path/to/Gelactic_Ricochet

# Make sure you're on the main branch
git checkout main  # or: git checkout master

# Create the development branch
git checkout -b development

# Push the new branch to GitHub
git push -u origin development
```

Or via GitHub web interface:
1. Go to the repository on GitHub
2. Click on the branch dropdown (defaults to "main" or "master")
3. Type "development" in the search field
4. Click on "Create branch: development from 'main'"

### 1. Navigate to Repository Settings

1. Open the repository: https://github.com/erwinhenraat/Gelactic_Ricochet
2. Click on **Settings** (top right tab)
3. Click on **Branches** in the left menu (under "Code and automation")

### 2. Add Branch Protection Rule

1. Click on **Add branch protection rule** (or **Add rule**)
2. Enter in **Branch name pattern**: `development`

### 3. Configure Protection Rules

Enable the following options:

#### ✅ Require a pull request before merging
- Enable this option
- **Require approvals**: Set to at least **1** approval
- ✅ **Dismiss stale pull request approvals when new commits are pushed** (recommended)
- ✅ **Require review from Code Owners** (uses the CODEOWNERS file)

#### ✅ Require status checks to pass before merging (optional)
- Only if you have CI/CD workflows configured

#### ✅ Require conversation resolution before merging (recommended)
- Ensures all discussions are resolved before merging

#### ✅ Require linear history (optional but recommended)
- Keeps git history clean

#### ✅ Include administrators (optional)
- If you want to apply these rules to yourself as well
- Recommended for extra security

#### ❌ Allow force pushes
- Leave this DISABLED (unchecked)
- Prevents people from overwriting history

#### ❌ Allow deletions
- Leave this DISABLED (unchecked)
- Prevents the development branch from being deleted

### 4. Save the Rule

Click **Create** or **Save changes** at the bottom

## Collaborator Workflow

After configuring these rules, collaborators work as follows:

### Starting a new feature/bugfix:

```bash
# Update local development branch
git checkout development
git pull origin development

# Create a new branch
git checkout -b feature/my-new-feature

# Work on the feature
git add .
git commit -m "Description of changes"

# Push to own branch
git push origin feature/my-new-feature
```

### Creating a Pull Request:

1. Go to the repository on GitHub
2. Click on **Pull requests** tab
3. Click on **New pull request**
4. Select:
   - **base**: `development`
   - **compare**: `feature/my-new-feature`
5. Click on **Create pull request**
6. Fill in a description
7. Wait for your approval

### After approval:

- You (repository owner) merge the pull request
- The collaborator can delete the branch and start a new feature

## CODEOWNERS File

The `.github/CODEOWNERS` file has been created and specifies that:
- All changes require review from @erwinhenraat

## Collaborator Permissions

For proper functioning, collaborators need the **Write** role:

1. Go to **Settings** > **Collaborators and teams**
2. Add collaborators with **Write** access
3. With Write access they can:
   - Create branches
   - Push to their own branches
   - Create pull requests
   - NOT push directly to protected branches

## Verification

Test the setup by:
1. Adding a collaborator
2. Having the collaborator create a new branch from development
3. Verifying that direct push to development is blocked
4. Creating a pull request and verifying that your approval is required

## Additional Security (optional)

### Restrict who can push to matching branches
- In the branch protection rule you can also explicitly specify who CAN push directly
- This is optional if "Require a pull request before merging" is already enabled

### Branch protection for other branches
- Consider protection for `main` or `master` branch if present
- Use the same settings as for `development`

## Troubleshooting

**Issue**: Collaborator cannot create branch
- **Solution**: Check if they have at least Write access

**Issue**: Pull request cannot be merged
- **Solution**: Check if all required checks have passed and approval is given

**Issue**: CODEOWNERS not working
- **Solution**: Check if "Require review from Code Owners" is enabled in branch protection

## References

- [GitHub Branch Protection Documentation](https://docs.github.com/en/repositories/configuring-branches-and-merges-in-your-repository/managing-protected-branches/about-protected-branches)
- [GitHub CODEOWNERS Documentation](https://docs.github.com/en/repositories/managing-your-repositorys-settings-and-features/customizing-your-repository/about-code-owners)
