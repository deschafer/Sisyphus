### Overview:

This readme is a basic overview of the processes involved in using github as our source management system. There will be a focus on using the GUI elements of git via github, and we will no go into any serious detail about command line GIT commands. Before we discuss any major ideas, please consider the following points.
1.	No private branches
a.	This has been iterated on many times, however it is important that everyone keeps their source in a public location and up to date with its main branch as often as possible.
b.	This means weekly, even daily, commits to your public branch.
2.	Push all code changes to your specific branch.
a.	The master branch is the working and safe version of our game. So we only want to push changes to it that have been tested and deemed safe.
3.	Stay up to date on the other branches of the project.
a.	Routinely look at what the other team members are doing for their features. If you must work with their components later on, try to get an idea how you will do that and ask questions to get a better idea.

### Startup:
First, to get to work on our project, you will need to clone our directory. To do this, the easiest way is through the installation of GitHub Desktop. This will allow for you complete any git actions for the repo without having to worry about the details of the command line procedures.
Once you have installed GitHub Desktop, you can then clone a new repository from File->Clone repository…
From here, select the URL tab and paste in the git URL from our GitHub repository. You can find this by going to www.github.com/deschafer/Sisyphus, the select “Clone or Download,” and copy the address given.
Chose a safe and accessible local path for this repository. Once this is completed, you have cloned the repository and should be able to open the files through unity and begin work.

### Workflow:
This section describes how exactly we will be adding our source code changes to the repository, and how they will make it into the master branch.
Essentially the process is as follows:
1.	Create a new branch for the development of your feature. All changes you make will be pushed to this branch during development.
2.	Develop and test your feature. Make constant commits to your branch.
3.	Prepare your feature for integration.
4.	Create a pull request to merge with the master branch.
a.	At this stage, someone else in the group should review your changes and test if it will cause any issues in the master branch.
b.	If it is deemed safe, then it will be merged into the master.

To do each of these steps, follow the guidelines below:
#### For step 1.
	To create a new branch, go to the home page of the repository and create a new branch under “Branches.” Name this branch accordingly so the rest of the team knows who is working on the branch and what it is for.
#### For step 2.
	After you have made your changes to the project, and you want to push it to your branch, GitHub desktop will have already kept track of your changes for the current repository. Switch to the branch that you are working on. Not the master branch. Add a summary and description of your changes, then create your commit to the branch. Then, push to the origin.
#### For step 4.
	This is only to be completed once you have tested your feature adequately and are confident that it is ready to be pushed to the master. Make the pull request to merge your branch with the master branch. This can be completed at GitHub. Navigate to your branch at the GitHub repo online. Then, create a new pull request. After this stage, then request someone else in the group to look at what you have made, and to verify that it works. Once this has been completed, and the feature is deemed safe, then the pull request will be closed.

### Disaster Recovery:
As with any project, it is likely that some sort of mistake will be made that makes the current version of the project unsafe and broken. The best thing to do in this case is to revert to a previous commit. This is simple to do. Under your branch on the GitHub site online, click on the commits. Then from here, we can revert to any instance before a commit was pushed to this branch.

### Additional Resources:
If you need any additional assistance with using the repository, please let me know, or take a look at the GitHub documentation at https://guides.github.com/. 
