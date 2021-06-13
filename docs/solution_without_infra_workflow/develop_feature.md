# Develop a feature

1. [User] Create a branch from `dev`
2. [User] Create some commits
3. [User] Push the branch
4. [CI] Detect if the branch is a feature branch
6. [CI] If PR is not created, create it
7. [CI] Create feature nuget packages
8. [CI] Add comments of the package created
9. [User] Approve the PR
10. [User] Merge the PR
11. [CI] Create nuget packages for `dev`

# If the PR is updated
Repeat CI steps