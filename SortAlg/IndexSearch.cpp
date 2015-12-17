#include <stdio.h>
#define INXEXTABLE_LEN 3
#define TABLE_LEN 30
typedef struct item
{
	int index;
	int start;
	int length;
}INDEXITEM;

long stu[TABLE_LEN] = { 1080101, 1080102, 1080104, 1080105, 1080106, 108016, 0, 0, 0, 0,
1080201, 1080202, 1080203, 1080204, 0, 0, 0, 0, 0, 0,
1080301, 1080302, 1080303, 1080304, 0, 0, 0, 0, 0, 0 };

INDEXITEM indextable[INXEXTABLE_LEN] =
{
	{ 10801, 0, 0 },
	{ 10802, 10, 4 },
	{ 10803, 20, 4 }
};
int indexSearch(int key)
{
	int i, index1, start, length;
	index1 = key / 100;
	for (i = 0; i < INXEXTABLE_LEN; i++)
	{
		if (indextable[i].index == index1)
		{
			start = indextable[i].start;
			length = indextable[i].length;
			break;
		}
		if (i>INXEXTABLE_LEN)
		{
			return -1;
		}
		for (i = start; i < start + length; i++)
		{
			if (stu[i] == key)
			{
				return i;
			}
			return -1;
		}
	}
}
int InsertNode(int key)
{
	int i, index1, start, length;
	index1 = key / 100;
	for (i = 0; i < INXEXTABLE_LEN; i++)
	{
		if (indextable[i].index == index1)
		{
			start = indextable[i].start;
			length = indextable[i].length;
			break;
		}
		if (i>INXEXTABLE_LEN)
		{
			return -1;
		}
		stu[start + length] = key;
		indextable[i].length++;
		return 0;
	}
}