- [PR Model](#pr-model)
- [Main Workflow](#main-workflow)
- [Validations in Nuke](#validations-in-nuke)
- [Steps detail](#steps-detail)
  - [1. Execute all UT](#1-execute-all-ut)
  - [2. Detect Projects Changed](#2-detect-projects-changed)
  - [3. Create Prerelease Nuget Packages](#3-create-prerelease-nuget-packages)
  - [4. Push Nuget Packages](#4-push-nuget-packages)


# Notes about git versioning

1. How does git versioning works?
2. Can I test it locally?
   1. It can be installed as dotnet tool, so test it locally
3. How to create the release artifacts

# NUKE
* NUKE has a client for the release:
  * Octokit -> NewRelease

* Create a custom service for gitversion:
  * Check what commands are required for the release
* Create a custom service for git with operations as:
  * Do commits
  * read tags


# Links to check

https://www.google.com/search?q=GitVersion&sxsrf=ALeKk01o_gm5KjR-DduYDnQHM_c7y7hppA%3A1623454504318&ei=KPPDYNHyEqqblwTD3LrYCA&oq=GitVersion&gs_lcp=Cgdnd3Mtd2l6EAMyBAgjECcyBwgAEIcCEBQyAggAMgIIADIFCAAQywEyBQgAEMsBMgUIABDLATIFCAAQywEyBQgAEMsBMgUIABDLAVCfoQlYn6EJYM6lCWgAcAJ4AIABYIgBtQGSAQEymAEAoAECoAEBqgEHZ3dzLXdpesABAQ&sclient=gws-wiz&ved=0ahUKEwjRpqeo35DxAhWqzYUKHUOuDosQ4dUDCA4&uact=5
https://gitversion.net/docs/reference/build-servers/
https://github.com/GitTools/GitVersion
https://github.com/marketplace/actions/gittools
https://github.com/GitTools/actions/blob/main/docs/examples/github/gitreleasemanager/index.md
https://github.com/GitTools/actions/blob/main/docs/examples/github/gitversion/execute/usage-examples.md
https://github.com/GitTools/GitVersion
https://gitversion.net/docs/
https://docs.github.com/en/github/administering-a-repository/releasing-projects-on-github/about-releases
https://cli.github.com/manual/gh_release_create
https://nuke.build/docs/authoring-builds/cli-tools.html
https://nuke.build/api/Nuke.Common/Nuke.Common.Git.GitRepository.html#methods
https://nuke.build/api/Nuke.Common/Nuke.Common.Tools.GitVersion.GitVersion.html
https://nuke.build/docs/running-builds/fundamentals.html


https://github.com/GitTools/GitVersion
https://github.com/marketplace/actions/gittools
https://github.com/GitTools/actions/blob/main/docs/examples/github/gitreleasemanager/index.md
https://github.com/GitTools/actions/blob/main/docs/examples/github/gitversion/execute/usage-examples.md
https://github.com/GitTools/GitVersion
https://gitversion.net/docs/
https://docs.github.com/en/github/administering-a-repository/releasing-projects-on-github/about-releases
https://cli.github.com/manual/gh_release_create
https://nuke.build/docs/authoring-builds/cli-tools.html
https://nuke.build/api/Nuke.Common/Nuke.Common.Git.GitRepository.html#methods
https://nuke.build/api/Nuke.Common/Nuke.Common.Tools.GitVersion.GitVersion.html
https://nuke.build/docs/running-builds/fundamentals.html