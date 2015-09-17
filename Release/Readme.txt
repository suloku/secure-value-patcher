This program will update the secure value of OLD savegame with the one present in the NEW savegame.
The secure value location is given by the "Secure Value File". I've included the files for Pokemon Shuffle and Animal Crossing New Leaf, since at the moment they are the only ones we know for sure.

The secure value file is just a plain text file which only content is the offset where the secure value is stored (in hexadecimal). This way the program can be used for any savegame, we only need to discover where the secure value of the file is stored and put it in a file.

Much thanks to DaBlackDeath for the source of his original updater for pokemon shuffle, this is just a modification of that program to make it more universal.

NOTE: Pokemon Rumble World uses compression and is currently not supported. A separate tool is available here: https://gbatemp.net/threads/antisavegame-restore-secure-value-updater-ps-acnl-prw-ssb-xy-oras.396644/


[+]v2c changelog:
- Added values for Pokémon ORAS Demo and SSB. Demo.
- Source at github.

[+]v2b changelog:
- Added filesize check as a way to ensure both old and new files are from the same game

[+]v2 changelog:
- Added more known secure values
- Known secure values are now built in thanks to DaBlackDeath
- Program can backup the old savefile before updating the secure value

Credits
-------
DaBlackDeath for original Pokemon Suffle secure value fixer

__________
suloku 15'