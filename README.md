# Project_Lyssa

## Set Up Git LFS for a Unity Project:
- Go to  [the git Windows download](https://git-scm.com/download/win)
- Download + run the installer. Make sure you set "default editor" to your default editor and not the nano editor or vim.
- navigate in Git bash to the folder where you want to keep the project (e.g. ```cd D:/documents```)
- run the command ```git lfs install```
  - You should receive the response ```Git LFS initialized.```
  
  
### Creating a New Git LFS Repository
- run ```git init``
- run ```git lfs track "*.psd"```
- open the ```.gitattributes``` file created by the previous command
  - paste the text from [this GitHub repository](https://gist.github.com/Srfigie/77b5c15bc5eb61733a74d34d10b3ed87)
- run ```git add .gitattributes``` to make your first commit
- run ```git commit -m "commit message"```
- run ```git remote add origin <git@github.com:username/new_repo>```
- run ```git push -u origin <branch name>```

### Cloning an existing Git LFS Repository
- run ```git lfs clone <https://github.com/USERNAME/REPOSITORY.git>``` 
  - for this repository: https://github.com/andreabeatrice/Project_Lyssa.git

### To Commit New Code
- ```git add .```
- ```git commit -m "commit message"```
- ```git push origin <branch name>```
