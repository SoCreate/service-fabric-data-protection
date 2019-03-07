# Contributing to Service Fabric Data Protection

 - [Issues and Bugs](#issue)
 - [Request/Add a Feature](#feature)
 
## <a name="issue"></a> Found an Issue?
If you find a bug in the source code or a mistake in the documentation, you can help us by
[submitting an issue][submitissue] to our [GitHub Repository][github]. Even better, 
you can [submit a Pull Request](#submit-pr) with a fix.

## <a name="feature"></a> Want a Feature?
You can *request* a new feature by [submitting an issue][submitissue] to our [GitHub
Repository][github]. If you would like to *implement* a new feature, please submit an issue with
a proposal for your work first, to be sure that we can use it.
Please consider what kind of change it is:

* For a **Major Feature**, first open an issue and outline your proposal so that it can be
discussed. This will also allow us to better coordinate our efforts, prevent duplication of work,
and help you to craft the change so that it is successfully accepted into the project.
* **Small Features** can be crafted and directly [submitted as a Pull Request](#submit-pr).

### <a name="submit-pr"></a> Submitting a Pull Request (PR)
Before you submit your Pull Request (PR) consider the following guidelines:

* Search [GitHub](https://github.com/socreate/service-fabric-data-protection/pulls) for an open or closed PR
  that relates to your submission. You don't want to duplicate effort.
* Make your changes in a new git branch:

     ```shell
     git checkout -b my-fix-branch master
     ```

* Create your patch.
* Commit your changes using a descriptive commit message.
* Push your branch to GitHub:

    ```shell
    git push origin my-fix-branch
    ```

* In GitHub, send a pull request to `service-fabric-data-protection:master`.
* If we suggest changes then:
  * Make the required updates.
  * Rebase your branch and force push to your GitHub repository (this will update your Pull Request):

    ```shell
    git rebase master -i
    git push -f
    ```

That's it! Thank you for your contribution!
