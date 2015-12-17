#include <stdio.h>
#include <stdlib.h>
#include <conio.h>

#define ARRAYLEN 10
int source[] = { 54, 90, 6, 69, 12, 37, 92, 28, 65, 83 };
typedef struct bat
{
	int data;
	bat* left;
	bat* right;


} BSTree;

void InsertBST(BSTree* t, int key)
{
	BSTree *p, *parent, *head;
	if (!(p = (BSTree *)malloc(sizeof(BSTree *))))
	{
		printf("申请内存出错");
		exit(0);
	}
	p->data = key;
	p->left = p->right = NULL;
	head = t;
	parent = head;
	while (head)
	{
		parent = head;
		if (key < head->data)
		{
			head = head->left;
		}
		else
		{
			head = head->right;
		}

	}
	if (key < parent->data)
	{
		parent->left = p;
	}
	else
	{
		parent->right = p;
	}

}

void CreateBST(BSTree* t, int data[], int n)
{
	int i;
	t->data = data[0];
	t->left = t->right = NULL;
	for (i = 1; i < n; i++)
	{
		InsertBST(t, data[i]);
	}
}
void BST_LDR(BSTree *t)
{
	if (t)
	{
		BST_LDR(t->left);
		printf("%d ", t->data);
		BST_LDR(t->right);
	}
	return;
}

BSTree *SearchBST(BSTree* t, int key)
{
	if (!t || t->data == key)
	{
		return t;
	}
	else if (key < t->data)
	{
		return SearchBST(t->left, key);
	}
	else
	{
		return SearchBST(t->right, key);
	}
}


void BST_Delete(BSTree* t, int key)
{
	BSTree *p, *parent, *l, *l1;
	int child = 0;
	if (!t)return;
	p = t;
	parent = p;
	while (p)
	{
		if (p->data == key)
		{
			if (!p->left&&!p->right)
			{
				if (p == t)
				{
					free(t);
				}
				else if (child == 0)
				{
					parent->left = NULL;
					free(p);
				}
				else
				{
					parent->right = NULL;
				}
			}
			else if (!p->left)
			{
				if (child == 0)
				{
					parent->left = p->right;
				}
				else
				{
					parent->left = p->left;
				}
				free(p);
			}
			else if (!p->right)
			{
				if (child == 0)
				{
					parent->right = p->right;
				}
				else
				{
					parent->right = p->left;
				}
				free(p);
			}
			else
			{
				l1 = p;
				l = p->right;
				while (l->left)
				{
					l1 = l;
					l = l->left;
				}
				p->data = l->data;
				l1->left = NULL;
				free(l1);

			}
			p = NULL;
		}
		else if (key < p->data)
		{
			child = 0;
			parent = p;
			p = p->left;
		}
		else
		{
			child = 1;
			parent = p;
			p = p->right;
		}

	}

}

int main()
{
	int key, i;
	BSTree bst, *pos;
	CreateBST(&bst, source, ARRAYLEN);
	printf("遍历二叉排序树结果:");
	BST_LDR(&bst);


	scanf_s("%d", &key);
	pos = SearchBST(&bst, key);
	if (pos)
	{
		printf("search successfull!");
	}
	else
	{
		printf("search failed!");
	}
	getchar();
	getchar();
	return 0;
}