Rumble World file integrity checker by Suloku september 2015
************************************************************

Rumblechecker.exe can check the integrity of the Pokemon Rumble World save files, since transfering this savefile trough 3ds ftbrony is prone to errors and can lead to uncomplete file transfer.

This program was made to make sure the files where transfered fine.

It can be done with a compressed savefile (00slot00) or with a decompressed savefile (if you used SciresM save editor, 00slot00_dec).

Instructions:
_____________

1.- Copy Rumblecheker.exe to 00slot00 folder or 00slot00_dec folder
2.- Run Rumblechecker.exe
3.- The program will ask if it is in a compressed (00slot00) folder, answer yes or no if it is in a decompressed (00slot00_dec) folder.

Program will output the results.

What does it do:
________________

- 00slot00 (compressed): it will calculate the crc32 of the file and compare it with the one stored in the header. This ensures almost 100% that the file is OK

- 00slot00_dec: it will calculate the filesize of the file and compare it with the one stored in the header. If it matches, everything should be ok, but there's no way to make sure if the data is correct.



Rumble world header information by SciresM
__________________________________________

0x30 byte header {
8 byte signature, "cAVIAR4\00";
4 byte crc32 of compressed data; // Big Endian
0x1C bytes unused;
4 byte isCompressed; // Little Endian, 01/00
4 byte DecompressedSize; // Big Endian
}

SciresM said compression is default zlib compression, but I had to use level 9 to achieve the same compression