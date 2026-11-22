# openfiledialog folder
this is a c# class that directly calls windows' openfiledialog and modify it to select folders instead of files

# how to use
just download the [Class1.cs](https://github.com/eightynine77/openfiledialog-folder/blob/main/Class1.cs) file and import it into your project. when you are done importing, call the class' function like this:
```C#
string folder = FolderPicker.PickFolder("");
if (folder != null)
{
   //your function goes here
   //for example: textBox1.Text = folder;
}
```
to set the title, add the title in `FolderPicker.PickFolder("");`. like this:
```C#
string folder = FolderPicker.PickFolder("your openfiledialog title");
if (folder != null)
{

}
```
