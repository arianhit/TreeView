using OO_Coding_Test;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.Security.AccessControl;
using static System.Net.Mime.MediaTypeNames;

namespace OO_Coding_Test
{
    class Program
    {

        static void Main(string[] args)
        {
            //Creat a root
            Root root = new Root("Desktop(Root)");

            OutputOperater op = new OutputOperater();
            try
            {

                //Make folders
                Folder images = new Folder("Images(Folder)");
                Folder videos = new Folder("Videos(Folder)");
                Folder musics = new Folder("Musics(Folder)");

                //Make Items
                Item item1 = new Item("img1(Item)");
                Item item2 = new Item("img2(Item)");
                Item item3 = new Item("img3(Item)");
                Item item4 = new Item("video1(Item)");
                Item item5 = new Item("video2(Item)");
                Item item6 = new Item("video3(Item)");



                //Adding folder to the root
                root.AddSubset(images);
                root.AddSubset(videos);

                //adding item to the folders
                images.AddSubset(item1);
                images.AddSubset(item2);


                //adding item to the folders
                videos.AddSubset(item4);
                videos.AddSubset(item5);

                //•	Cannot create multiple root nodes
                op.makeItColor(ConsoleColor.Yellow, "\nTry to creat another root.\n");
                op.makeItColor(ConsoleColor.Cyan, " Creat root1" + "\n");
                Root root1 = new Root("Drive(Root)");

                //•	Adding and deleting items within a folder.
                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nAdding items within a folder.\n");
                op.makeItColor(ConsoleColor.Cyan, videos.Name + " add " + item6.Name + "\n");
                videos.AddSubset(item6);
                op.makeItColor(ConsoleColor.Cyan, images.Name + " add " + item3.Name + "\n");
                images.AddSubset(item3);


                //•	Items cannot contain anything.
                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nTry to add item to another item.\n");
                op.makeItColor(ConsoleColor.Cyan, item1.Name + " add " + item3.Name + "\n");
                item1.AddSubset(item3);


                //Cannot add root to any node
                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nTry to add root to a folder.\n");
                op.makeItColor(ConsoleColor.Cyan, videos.Name + " add " + root.Name + "\n");
                videos.AddSubset(root);

                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nDeleting items within a folder.\n");
                op.makeItColor(ConsoleColor.Cyan, item1.Name + " remove from " + images.Name + "\n");
                images.RemoveSubset(item1);
                op.makeItColor(ConsoleColor.Cyan, item5.Name + " remove from " + videos.Name + "\n");
                videos.RemoveSubset(item5);

                //Cannot remove item from an item
                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nTry to remove item from another item.\n");
                op.makeItColor(ConsoleColor.Cyan, item3.Name + " remove from " + item1.Name + "\n");
                item1.RemoveSubset(item3);


                //•	Adding and deleting folders.
                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nAdding folders.\n");
                op.makeItColor(ConsoleColor.Cyan, root.Name + " add " + musics.Name + "\n");
                root.AddSubset(musics);


                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nTry to add item to the root.\n");
                op.makeItColor(ConsoleColor.Cyan, root.Name + " add " + item3.Name + "\n");
                root.AddSubset(item3);

                //•	Deleting a folder should delete everything contained in the folder.
                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nDeleting folders.\n");
                op.makeItColor(ConsoleColor.Cyan, videos.Name + " remove from " + root.Name + "\n");
                root.RemoveSubset(videos);


                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nSearching item.\n");
                search("img2");
                op.makeItColor(ConsoleColor.Yellow, "\nSearching Folder.\n");
                search("images");

                //•	Moving items or folders (along with the contents, it is a folder being moved.)
                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nMoving Items.\n");
                op.makeItColor(ConsoleColor.Cyan, item2.Name + " moved to " + musics.Name + "\n");
                item2.MoveTo(musics);


                //•	Moving a folder should move everything contained within the folder.
                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nMoving Folder.\n");
                op.makeItColor(ConsoleColor.Cyan, images.Name + " moved to " + musics.Name + "\n");
                images.MoveTo(musics);

                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nTry to move root to a folder.\n");
                op.makeItColor(ConsoleColor.Cyan, root.Name + " moved to " + musics.Name + "\n");
                root.MoveTo(musics);

                TreeView();
                op.makeItColor(ConsoleColor.Yellow, "\nTry to move item to a root.\n");
                op.makeItColor(ConsoleColor.Cyan, item2.Name + " moved to " + root.Name + "\n");
                item2.MoveTo(root);

                TreeView();
            }
            catch (Exception e)
            {
                op.outPutError(e.Message);
            }
            // Define a method to display the tree structure
            void TreeView()
            {
                // Print some separator lines to improve readability
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine();

                // Print the name of the root node
                Console.WriteLine("****************" + root.Name + "**********************\n");

                // Iterate over the child nodes of the root node
                foreach (Folder folder in root.Collection)
                {
                    // Print the name of each child node
                    Console.WriteLine("\t****" + folder.Name + "\n");

                    // Iterate over the child nodes of the current child node
                    foreach (var item in folder.Collection)
                    {
                        // Print the name of each grandchild node
                        Console.WriteLine("\t\t**" + item.Name + "\n");

                        // If the current grandchild node has child nodes, iterate over them
                        if (item.Collection.Count > 0)
                        {
                            foreach (var unit in item.Collection)
                            {
                                // Print the name of each great-grandchild node
                                Console.WriteLine("\t\t\t*" + unit.Name + "\n");
                            }
                        }
                    }
                }

                // Print some separator lines to improve readability
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            }

            // Define a method to search for a node with a given name within the tree
            void search(string searchQuery)
            {
                // Use a helper method to change the color of the console text
                op.makeItColor(ConsoleColor.Green, searchQuery + " Searched!");

                // Print some separator lines to improve readability
                Console.WriteLine();
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
                Console.WriteLine("Resaults :");

                // Call the Search method of the root node to find all nodes with the given name
                List<Node> matches = root.Search(searchQuery);

                // Iterate over the list of matches and print their names and locations in the tree
                foreach (Node match in matches)
                {
                    if (match.Collection.Count > 0)
                    {
                        // If the current match has child nodes, print their names and locations
                        Console.WriteLine("\t****" + match.Name + "   from: " + root.Name + "/" + match.Parent.Name + "\n");
                        foreach (var unit in match.Collection)
                        {
                            Console.WriteLine("\t\t**" + unit.Name + "   from: " + root.Name + "/" + unit.Parent.Name + "\n");
                        }
                    }
                    else
                    {
                        // If the current match has no child nodes, print its name and location
                        Console.WriteLine("\t\t**" + match.Name + "   from: " + root.Name + "/" + match.Parent.Name + "\n");
                    }
                }

                // Print some separator lines to improve readability
                Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            }


            Console.ReadLine();
        }

    }
}


