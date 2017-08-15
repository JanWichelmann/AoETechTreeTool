## OVERVIEW

This is an editor for the new implementation of the ingame tech tree view (F2). It provides a simple user interface where tree nodes can be added, edited and deleted. There are also functions to import and export the new tech tree data, so these can be easily applied to existing DAT files. The new tech tree data structure is incompatible to the existing one, but the old tech tree data persists, so unmodified executables will simply ignore the new tech tree data and should not crash.

For the new ingame tech tree implementation look here: https://github.com/Janworks/AoETechTree

## USAGE

Simply load the DAT file (usually empires2_x1_p1.dat) and select language files for proper string display (usually LANGUAGE.DLL, language_x1.dll and language_x1_p1.dll). If the DAT file already contains new tech tree information, these are displayed, else the tree view will be empty. You can add, delete and move nodes using the buttons on the right. To add a new top level node, press shift key while clicking "Add". Drag&Drop is also enabled.

You can also change the tech tree design using the built-in design editor. Please be careful when changing these settings, as some of them may lead to odd rendering results or even crashes when used incorrectly. Each setting has a short help text explaining what it does and pointing out possible problems. To show this help text just put the mouse cursor onto the respective labels.

There may still be a few bugs, so let me know if you run into problems.

The files age2_x1.techtreedata and age2_x1.techtreedesign contain the vanilla tech tree and its design definitions, respectively. You may use them as basis for your modifications.


## SYSTEM REQUIREMENTS

This software depends on the .NET Framework 4.5. It should already be installed on current Windows systems; if not, you can find it here: https://www.microsoft.com/en-us/download/details.aspx?id=30653

To find out if it is installed just start the program, it will tell you when the appropriate .NET Framework version is not found.


## LEGAL INFO & CREDITS

This software is published under the MIT/X11 license. Please read the LICENSE for further information.