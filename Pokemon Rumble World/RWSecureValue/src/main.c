#include <stdio.h>
#include <stdlib.h>
#include <string.h>
#include <dirent.h>
#include <inttypes.h>
#include "include/zlib.h"

#define be16(x) ((((x)>>8)&0xFF)|(((x)<<8))&0xFF00)
#define be32(x) (((x)<<24)|(((x)>>8)&0xFF00)|(((x)<<8)&0xFF0000)|((x)>>24))

//#define DEBUG

/*
Rumble world header information by SciresM

0x30 byte header {
8 byte signature, "cAVIAR4\00";
4 byte crc32 of compressed data; // Big Endian
0x1C bytes unused;
4 byte isCompressed; // Little Endian, 01/00
4 byte DecompressedSize; // Big Endian
}

SciresM said compression is default zlib compression, but I had to use level 9 to achieve the same compression
*/

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


int main()
{
    FILE * pFile;
    long lSize;
    long lSizeNew;
    char * saveOld;
    char * saveNew;
    Bytef * decbuffer;
    Bytef * decbufferNew;
    Bytef * compbuffer;
    size_t result;
    unsigned long decsize = 0;
    unsigned long decsizeNew = 0;

//Open OLD main file
    pFile = fopen ( "old/00slot00/00main.dat" , "rb" );
    if (pFile==NULL) {fputs ("Can't open \"old/00slot00/00main.dat\"",stderr); getchar(); exit (1);}

    // obtain file size:
    fseek (pFile , 0 , SEEK_END);
    lSize = ftell (pFile);
    rewind (pFile);
    saveOld = (char*) malloc (sizeof(char)*lSize);
    if (saveOld == NULL) {fputs ("Memory error",stderr); getchar(); exit (2);}
    result = fread (saveOld,1,lSize,pFile);
    if (result != lSize) {fputs ("Reading error",stderr); getchar(); exit (3);}
    fclose (pFile);
    //backup file
    pFile = fopen ("00main.dat.old.bak", "wb");
    if (pFile==NULL) {fputs ("Can't open \"00main.dat.old.bak\" to backup your 00main.dat file",stderr); getchar(); exit (4);}
    fwrite (saveOld, 1, lSize, pFile);
    fclose (pFile);

    //get decompressed size
    memcpy(&decsize, saveOld+0x2c, 4);

    //decompress on buffer
    uLong Zsize;
#ifdef DEBUG
    printf("%ld\n", Zsize);
#endif
    decbuffer = (char*) malloc (sizeof(char)*be32(decsize));
    if (decbuffer == NULL) {fputs ("Memory error",stderr); getchar(); exit (5);}
    int ret = uncompress(decbuffer, &Zsize, (Bytef*)(saveOld+0x30), (uLong)lSize-0x30);

#ifdef DEBUG
    printf("%ld\n", Zsize);
    printf("%ld\n", be32(decsize));
    printf("%d\n", ret);
#endif
    if(Zsize != be32(decsize)) {fputs ("Eror: failed to uncompress",stderr); getchar(); exit (6);}


//Open NEW main file
    pFile = fopen ( "new/00slot00/00main.dat" , "rb" );
    if (pFile==NULL) {fputs ("Can't open \"new/00slot00/00main.dat\"",stderr); getchar(); exit (7);}

    // obtain file size:
    fseek (pFile , 0 , SEEK_END);
    lSizeNew = ftell (pFile);
    rewind (pFile);
    saveNew = (char*) malloc (sizeof(char)*lSizeNew);
    if (saveNew == NULL) {fputs ("Memory error",stderr); getchar(); exit (8);}
    result = fread (saveNew,1,lSizeNew,pFile);
    if (result != lSizeNew) {fputs ("Reading error",stderr); getchar(); exit (9);}
    fclose (pFile);

    //get decompressed size
    memcpy(&decsizeNew, saveNew+0x2c, 4);

    //decompress on buffer
    uLong ZsizeNew;
#ifdef DEBUG
    printf("%ld\n", ZsizeNew);
#endif
    decbufferNew = (char*) malloc (sizeof(char)*be32(decsizeNew));
    if (decbufferNew == NULL) {fputs ("Memory error",stderr); getchar(); exit (10);}
    ret = uncompress(decbufferNew, &ZsizeNew, (Bytef*)(saveNew+0x30), (uLong)lSizeNew-0x30);

#ifdef DEBUG
    printf("%ld\n", ZsizeNew);
    printf("%ld\n", be32(decsizeNew));
    printf("%d\n", ret);
#endif
    if(ZsizeNew != be32(decsizeNew)) {fputs ("Eror: failed to uncompress",stderr); getchar(); exit (11);}

//Get secure value from NEW decompressed buffer to OLD decompressed buffer
    //Secure value (8 bytes) is stored at the end -2 bytes.
    memcpy(decbuffer+be32(decsize)-10, decbufferNew+be32(decsizeNew)-10, 8);
    //Copy header (will be updated later)
    char updatedheader[0x31];
    memcpy(updatedheader, saveOld, 0x30);

//Compress modified OLD file
    uLong ZsizeUpdated;
    //allocate decompressed size to buffer, just to be safe
    //compbuffer = (char*) malloc (sizeof(char)*be32(decsize));
    compbuffer = (char*) malloc (sizeof(char)*be32(decsize)*2);
    if (compbuffer == NULL) {fputs ("Memory error",stderr); getchar(); exit (12);}
    ret = compress2(compbuffer, &ZsizeUpdated, (Bytef*)(decbuffer), (uLong)be32(decsize), 9);

#ifdef DEBUG
    printf("%ld\n", ZsizeUpdated);
    printf("%ld\n", lSize-0x30);
    printf("%d\n", ret);
#endif

//test code
/*
    remove( "00main_dec.dat" );
    pFile = fopen ("00main_dec.dat", "wb");
    if (pFile==NULL) {fputs ("File error",stderr); getchar(); exit (20);}
    fwrite (decbuffer , 1, be32(decsize), pFile);
    fclose (pFile);
    remove( "00main_comp.dat" );
    pFile = fopen ("00main_comp.dat", "wb");
    if (pFile==NULL) {fputs ("File error",stderr); getchar(); exit (21);}
    fwrite (compbuffer , 1, lSize-0x30, pFile);
    fclose (pFile);
*/
/*
    //put new compressed size in header
    ZsizeUpdated = be32(ZsizeUpdated);
    memcpy(updatedheader+0x30-4, &ZsizeUpdated, 4);
    ZsizeUpdated = be32(ZsizeUpdated); //reflip
*/
//end of test code

    //calculate crc32 checksum of new comperessed file
    unsigned int calccrc32;
    calccrc32 = rc_crc32(0, compbuffer, ZsizeUpdated);
    calccrc32 = be32(calccrc32);
    memcpy(updatedheader+8, &calccrc32, 4);
    calccrc32 = be32(calccrc32);//flip back

//Write updated file
    if (remove ("old/00slot00/00main.dat") != 0) {fputs ("Can't delete \"old/00slot00/00main.dat\", file already in use by another program?",stderr); getchar(); exit (13);}
    pFile = fopen ("old/00slot00/00main.dat", "wb");
    if (pFile==NULL) {fputs ("Can't open \"old/00slot00/00main.dat\"",stderr); getchar(); exit (14);}
    fwrite (updatedheader , 1, 0x30, pFile);
    fwrite (compbuffer , 1, ZsizeUpdated, pFile);
    fclose (pFile);

    free (saveOld);
    free (saveNew);
    free (decbuffer);
    free (compbuffer);
    free (decbufferNew);

    printf("Your OLD file has been updated. Press enter to exit...");
    getchar();

    return 0;
}
