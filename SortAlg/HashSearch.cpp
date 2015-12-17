#include <stdio.h>
#define HASH_LEN 13
#define TABLE_LEN 8
int data[TABLE_LEN] = { 69, 65, 90, 37, 92, 6, 28, 54 };
int hash[HASH_LEN] = { 0 };
void InsertHash(int hash[], int m, int data)
{
	int i;
	i = data % 13;
	while (hash[i])
	{
		i = (++i) % m;
	}
	hash[i] = data;
}

int HashSearch(int hash[], int m, int key)
{
	int i;
	i = key % 13;
	while (hash[i]&&hash[i]!=key)
	{
		i = (++i) % m;
	}
	if (hash[i] == 0)
	{
		return -1;
	}
	else
	{
		return i;
	}
}