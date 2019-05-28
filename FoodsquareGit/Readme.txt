-GitHub Account

Freaqke
Mofo121191!

-how to get started

Right-click application folder
Left click Git bash here

enter command "git init" to initialize folder as git repository ( now you can use commands )

-After inilization
#Setup
Configure name = git config --global user.name 'name'
Configure email = git config --global user.email 'email@email.com'

#Commands
Add file to git repository = git add filename/ ( everything in file)
                             git add filename.filetype 
Add everything = 1 git add .

Check which files are being tracked = git status

Remove a file = git rm --cached filename/ ( everything in file)
                                filename.filetype

-After checking files and status
Commit files = git commit

Click i to be able to type in vim window
Press escape to get out of insert and type :wq to finish commit

-Skipping vim window
git commit -m 'comment what commit includes'

-Files that you dont want tracked
touch .gitignore ( Create ignore file )

Add the file that you dont want tracked in the gitignore file an save it

git status
git add .
git status
git commit -m 'Comment what commit includes'

-Remote repository ( github )

Check if there is a remote repository = git remote
add repository = git remote add origin https://github.com/Freaqke/Foodsquare.git (https link)

push files = push -u origin master

-After
git push = after commiting into local repository





