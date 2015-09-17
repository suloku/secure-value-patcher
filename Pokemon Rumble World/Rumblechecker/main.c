/* fread example: read an entire file */
#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <dirent.h>
#include <inttypes.h>

#define be16(x) ((((x)>>8)&0xFF)|(((x)<<8))&0xFF00)
#define be32(x) (((x)<<24)|(((x)>>8)&0xFF00)|(((x)<<8)&0xFF0000)|((x)>>24))

//Crc32 code from: http://rosettacode.org/wiki/CRC-32#C
uint32_t rc_crc32(uint32_t crc, const char *buf, size_t len)
{
	static uint32_t table[256];
	static int have_table = 0;
	uint32_t rem;
	uint8_t octet;
	int i, j;
	const char *p, *q;

	/* This check is not thread safe; there is no mutex. */
	if (have_table == 0) {
		/* Calculate CRC table. */
		for (i = 0; i < 256; i++) {
			rem = i;  /* remainder from polynomial division */
			for (j = 0; j < 8; j++) {
				if (rem & 1) {
					rem >>= 1;
					rem ^= 0xedb88320;
				} else
					rem >>= 1;
			}
			table[i] = rem;
		}
		have_table = 1;
	}

	crc = ~crc;
	q = buf + len;
	for (p = buf; p < q; p++) {
		octet = *p;  /* Cast to unsigned octet. */
		crc = (crc >> 8) ^ table[(crc & 0xff) ^ octet];
	}
	return ~crc;
}

int main (int argc, char *argv[]) {

    printf("Pokemon Rumble World Save Checker\n\n");

    unsigned int filecrc32;
    unsigned int calccrc32;

    FILE * pFile;
    long lSize;
    char * buffer;
    size_t result;
    char* ext;

    int badfiles = 0;
    int totalfiles = 0;
    unsigned long decsize = 0;

    DIR *dir;
    struct dirent *ent;
    char filename[250];

    int c;
    int compressed = 1;
    while(1){
        printf("Is this a compressed folder? y/n\n");
        c=getchar();
        getchar();
        if(c=='y'|| c =='Y'){compressed=1;break;}
        else if (c=='n'|| c =='N'){compressed=0;break;}
    }

if(compressed){
        if ((dir = opendir (".")) != NULL) {
          /* print all the files and directories within directory */
            while ((ent = readdir (dir)) != NULL) {
                sprintf (filename, "%s", ent->d_name);
                ext=strrchr(filename,'.');
                if (strcmp(filename, ".") == 0 || strcmp(filename, "..") == 0 || strncmp(ext+1, "exe", 3) == 0) continue;
                pFile = fopen ( filename , "rb" );
                if (pFile==NULL) {fputs ("File error",stderr); exit (1);}

                // obtain file size:
                fseek (pFile , 0 , SEEK_END);
                lSize = ftell (pFile);
                rewind (pFile);

                // allocate memory to contain the whole file:
                buffer = (char*) malloc (sizeof(char)*(lSize));
                if (buffer == NULL) {fputs ("Memory error",stderr); exit (2);}

                // copy the file into the buffer:
                fseek (pFile , 0 , SEEK_SET);
                result = fread (buffer,1,lSize,pFile);
                if (result != lSize) {fputs ("Reading error",stderr); exit (3);}

                /* the whole file is now loaded in the memory buffer. */
                // terminate
                fclose (pFile);
                memcpy(&filecrc32, buffer+8, 4);
                calccrc32 = rc_crc32(0, buffer+0x30, lSize-0x30);
                //printf("%" PRIX32 "\n", rc_crc32(0, buffer, lSize));

                totalfiles++;
                if (calccrc32 == be32(filecrc32)) {
                    printf ("%s CRC32 OK header:%#X file:%#X\n", filename, calccrc32, be32(filecrc32));
                }else {
                    badfiles++;
                    printf ("-->%s CRC32 BAD header:%#X file:%#X\n", filename, calccrc32, be32(filecrc32));
                    printf ("\t\tPress enter to continue...\n");
                    getchar();
                }
                free (buffer);
            }
            closedir (dir);
        } else {
          /* could not open directory */
          perror ("");
          return EXIT_FAILURE;
        }
        if (!badfiles){
            printf("All %d files OK\n", totalfiles);
        }else{
            printf("%d/%d files are BAD\n", badfiles, totalfiles);
        }
    }
    else if (!compressed){
        if ((dir = opendir (".")) != NULL) {
          /* print all the files and directories within directory */
            while ((ent = readdir (dir)) != NULL) {
                sprintf (filename, "%s", ent->d_name);
                ext=strrchr(filename,'.');
                if (strcmp(filename, ".") == 0 || strcmp(filename, "..") == 0 || strncmp(ext+1, "exe", 3) == 0) continue;
                pFile = fopen ( filename , "rb" );
                if (pFile==NULL) {fputs ("File error",stderr); exit (1);}

                // obtain file size:
                fseek (pFile , 0 , SEEK_END);
                lSize = ftell (pFile);
                rewind (pFile);

                // allocate memory to contain the whole file:
                buffer = (char*) malloc (sizeof(char)*(lSize));
                if (buffer == NULL) {fputs ("Memory error",stderr); exit (2);}

                // copy the file into the buffer:
                fseek (pFile , 0 , SEEK_SET);
                result = fread (buffer,1,lSize,pFile);
                if (result != lSize) {fputs ("Reading error",stderr); exit (3);}

                /* the whole file is now loaded in the memory buffer. */
                // terminate
                fclose (pFile);
                memcpy(&decsize, buffer+0x2c, 4);

                totalfiles++;
                if (be32(decsize)==lSize-0x30) {
                    printf ("%s filesize OK header:%d file:%d\n", filename, be32(decsize), lSize-0x30 );
                }else {
                    badfiles++;
                    printf ("-->%s filesize BAD header:%d file:%d\n", filename, be32(decsize), lSize-0x30 );
                    printf ("\t\tPress enter to continue...\n");
                    getchar();
                }
                free (buffer);
            }
            closedir (dir);
        } else {
          /* could not open directory */
          perror ("Could not open directory");
          return EXIT_FAILURE;
        }
        printf("\n");
        if (!badfiles){
            printf("All %d files OK\n", totalfiles);
        }else{
            printf("%d/%d files are BAD\n", badfiles, totalfiles);
        }
    }

    printf("Pess enter to exit...");
    getchar();
    return 0;
}
