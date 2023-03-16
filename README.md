# TreeView

This is a C# console application that demonstrates Object-Oriented programming concepts. The program creates a file system with a Root node, folders, and items.

# Classes
The program consists of the following classes:

  ### Program: The main class that contains the entry point to the application.
  ### Node: The base class that all nodes inherit from.
  ### Root: A node that represents the root of the file system.
  ### Folder: A node that represents a folder in the file system.
  ### Item: A node that represents a file in the file system.
  ### OutputOperater: A class that contains helper functions for console output Usage.
  
  
The Program class contains the Main method which demonstrates various object-oriented programming concepts such as inheritance, encapsulation, and polymorphism. The program creates a file system with a Root node, folders, and items.

# The program demonstrates the following functionality:

  ### Creating a root node and adding folders and items to it.
  ### Adding and deleting items within a folder.
  ### Items cannot contain anything.
  ### Cannot create multiple root nodes.
  ### Cannot add root to any node.
  ### Deleting a folder should delete everything contained in the folder.
  ### Adding and deleting folders.
  ### Moving items or folders (along with the contents, if it is a folder being moved).
  ### Moving a folder should move everything contained within the folder.
  
When running the application, the console output will display the actions performed by the program, and their results.

## This program was created by *Arian DEHGHANI*

render();
Images(Folder) Added!

Videos(Folder) Added!

img1(Item) Added!

img2(Item) Added!

video1(Item) Added!

video2(Item) Added!


Try to creat another root. 

 Creat root1

[ERROR]: Cannot create multiple root nodes.

---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Images(Folder)

                **img1(Item)

                **img2(Item)

        ****Videos(Folder)

                **video1(Item)

                **video2(Item)

---------------------------------------------------------------------------------------------------------------------

Adding items within a folder.

Videos(Folder) add video3(Item)

video3(Item) Added!

Images(Folder) add img3(Item)

img3(Item) Added!


---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Images(Folder)

                **img1(Item)

                **img2(Item)

                **img3(Item)

        ****Videos(Folder)

                **video1(Item)

                **video2(Item)

                **video3(Item)

---------------------------------------------------------------------------------------------------------------------

Try to add item to another item.

img1(Item) add img3(Item)

[ERROR]: Cannot add collection to an item

---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Images(Folder)

                **img1(Item)

                **img2(Item)

                **img3(Item)

        ****Videos(Folder)

                **video1(Item)

                **video2(Item)

                **video3(Item)

---------------------------------------------------------------------------------------------------------------------

Try to add root to a folder.

Videos(Folder) add Desktop(Root)

[ERROR]: Cannot add a root node to a folder or another root node.

---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Images(Folder)

                **img1(Item)

                **img2(Item)

                **img3(Item)

        ****Videos(Folder)

                **video1(Item)

                **video2(Item)

                **video3(Item)

---------------------------------------------------------------------------------------------------------------------

Deleting items within a folder.

img1(Item) remove from Images(Folder)

img1(Item) Removed!

video2(Item) remove from Videos(Folder)

video2(Item) Removed!


---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Images(Folder)

                **img2(Item)

                **img3(Item)

        ****Videos(Folder)

                **video1(Item)

                **video3(Item)

---------------------------------------------------------------------------------------------------------------------

Try to remove item from another item.

img3(Item) remove from img1(Item)

[ERROR]: Item cannot have children

---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Images(Folder)

                **img2(Item)

                **img3(Item)

        ****Videos(Folder)

                **video1(Item)

                **video3(Item)

---------------------------------------------------------------------------------------------------------------------

Adding folders.

Desktop(Root) add Musics(Folder)

Musics(Folder) Added!


---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Images(Folder)

                **img2(Item)

                **img3(Item)

        ****Videos(Folder)

                **video1(Item)

                **video3(Item)

        ****Musics(Folder)

---------------------------------------------------------------------------------------------------------------------

Try to add item to the root.

Desktop(Root) add img3(Item)

[ERROR]: Only folder are allowed as collection of the root

---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Images(Folder)

                **img2(Item)

                **img3(Item)

        ****Videos(Folder)

                **video1(Item)

                **video3(Item)

        ****Musics(Folder)

---------------------------------------------------------------------------------------------------------------------

Deleting folders.

Videos(Folder) remove from Desktop(Root)

Videos(Folder) Removed!


---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Images(Folder)

                **img2(Item)

                **img3(Item)

        ****Musics(Folder)

---------------------------------------------------------------------------------------------------------------------

Searching item.

img2 Searched!

---------------------------------------------------------------------------------------------------------------------
Resaults :
                **img2(Item)   from: Desktop(Root)/Images(Folder)

---------------------------------------------------------------------------------------------------------------------

Searching Folder.

images Searched!

---------------------------------------------------------------------------------------------------------------------
Resaults :
        ****Images(Folder)   from: Desktop(Root)/Desktop(Root)

                **img2(Item)   from: Desktop(Root)/Images(Folder)

                **img3(Item)   from: Desktop(Root)/Images(Folder)

---------------------------------------------------------------------------------------------------------------------

---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Images(Folder)

                **img2(Item)

                **img3(Item)

        ****Musics(Folder)

---------------------------------------------------------------------------------------------------------------------

Moving Items.

img2(Item) moved to Musics(Folder)

img2(Item) Removed!

img2(Item) Added!

img2(Item) Moved to Musics(Folder)


---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Images(Folder)

                **img3(Item)

        ****Musics(Folder)

                **img2(Item)

---------------------------------------------------------------------------------------------------------------------

Moving Folder.

Images(Folder) moved to Musics(Folder)

Images(Folder) Removed!

Images(Folder) Added!

img3(Item) Removed!

img3(Item) Added!

img3(Item) Moved to Images(Folder)

Images(Folder) Moved to Musics(Folder)

---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Musics(Folder)

                **img2(Item)

                **Images(Folder)

                        *img3(Item)

---------------------------------------------------------------------------------------------------------------------

Try to move root to a folder.

Desktop(Root) moved to Musics(Folder)

[ERROR]: Cannot move the root

---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Musics(Folder)

                **img2(Item)

                **Images(Folder)

                        *img3(Item)

---------------------------------------------------------------------------------------------------------------------

Try to move item to a root.

img2(Item) moved to Desktop(Root)

[ERROR]: Cannot move a node to the root
[ERROR]: Cannot move a node to an item

---------------------------------------------------------------------------------------------------------------------

****************Desktop(Root)**********************

        ****Musics(Folder)

                **img2(Item)

                **Images(Folder)

                        *img3(Item)

---------------------------------------------------------------------------------------------------------------------
