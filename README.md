# Tree View File Manager

This is a C# console application that demonstrates Object-Oriented programming concepts. The program creates a file system with a Root node, folders, and items.

# Classes
The program consists of the following classes:

  * Program: The main class that contains the entry point to the application.
  * Node: The base class that all nodes inherit from.
  * Root: A node that represents the root of the file system.
  * Folder: A node that represents a folder in the file system.
  * Item: A node that represents a file in the file system.
  * OutputOperater: A class that contains helper functions for console output Usage.
  
  
The Program class contains the Main method which demonstrates various object-oriented programming concepts such as inheritance, encapsulation, and polymorphism. The program creates a file system with a Root node, folders, and items.

# The program demonstrates the following functionality:

  * Creating a root node and adding folders and items to it.
  * Adding and deleting items within a folder.
  * Items cannot contain anything.
  * Cannot create multiple root nodes.
  * Cannot add root to any node.
  * Deleting a folder should delete everything contained in the folder.
  * Adding and deleting folders.
  * Moving items or folders (along with the contents, if it is a folder being moved).
  * Moving a folder should move everything contained within the folder.
  
# Usage
  
When you run the program, you will see a welcome message followed by the current state of the tree. You can use the menu options to perform various actions on the tree.

![image](https://user-images.githubusercontent.com/93319255/225887840-3824bbfc-20bd-418d-871f-0d3dddeec99c.png)

Menu Options
+**Add Node:** Prompts the user to enter the name of the parent and subset nodes they want to add, and then adds the subset to the parent.
+**Remove Node:** Prompts the user to enter the name of the node they want to remove, and then removes it from the tree.
+**Move Node:** Prompts the user to enter the names of the parent and subset nodes they want to move, and then moves the subset to the parent.
+**Search Node:** Prompts the user to enter the name of the node they want to search for, and then searches the tree for that node.
+**Test the whole program:** Runs a series of tests on the program to ensure it is functioning correctly.
+**Exit:** Exits the program.

### This program was created by *Arian DEHGHANI*


# Testing 

Try to creat another root. 

![image](https://user-images.githubusercontent.com/93319255/225770023-8e1c0ada-9a5b-42e6-8660-2c7a2e2e8db1.png)

Adding items within a folder.

![image](https://user-images.githubusercontent.com/93319255/225770345-07494175-0a8c-4981-9d04-812c00c656d4.png)

Try to add item to another item.

![image](https://user-images.githubusercontent.com/93319255/225770417-7e78c3ee-08af-4e6c-8ac0-6f33c9bb5be0.png)

Try to add root to a folder.

![image](https://user-images.githubusercontent.com/93319255/225770475-52c4c7d5-5a9a-465a-bd32-9f4d3e417ea8.png)

Deleting items within a folder.

![image](https://user-images.githubusercontent.com/93319255/225770698-a2f5c580-fdb5-4497-8984-9553c912653b.png)

Try to remove item from another item.

![image](https://user-images.githubusercontent.com/93319255/225770734-f3ca697b-54d8-421e-9b45-bd8d69cd1e68.png)

Adding folders.

![image](https://user-images.githubusercontent.com/93319255/225770762-92b3926e-b4a7-4855-97e5-a4a0fc80c084.png)

Try to add item to the root.

![image](https://user-images.githubusercontent.com/93319255/225770795-376b85c6-790c-42c0-bc0f-8ee36dcabf32.png)

Deleting folders.

![image](https://user-images.githubusercontent.com/93319255/225770849-29011726-83c2-4d69-b3b4-512863a25cee.png)

Searching item.

![image](https://user-images.githubusercontent.com/93319255/225770886-e4bc5aa8-6cd9-42bd-bd54-fd2aebc800c1.png)

Searching Folder.

![image](https://user-images.githubusercontent.com/93319255/225770968-8717667b-e5ba-481f-be85-506a8bfd54a1.png)

Moving Items.

![image](https://user-images.githubusercontent.com/93319255/225771010-52db3a7e-cac4-4787-bdfe-341f04777265.png)

Moving Folder.

![image](https://user-images.githubusercontent.com/93319255/225771050-51852eeb-acaa-4e07-93c7-0b1d38be2a58.png)

Try to move root to a folder.

![image](https://user-images.githubusercontent.com/93319255/225771098-baddbe7b-8c74-4ac3-8a8f-c2eb97e21b47.png)

Try to move item to a root.

![image](https://user-images.githubusercontent.com/93319255/225771119-a365333f-594e-4a45-b78b-c046b4964838.png)
