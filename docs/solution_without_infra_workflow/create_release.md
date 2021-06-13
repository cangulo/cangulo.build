# Create a release

1. [User] Start the create release pipeline
2. [CI] Create release branch
3. [CI] Add the release tag
4. [CI] Push the branch
5. [CI] Create a PR targeting `main`
6. [User] Common PR revisions and requirements
7. [User] Merge the PR
8. [CI] Create a GitHub Release using GH CLI
9. [CI] Provide description for the release (Copy commits text)
10. [CI] Create artifacts
11. [CI] Push artifacts to the GitHub Release